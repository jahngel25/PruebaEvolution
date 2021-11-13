import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Usuario } from '../models/usuario.model';
import { ProductoModel } from '../models/producto.model';
import { PedidoModel } from '../models/pedido.model';

@Injectable({
  providedIn: 'root'
})
export class TemplateServiceService {

  constructor(private http: HttpClient, private router: Router) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
    

  CrearUsuario(model:Usuario){
    return this.http.post(`/api/Usuario`, model,this.httpOptions);
  }

  CrearProducto(model:ProductoModel){
    return this.http.post(`/api/Producto`, model,this.httpOptions);
  }

  CrearPedido(model:PedidoModel){
    console.log(model);
    
    return this.http.post(`/api/Pedido`, model,this.httpOptions);
  }
  
  ConsultarProductos(){
    return this.http.get(`/api/Producto`,this.httpOptions);
  }

  ConsultarUsuarios(){
    return this.http.get(`/api/Usuario`,this.httpOptions);
  }

  ConsultarPedido(){
    return this.http.get(`/api/Pedido`, this.httpOptions);
  }
}
