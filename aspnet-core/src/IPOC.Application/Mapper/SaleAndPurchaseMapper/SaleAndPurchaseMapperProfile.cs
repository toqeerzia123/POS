using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IPOC.SaleAndPurchase.InventoryAppService;
using IPOC.SaleAndPurchase;
using IPOC.SaleAndPurchase.InventoryTransactionAppService;
using IPOC.SaleAndPurchase.PurchaseAppService;
using IPOC.SaleAndPurchase.SaleAppService;
using IPOC.SaleAndPurchase.StockTransferAppService;

namespace IPOC.Mapper.SaleAndPurchase;
public class SaleAndPurchaseMapperProfile : Profile
{
    public SaleAndPurchaseMapperProfile()
    {
        CreateMap<Inventory, InventoryDto>().ReverseMap();
        CreateMap<CreateUpdateInventoryDto, Inventory>();

        CreateMap<InventoryTransaction, InventoryTransactionDto>().ReverseMap();
        CreateMap<CreateUpdateInventoryTransactionDto, InventoryTransaction>();

        CreateMap<Purchase, PurchaseDto>().ReverseMap();
        CreateMap<PurchaseItem, PurchaseItemDto>().ReverseMap();

        CreateMap<CreateUpdatePurchaseDto, Purchase>();
        CreateMap<CreateUpdatePurchaseItemDto, PurchaseItem>();

        CreateMap<PurchaseItem, PurchaseItemDto>();
        CreateMap<CreateUpdatePurchaseItemDto, PurchaseItem>();


        CreateMap<Sale, SaleDto>();
        CreateMap<CreateUpdateSaleDto, Sale>();

        CreateMap<SaleItem, SaleItemDto>();
        CreateMap<CreateUpdateSaleItemDto, SaleItem>();

        CreateMap<StockTransfer, StockTransferDto>();
        CreateMap<CreateUpdateStockTransferDto, StockTransfer>();

    }
}

