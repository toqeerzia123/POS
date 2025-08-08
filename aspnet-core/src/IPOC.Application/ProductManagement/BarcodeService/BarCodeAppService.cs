using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using SkiaSharp;
using ZXing.SkiaSharp.Rendering;
using ZXing;

namespace IPOC.ProductManagement.BarcodeService;
public class BarCodeAppService : ApplicationService, IBarCodeAppService
{
    private readonly IRepository<BarCode, Guid> _barCodeRepository;
    private readonly IRepository<Product, Guid> _productRepository;


    public BarCodeAppService(IRepository<BarCode, Guid> barCodeRepository, IRepository<Product, Guid> productRepository)
    {
        _barCodeRepository = barCodeRepository;
        _productRepository = productRepository;
    }

    public async Task<List<BarCodeDto>> GetAllAsync()
    {
        var barcodes = await _barCodeRepository.GetAllListAsync();
        return ObjectMapper.Map<List<BarCodeDto>>(barcodes);
    }
    public async Task<List<TreeNodeDto>> GetBarcodesGroupedAsync()
    {
        var barcodes = await _barCodeRepository.GetAllListAsync();
        var products = await _productRepository.GetAllListAsync(); // Assuming you have product names

        var productDict = products.ToDictionary(p => p.Id, p => p.Name);

        var grouped = barcodes
            .GroupBy(b => b.ProductId)
            .Select((g, index) =>
            {
                var parentKey = g.Key.HasValue ? g.Key.ToString() : "unassigned";
                var label = g.Key.HasValue && productDict.ContainsKey(g.Key.Value)
                    ? productDict[g.Key.Value]
                    : "Unassigned";

                var children = g.Select((barcode, i) => new TreeNodeDto
                {
                    Key = $"{parentKey}-{i}",
                    Label = barcode.BarcodeValue,
                    Data = barcode.BarcodeValue
                }).ToList();

                return new TreeNodeDto
                {
                    Key = parentKey,
                    Label = label,
                    Data = label,
                    Children = children
                };
            })
            .ToList();

        return grouped;
    }

    public async Task<BarCodeDto> GetAsync(Guid id)
    {
        var barcode = await _barCodeRepository.GetAsync(id);
        return ObjectMapper.Map<BarCodeDto>(barcode);
    }

    public async Task<BarCodeDto> CreateAsync(CreateUpdateBarCodeDto input)
    {
        var barcode = ObjectMapper.Map<BarCode>(input);

        if (string.IsNullOrEmpty(barcode.BarcodeValue))
        {
          //  barcode.BarcodeValue = await GenerateBarcodeInternalAsync();
        }

        barcode.BarcodeType ??= "Code128";

        await _barCodeRepository.InsertAsync(barcode);
        return ObjectMapper.Map<BarCodeDto>(barcode);
    }

    public async Task<BarCodeDto> UpdateAsync(Guid id, CreateUpdateBarCodeDto input)
    {
        var barcode = await _barCodeRepository.GetAsync(id);
        ObjectMapper.Map(input, barcode);
        await _barCodeRepository.UpdateAsync(barcode);
        return ObjectMapper.Map<BarCodeDto>(barcode);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _barCodeRepository.DeleteAsync(id);
    }
    public string GenerateBarcode(string value, string price)
    {
        // Combine value with price (optional format)
        string fullText = $"{value} - {price}";

        var writer = new BarcodeWriter<SKBitmap>
        {
            Format = BarcodeFormat.CODE_128,
            Options = new ZXing.Common.EncodingOptions
            {
                Width = 50,
                Height = 20,
                Margin = 1,
                PureBarcode = false
            },
            Renderer = new SKBitmapRenderer()
        };

        var barcodeBitmap = writer.Write(fullText);

        using (var image = SKImage.FromBitmap(barcodeBitmap))
        using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
        {
            return Convert.ToBase64String(data.ToArray());
        }
    }
    public byte[] GenerateBarcodeWithDetails(string productName, string productCode, string price)
    {
        
        var barcodeWriter = new BarcodeWriter<SKBitmap>
        {
            Format = BarcodeFormat.CODE_128,
            Options = new ZXing.Common.EncodingOptions
            {
                Width = 200,
                Height = 70,
                Margin = 0,
                PureBarcode = true
            },
            Renderer = new SKBitmapRenderer()
        };

        var barcodeBitmap = barcodeWriter.Write(productCode);

        // Canvas setup
        int canvasWidth = 260;
        int canvasHeight = 110;
        using var finalBitmap = new SKBitmap(canvasWidth, canvasHeight);
        using var canvas = new SKCanvas(finalBitmap);
        canvas.Clear(SKColors.White);

        // Border
        using var borderPaint = new SKPaint
        {
            Color = new SKColor(200, 200, 200),
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 1,
            IsAntialias = true
        };
        canvas.DrawRect(1, 1, canvasWidth - 2, canvasHeight - 2, borderPaint);

        // Paints
        var labelPaint = new SKPaint
        {
            Color = SKColors.Black,
            TextSize = 12,
            IsAntialias = true,
            Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Normal)
        };

        var codePaint = new SKPaint
        {
            Color = SKColors.Black,
            TextSize = 14,
            IsAntialias = true,
            Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold)
        };

        var pricePaint = new SKPaint
        {
            Color = SKColors.Black,
            TextSize = 14,
            IsAntialias = true,
            Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold)
        };

        var labelMetrics = labelPaint.FontMetrics;
        var codeMetrics = codePaint.FontMetrics;

        float spacing = 1;

        // ---- Start from Top: Product Name ----
        float labelTextHeight = labelMetrics.Descent - labelMetrics.Ascent;
        float labelWidth = labelPaint.MeasureText(productName);
        float labelX = (canvasWidth - labelWidth) / 2f;
        float labelY = -labelMetrics.Ascent + spacing; // top padding
        canvas.DrawText(productName, labelX, labelY, labelPaint);

        // ---- Barcode under label ----
        float barcodeX = (canvasWidth - barcodeBitmap.Width) / 2f;
        float barcodeY = labelY + labelTextHeight + spacing;
        canvas.DrawBitmap(barcodeBitmap, barcodeX, (int)barcodeY);

        // ---- Product Code under Barcode ----
        float codeTextHeight = codeMetrics.Descent - codeMetrics.Ascent;
        float codeWidth = codePaint.MeasureText(productCode);
        float codeX = (canvasWidth - codeWidth) / 2f;
        float codeY = barcodeY + barcodeBitmap.Height + spacing - codeMetrics.Ascent;
        canvas.DrawText(productCode, codeX, codeY, codePaint);

        // ---- Vertical Price ----
        // Center vertically relative to barcode block (label + barcode + code)
        float barcodeBlockTop = labelY;
        float barcodeBlockBottom = codeY + codeMetrics.Descent;
        float barcodeBlockCenterY = (barcodeBlockTop + barcodeBlockBottom) / 2;

        float priceWidth = pricePaint.MeasureText(price);
        float priceX = -barcodeBlockCenterY + priceWidth / 2f;
        float priceY = 18;

        canvas.Save();
        canvas.RotateDegrees(-90);
        canvas.DrawText(price, priceX, priceY, pricePaint);
        canvas.Restore();

        using var image = SKImage.FromBitmap(finalBitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        return data.ToArray();
    }


}
