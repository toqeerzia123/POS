import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TreeModule } from 'primeng/tree';
import { TreeTableModule } from 'primeng/treetable';
import { TreeNode } from 'primeng/api';
import { BarcodeService } from '../service/barcode.service';
import { ButtonModule } from 'primeng/button';
import { ButtonGroupModule } from 'primeng/buttongroup';
import { SplitButtonModule } from 'primeng/splitbutton';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-barcode',
     standalone: true,
  templateUrl: './barcode.component.html',
  styleUrls: ['./barcode.component.css'],
      imports: [CommonModule, FormsModule, TreeTableModule,ButtonModule, ButtonGroupModule, SplitButtonModule,
           DialogModule,
    InputTextModule,
      ],
         providers: [BarcodeService]
})
export class BarcodeComponent implements OnInit {

 treeValue: TreeNode[] = [];

    treeTableValue: TreeNode[] = [];

    selectedTreeValue: TreeNode[] = [];

    selectedTreeTableValue = {};

    cols: any[] = [];

    barcodeService = inject(BarcodeService);
  barcodeSvg!: string;

    ngOnInit() {
    this.cols = [
    { field: 'barcode', header: 'Barcode' },
    { field: 'option', header: 'Options' },
];
this.barcodeService.getBarcodeData().subscribe((data: any) => {
  debugger
      this.treeTableValue = this.transformToTreeNode(data.result);
        });
 

        this.selectedTreeTableValue = {
            '0-0': {
                partialChecked: false,
                checked: true
            }
        };
    }
transformToTreeNode(data: any[]): TreeNode[] {
  return data.map(item => ({
    key: item.key,
    label: item.label,
    data: item.data,
    children: item.children ? this.transformToTreeNode(item.children) : undefined // not null
  }));
}
onView(row: any) {
  console.log('View clicked:', row);
  // TODO: Open modal or navigate
}
barcodeBase64: string | null = null;
onPrint(row: any) {
  this.barcodeDialogVisible = true;
this.barcodeService.generateBarcode('t-shirt', '16444848464554654', 1500).subscribe({
      next: (res:any) => {
        debugger
        this.barcodeBase64 =`data:image/png;base64,${res.result}`
      },
      error: (err) => {
        console.error('Failed to generate barcode:', err);
      }
    });
  // TODO: Trigger print logic
}
onAddNewBarcode(parentNode: any) {
  console.log('Add New Barcode for:', parentNode);
  // Implement logic to add a new barcode under this node
}
  newBarcodeValue:number=0;
  barcodes: any[] = [];
barcodeDialogVisible = false;
submitted = false;

barcodeForm: any = {
  BarcodeValue: '',
  ProductId: null,
  BarcodeType: ''
};

productList = [
  { id: 'some-guid-1', name: 'Product 1' },
  { id: 'some-guid-2', name: 'Product 2' }
];

barcodeTypes = [
  { label: 'QR', value: 'QR' },
  { label: 'EAN', value: 'EAN' },
  { label: 'UPC', value: 'UPC' }
];

hideDialog() {
  this.barcodeDialogVisible = false;
  this.submitted = false;
  this.resetForm();
}
  chunkedBarcodes: string[][] = [];
addbarcode() {
  this.barcodes = [];
  this.barcodeDialogVisible = true;
  for (let i = 0; i < this.newBarcodeValue; i++) {
   
  this.barcodes.push(this.barcodeBase64);
  }
    this.chunkBarcodes()
}

private chunkBarcodes(): void {
  this.chunkedBarcodes = [];
  for (let i = 0; i < this.barcodes.length; i += 2) {
    this.chunkedBarcodes.push(this.barcodes.slice(i, i + 2));
  }
}
saveBarcode() {
  this.submitted = true;
}
resetForm() {
  this.barcodeForm = {
    BarcodeValue: '',
    ProductId: null,
    BarcodeType: ''
  };
}


}
