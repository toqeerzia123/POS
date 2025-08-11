import { Component, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

interface Product {
  id: string;
  name: string;
  size: string;
  color: string;
  price: number;
}

interface CartItem extends Product {
  qty: number;
}

@Component({
  selector: 'app-POS-screen',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './POS-screen.component.html',
  styleUrls: ['./POS-screen.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class POSScreenComponent {
  receivedAmount: number = 0;
  products: Product[] = [
    { id: 'CLO-001', name: 'Men Shirt', size: 'M', color: 'Blue', price: 25.00 },
    { id: 'CLO-002', name: 'Women Dress', size: 'L', color: 'Red', price: 40.00 },
    { id: 'CLO-003', name: 'Jeans', size: '32', color: 'Black', price: 35.00 },
    { id: 'CLO-004', name: 'Hoodie', size: 'XL', color: 'Gray', price: 50.00 },
    { id: 'CLO-005', name: 'Skirt', size: 'S', color: 'Pink', price: 30.00 },
    { id: 'CLO-006', name: 'Skirt', size: 'S', color: 'Pink', price: 30.00 },
    { id: 'CLO-007', name: 'Skirt', size: 'S', color: 'Pink', price: 30.00 },
    { id: 'CLO-008', name: 'Skirt', size: 'S', color: 'Pink', price: 30.00 },
    { id: 'CLO-009', name: 'Skirt', size: 'S', color: 'Pink', price: 30.00 },
    { id: 'CLO-010', name: 'Skirt', size: 'S', color: 'Pink', price: 30.00 },
    { id: 'CLO-011', name: 'Skirt', size: 'S', color: 'Pink', price: 30.00 },
    { id: 'CLO-012', name: 'Skirt', size: 'S', color: 'Pink', price: 30.00 },
    { id: 'CLO-013', name: 'Skirt', size: 'S', color: 'Pink', price: 30.00 },
    { id: 'CLO-014', name: 'Skirt', size: 'S', color: 'Pink', price: 30.00 },
  ];
userName: string = 'Toqeer Yousaf';
  cart: CartItem[] = [
    { id: 'CLO-001', name: 'Men Shirt Men Shirt Men Shirt Men Shirt Men Shirt Men Shirt', size: 'M', color: 'Blue', price: 25.00, qty: 2 },
    { id: 'CLO-003', name: 'Jeans', size: '32', color: 'Black', price: 35.00, qty: 1 }
  ];

  barcode: string = '';
  customerName: string = '';
  customerPhone: string = '';
  discountValue: number = 0;
  discountType: 'value' | 'percent' = 'value';
  paymentType: 'cash' | 'card' | 'upi' = 'cash';

  currentDateTime: string = '';

  constructor() {
    this.updateDateTime();
    setInterval(() => this.updateDateTime(), 1000);
  }

  updateDateTime() {
    this.currentDateTime = new Date().toLocaleString();
  }

  get totalQty(): number {
    return this.cart.reduce((sum, item) => sum + item.qty, 0);
  }

  get totalAmount(): number {
    return this.cart.reduce((sum, item) => sum + (item.price * item.qty), 0);
  }

  get discountAmount(): number {
    if (this.discountType === 'percent') {
      return (this.totalAmount * this.discountValue) / 100;
    }
    return this.discountValue;
  }

  addProductByBarcode() {
    if (!this.barcode) return;
    const product = this.products.find(p => p.id === this.barcode.trim());
    if (product) {
      const existing = this.cart.find(c => c.id === product.id);
      if (existing) {
        existing.qty++;
      } else {
        this.cart.push({ ...product, qty: 1 });
      }
    } else {
      alert('Product not found');
    }
    this.barcode = '';
  }

  updateQty(item: CartItem, qty: number) {
    item.qty = qty > 0 ? qty : 1;
  }

  removeItem(index: number) {
    this.cart.splice(index, 1);
  }

  checkout() {
    if (this.cart.length === 0) {
      alert('Cart is empty');
      return;
    }
    alert(`Processing payment for ${this.customerName} (${this.customerPhone}), Payment Type: ${this.paymentType}`);
  }

printReceipt() {
  const printContents = document.getElementById('invoice')?.innerHTML;
  if (!printContents) {
    alert('No invoice to print');
    return;
  }
  const popupWin = window.open('', '_blank', 'width=300,height=600');
  if (!popupWin) return;

  popupWin.document.open();
  popupWin.document.write(`
    <html>
      <head>
        <title>Invoice Print</title>
        <style>
          /* Narrow receipt size approx 80mm paper */
          body {
            font-family: monospace;
            font-size: 12px;
            width: 80mm;
            margin: 0;
            padding: 10px;
            background: white;
            color: black;
          }
          /* Remove margins/padding on print */
          @media print {
            body {
              margin: 0;
              padding: 0;
            }
          }
        </style>
      </head>
      <body onload="window.print(); window.close();">
        ${printContents}
      </body>
    </html>
  `);
  popupWin.document.close();
}

}
