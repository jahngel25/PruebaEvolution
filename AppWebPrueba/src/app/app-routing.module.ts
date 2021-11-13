import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { PagesComponent } from './pages/pages.component';
import { ProductoComponent } from './pages/producto/producto.component';
import { UsuarioComponent } from './pages/usuario/usuario.component';
import { PedidoComponent } from './pages/pedido/pedido.component';

const routes: Routes = [
  {
    path: '',
    component: PagesComponent,      
    children: [
      {path: 'producto', component: ProductoComponent},  
      {path: 'pedido', component: PedidoComponent},  
      {path: 'usuario', component: UsuarioComponent}
    ]
  },
    
  {path: '', pathMatch: 'full', redirectTo: '/inicio'},
  {path: '**', pathMatch: 'full', redirectTo: '/inicio'}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes, { useHash: true })
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
