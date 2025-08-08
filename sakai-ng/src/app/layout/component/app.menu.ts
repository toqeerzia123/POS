import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { AppMenuitem } from './app.menuitem';

@Component({
    selector: 'app-menu',
    standalone: true,
    imports: [CommonModule, AppMenuitem, RouterModule],
    template: `<ul class="layout-menu">
        <ng-container *ngFor="let item of model; let i = index">
            <li app-menuitem *ngIf="!item.separator" [item]="item" [index]="i" [root]="true"></li>
            <li *ngIf="item.separator" class="menu-separator"></li>
        </ng-container>
    </ul> `
})
export class AppMenu {
    model: MenuItem[] = [];

    ngOnInit() {
      this.model = [
    {
        label: 'Home',
        items: [{ label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] }]
    },            
    {
        label: 'POS Management',
        icon: 'pi pi-fw pi-credit-card',
        routerLink: ['/pages'],
        items: [
            {
                label: 'locations',
                icon: 'pi pi-fw pi-map-marker',
                routerLink: ['/pages/locations']
            },
            {
                label: 'settings',
                icon: 'pi pi-fw pi-cog',
                routerLink: ['/pages/pos-settings']
            },
        ]
    },
    {
        label: 'Inventory Management',
        icon: 'pi pi-fw pi-box',
        routerLink: ['/pages'],
        items: [
            {
                label: 'stock',
                icon: 'pi pi-fw pi-chart-bar',
                routerLink: ['/landing']
            },
        ]
    },
    {
        label: 'Purchase Management',
        icon: 'pi pi-fw pi-shopping-cart',
        routerLink: ['/pages'],
        items: [
          
            {
                label: 'Transfer Products',
                icon: 'pi pi-fw pi-send',
                routerLink: ['/pages/transfer-stock']
            },
            {
                label: 'Purchase History',
                icon: 'pi pi-fw pi-history',
                routerLink: ['/pages/purchase-stock']
            },
        ]
    },
    {
        label: 'Sales Management',
        icon: 'pi pi-fw pi-chart-line',
        routerLink: ['/pages'],
        items: [
            {
                label: 'sales History',
                icon: 'pi pi-fw pi-list',
                routerLink: ['/landing']
            },
            {
                label: 'Return Products',
                icon: 'pi pi-fw pi-undo',
                routerLink: ['/landing']
            },
        ]
    },
    {
        label: 'Product Management',
        icon: 'pi pi-fw pi-tags',
        routerLink: ['/pages'],
        items: [
            {
                label: 'Products',
                icon: 'pi pi-fw pi-th-large',
                routerLink: ['/pages/products']
            },
            {
                label: 'Categories',
                icon: 'pi pi-fw pi-sitemap',
                routerLink: ['/pages/categories']
            },
            {
                label: 'Barcodes',
                icon: 'pi pi-fw pi-qrcode',
                routerLink: ['/pages/barcode']
            },
        ]
    },
    {
        label: 'Clients Management',
        icon: 'pi pi-fw pi-users',
        routerLink: ['/pages'],
        items: [
            {
                label: 'Clients',
                icon: 'pi pi-fw pi-user',
                routerLink: ['/pages/clients']
            },
            {
                label: 'Client Ledger',
                icon: 'pi pi-fw pi-book',
                routerLink: ['/pages/client-ledger']
            },
        ]
    },
    {
        label: 'Vendors Management',
        icon: 'pi pi-fw pi-building',
        routerLink: ['/pages'],
        items: [
            {
                label: 'Vendors',
                icon: 'pi pi-fw pi-briefcase',
                routerLink: ['/pages/vendors']
            },
            {
                label: 'Vendor Ledger',
                icon: 'pi pi-fw pi-calendar',
                routerLink: ['/pages/vendor-ledger']
            },
        ]
    },
];
    }
}
