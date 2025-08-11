
import { Component, ElementRef, OnInit, signal, ViewChild } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table, TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { RatingModule } from 'primeng/rating';
import { InputTextModule } from 'primeng/inputtext';
import { TextareaModule } from 'primeng/textarea';
import { SelectModule } from 'primeng/select';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputNumberModule } from 'primeng/inputnumber';
import { DialogModule } from 'primeng/dialog';
import { TagModule } from 'primeng/tag';
import { InputIconModule } from 'primeng/inputicon';
import { IconFieldModule } from 'primeng/iconfield';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { Product, ProductService } from '../service/product.service';
import { FileUploadModule } from 'primeng/fileupload';
import { CategoryService } from '../service/categories.service';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { CheckboxModule } from 'primeng/checkbox';
import { InputGroupModule } from 'primeng/inputgroup';
import { BarcodeService } from '../service/barcode.service';
import { DatePickerModule } from 'primeng/datepicker';
import { VendorService } from '../service/vendor.service';
import { LocationsService } from '../service/locations.service';
interface Column {
    field: string;
    header: string;
    customExportHeader?: string;
}

interface ExportColumn {
    title: string;
    dataKey: string;
}
@Component({
  selector: 'app-transfer-product',
  templateUrl: './transfer-product.component.html',
  styleUrls: ['./transfer-product.component.css'],
   standalone: true,
    imports: [
        CommonModule,
        TableModule,
        FormsModule,
        ButtonModule,
        RippleModule,
        ToastModule,
        ToolbarModule,
        RatingModule,
        InputTextModule,
        TextareaModule,
        SelectModule,
        RadioButtonModule,
        InputNumberModule,
        DialogModule,
        TagModule,
        InputIconModule,
        IconFieldModule,
        ConfirmDialogModule,
        FileUploadModule,
        InputGroupAddonModule,
        CheckboxModule,
        InputGroupModule ,
        DatePickerModule,
           ReactiveFormsModule,
   
    ],
        providers: [MessageService, ProductService, ConfirmationService,CategoryService,BarcodeService,VendorService,LocationsService]
})
export class TransferProductComponent     implements OnInit {
    productDialog: boolean = false;

    products = signal<Product[]>([]);
    productpurchase:any[]=[];
    allCategories :any[]=[];
    subcategories :any[]=[];
    allVendors :any[]=[];
    allLocations :any[]=[];

    product!: Product;
    productInfo: any;

    selectedProducts!: Product[] | null;

    submitted: boolean = false;
    barcodeBase64: string="";
  onUpload(event: any) {
        for (const file of event.files) {
            this.uploadedFiles.push(file);
        }

        this.messageService.add({ severity: 'info', summary: 'Success', detail: 'File Uploaded' });
    }
     uploadedFiles: any[] = [];
     uploadedImages: string[] = [];

     onSelect(event: any): void {
  for (let file of event.files) {
    this.uploadedFiles.push(file);
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.uploadedImages.push(e.target.result);
    };
    reader.readAsDataURL(file);
  }
}
barcodeDialogVisible = false;
newBarcodeValue:number=2;
  barcodes: any[] = [];
  chunkedBarcodes: string[][] = [];
addbarcode() {
  this.barcodes = [];
  this.barcodeDialogVisible = true;
  for (let i = 0; i < this.newBarcodeValue; i++) {
   
  this.barcodes.push(this.barcodeBase64);
  }
    this.chunkBarcodes()
}
saveBarcode() {
  this.submitted = true;
}
private chunkBarcodes(): void {
  this.chunkedBarcodes = [];
  for (let i = 0; i < this.barcodes.length; i += 2) {
    this.chunkedBarcodes.push(this.barcodes.slice(i, i + 2));
  }
}
generate(data:any) {
    debugger
    this.chunkedBarcodes=[]
      this.barcodeDialogVisible = true;
      this.newBarcodeValue=Number(data.quantity) || 2;
      this.barcodeBase64 = '';
    this.barcodeService.generateBarcode(data.name, data.productCode, data.price).subscribe({
      next: (res:any) => {
        debugger
        this.barcodeBase64 =`data:image/png;base64,${res.result}`
      },
      error: (err:any) => {
        console.error('Failed to generate barcode:', err);
      }
    });
  // TODO: Trigger print logic
}
  @ViewChild('printSection') printSectionRef!: ElementRef;
  onclickButtonClick() {
    const printContent = this.printSectionRef.nativeElement.innerHTML;

    const WindowPrt = window.open('', '', 'width=900,height=650');
    if (WindowPrt) {
      WindowPrt.document.write(`
        <html>
          <head>
            <title>Print Barcode</title>
            <style>
              body { font-family: Arial, sans-serif; margin: 20px; }
              .barcode-line { display: flex; gap: 10px; }
              .barcode-line img { width: 200px; height: auto; }
              .dotted-line { border-top: 1px dotted #000; margin: 20px 0; }
            </style>
          </head>
          <body onload="window.print();window.close()">
            ${printContent}
          </body>
        </html>
      `);
      WindowPrt.document.close();
    }
  }
    statuses!: any[];

    @ViewChild('dt') dt!: Table;

    exportColumns!: ExportColumn[];

    cols!: Column[];

    constructor(
        private productService: ProductService,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private categoryService: CategoryService,
        private barcodeService: BarcodeService,
        private fb: FormBuilder,
        private vendorService: VendorService,
        private locationsService: LocationsService,
    ) {}
 productForm!: FormGroup;
    exportCSV() {
        this.dt.exportCSV();
    }

    ngOnInit() {
        this.loadDemoData();
           this.productForm = this.fb.group({
      fromLocation: ['', [Validators.required, Validators.minLength(2)]],
      toLocation: ['', Validators.required],
      invoiceNumber: ['', [Validators.required, Validators.minLength(3)]],
      productCode: ['', [Validators.required, Validators.minLength(3)]],
      name: [''],
      quantity: ['', [Validators.required, Validators.min(1)]]
    });
    }
    getProduct() {
        const productCode = this.productForm.get('productCode')?.value;
        if (productCode) {
            this.productService.getProductInfo(productCode).subscribe((data:any) => {
              debugger;
                this.productInfo = data.result;
              
            });
        }
    }
 toggleFieldsBasedOnVendor(vendorName: string): void {
    const productCodeControl = this.productForm.get('toLocation');
    const quantityControl = this.productForm.get('quantity');

    if (vendorName && vendorName.trim().length > 0) {
      // Enable fields when vendor is provided
      productCodeControl?.enable();
      quantityControl?.enable();
    } else {
      // Disable and reset fields when vendor is empty
      productCodeControl?.disable();
      productCodeControl?.setValue('');
      quantityControl?.disable();
      quantityControl?.setValue('');
    }
  }
    onClear(): void {
    this.productForm.reset();
    // Re-disable fields after reset
    this.toggleFieldsBasedOnVendor('');
  }

  onSaveProduct(): void {
    debugger
    if (this.productForm.valid) {
   this.productForm.value.name=this.productInfo?.name;
   this.productForm.value.saleprice=this.productInfo?.price;
      this.productForm.value.productCode=this.productInfo?.productCode;
      this.productForm.value.productId=this.productInfo?.id;
      this.productpurchase.push(this.productForm.value);
 
      // Add your save logic here
    } else {
      console.log('Form is invalid');
      this.markFormGroupTouched();
    }
  }
sumQuantities(): number {
  return this.productpurchase.reduce((acc, x) => acc + x.quantity, 0);
}

transferStock() {
  debugger
  var data:any[]=[];
  this.productpurchase.forEach((item:any) => {
    data.push({
      productId: item.productId,
      quantity: item.quantity,
      FromLocationId: this.fromLocation?.value,
      ToLocationId: this.toLocation?.value,
      saleprice: item.saleprice,
      purchasePrice: item.purchasePrice,
      InvoiceNumber: this.invoiceNumber?.value,
    });
  });
debugger
this.productService.transferStock(data).subscribe({
      next: (res:any) => {
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Purchase saved successfully!' });
        this.productpurchase = [];
        this.productForm.reset();
        this.onClear();
      },
      error: (err:any) => {
        console.error('Error saving purchase:', err);
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Failed to save purchase.' });
      }
  });

 
  
}
sumTotal(): number {
  return this.productpurchase.reduce((acc, x) => acc + x.saleprice, 0);
}
  private markFormGroupTouched(): void {
    Object.keys(this.productForm.controls).forEach(key => {
      const control = this.productForm.get(key);
      control?.markAsTouched();
    });
  }

  // Getter methods for easy access in template
  get vendorName() { return this.productForm.get('vendorName'); }
  get toLocation() { return this.productForm.get('toLocation'); }
  get fromLocation() { return this.productForm.get('fromLocation'); }
  get purchaseDate() { return this.productForm.get('purchaseDate'); }
  get invoiceNumber() { return this.productForm.get('invoiceNumber'); }
  get productCode() { return this.productForm.get('productCode'); }
  get quantity() { return this.productForm.get('quantity'); }
  get purchasePrice() { return this.productForm.get('purchasePrice'); }

  // Helper method to check if save button should be disabled
  get isSaveDisabled(): boolean {
    return !this.toLocation?.value || !this.productForm.valid;
  }

  // Helper method to check if product fields should be disabled
  get isProductFieldsDisabled(): boolean {
    return !this.vendorName?.value || this.vendorName?.value.trim().length === 0;
  }
    onCategoryChange(event: any) {
        debugger
        if (event.value) {
            this.categoryService.getsubcategoriesbyParentId(event.value).subscribe((data:any) => {
                this.subcategories=data.result;
            });
        } else {
            this.subcategories=[];
        }
    }
    loadDemoData() {
        this.productService.getAllProducts().subscribe((data) => {
            debugger
            this.products.set(data.result);
        });
        this.locationsService.getallLocations().subscribe((data) => {
            debugger
            this.allLocations=data.result;
        });
  this.categoryService.getAllCategories().subscribe((data:any) => {
    debugger;
            this.allCategories=data.result;
        });
        this.statuses = [
            { label: 'INSTOCK', value: 'instock' },
            { label: 'LOWSTOCK', value: 'lowstock' },
            { label: 'OUTOFSTOCK', value: 'outofstock' }
        ];

        this.cols = [
            { field: 'code', header: 'Code', customExportHeader: 'Product Code' },
            { field: 'name', header: 'Name' },
            { field: 'image', header: 'Image' },
            { field: 'price', header: 'Price' },
            { field: 'category', header: 'Category' }
        ];

        this.exportColumns = this.cols.map((col) => ({ title: col.header, dataKey: col.field }));
    }

    onGlobalFilter(table: Table, event: Event) {
        table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
    }

    openNew() {
        this.product = {};
        this.submitted = false;
        this.productDialog = true;
    }

    editProduct(product: Product) {
        this.product = { ...product };
        this.productDialog = true;
    }

    deleteSelectedProducts() {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete the selected products?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.products.set(this.products().filter((val) => !this.selectedProducts?.includes(val)));
                this.selectedProducts = null;
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Products Deleted',
                    life: 3000
                });
            }
        });
    }

    hideDialog() {
        this.productDialog = false;
        this.submitted = false;
    }

    deleteProduct(product: Product) {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete ' + product.name + '?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.products.set(this.products().filter((val) => val.id !== product.id));
                this.product = {};
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Product Deleted',
                    life: 3000
                });
            }
        });
    }

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.products().length; i++) {
            if (this.products()[i].id === id) {
                index = i;
                break;
            }
        }

        return index;
    }

    createId(): string {
        let id = '';
        var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        for (var i = 0; i < 5; i++) {
            id += chars.charAt(Math.floor(Math.random() * chars.length));
        }
        return id;
    }

    getSeverity(status: boolean) {
      return status ? 'success' : 'danger';
    }

    saveProduct() {
        debugger
        this.submitted = true;
        let _products = this.products();

  const formData = new FormData();

  formData.append('ProductCode', this.product.code || '');
  formData.append('Name', this.product.name || '');
  formData.append('Description', this.product.description || '');
  formData.append('Price', this.product.price?.toString() || '0');
  formData.append('Unit', this.product.quantity?.toString() || '0');
  formData.append('Barcode', '');
  formData.append('IsActive',  'true' );
  formData.append('CategoryId', this.product.inventoryCategory || '');

  this.uploadedFiles?.forEach((img, i) => {
    formData.append(`ProductImages[${i}].ImageUrl`, img);
    formData.append(`ProductImages[${i}].AltText`, 'Image ' + (i + 1));
    formData.append(`ProductImages[${i}].DisplayOrder`, i.toString());
    formData.append(`ProductImages[${i}].IsPrimary`, i === 0 ? 'true' : 'false');
  });

    this.productService.save(formData).subscribe({
                next: (res:any) => console.log('Uploaded', res),
                error: (err:any) => console.error('Error uploading', err),  
            });
        
        if (this.product.name?.trim()) {
            if (this.product.id) {
                _products[this.findIndexById(this.product.id)] = this.product;
                this.products.set([..._products]);
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Product Updated',
                    life: 3000
                });
            } else {
                this.product.id = this.createId();
                this.product.image = 'product-placeholder.svg';
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Product Created',
                    life: 3000
                });
                this.products.set([..._products, this.product]);
            }

            this.productDialog = false;
        
            this.product = {};
        }
    }
}
