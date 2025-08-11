import { Routes } from '@angular/router';
import { Documentation } from './documentation/documentation';
import { Crud } from './crud/crud';
import { Empty } from './empty/empty';
import { VendorComponent } from './vendor/vendor.component';
import { VendorLedgerComponent } from './vendor-ledger/vendor-ledger.component';
import { UserComponent } from './user/user.component';
import { RoleComponent } from './role/role.component';
import { ProductsComponent } from './products/products.component';
import { PosSettingComponent } from './pos-setting/pos-setting.component';
import { PermissionComponent } from './permission/permission.component';
import { LocationComponent } from './location/location.component';
import { InventoryComponent } from './inventory/inventory.component';
import { ClientsComponent } from './clients/clients.component';
import { ClientLedgerComponent } from './client-ledger/client-ledger.component';
import { CategoriesComponent } from './categories/categories.component';
import { BarcodeComponent } from './barcode/barcode.component';
import { TransferProductComponent } from './transfer-product/transfer-product.component';
import { PurchaseProductComponent } from './purchase-product/purchase-product.component';
import { ReceiveStockComponent } from './receive-stock/receive-stock.component';
import { POSScreenComponent } from './POS-screen/POS-screen.component';

export default [
    { path: 'documentation', component: Documentation },
    { path: 'crud', component: Crud },
    { path: 'empty', component: Empty },
    { path: 'vendors', component: VendorComponent },
    { path: 'vendor-ledger', component: VendorLedgerComponent },
    { path: 'users', component: UserComponent },
    { path: 'roles', component: RoleComponent },
    { path: 'products', component: ProductsComponent },
    { path: 'pos-settings', component: PosSettingComponent },
    { path: 'permissions', component: PermissionComponent },
    { path: 'locations', component: LocationComponent },
    { path: 'inventory', component: InventoryComponent },
    { path: 'clients', component: ClientsComponent },
    { path: 'client-ledger', component: ClientLedgerComponent },
    { path: 'categories', component: CategoriesComponent },
    { path: 'barcode', component: BarcodeComponent },
    { path: 'purchase-stock', component: PurchaseProductComponent },
    { path: 'transfer-stock', component: TransferProductComponent },
    { path: 'receive-stock', component: ReceiveStockComponent },
    { path: 'pos', component: POSScreenComponent },

    { path: '**', redirectTo: '/notfound' }
] as Routes;
