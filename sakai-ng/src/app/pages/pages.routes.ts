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

    { path: '**', redirectTo: '/notfound' }
] as Routes;
