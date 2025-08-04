import { Routes, RouterModule } from '@angular/router';
import { AllClientsComponent } from './all-clients/all-clients.component';

const routes: Routes = [
 {
    path: '',
    component: AllClientsComponent
  }
];

export const ClientRoutes = RouterModule.forChild(routes);
