import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientRoutes } from './client.routing';
import { AllClientsComponent } from './all-clients/all-clients.component';


@NgModule({
  imports: [
    CommonModule,
    ClientRoutes
  ],
  declarations: [AllClientsComponent]
})
export class ClientsModule { }
