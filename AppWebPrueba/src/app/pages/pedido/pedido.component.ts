import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PedidoModel } from 'src/app/models/pedido.model';
import { ProductoModel } from 'src/app/models/producto.model';
import { Usuario } from 'src/app/models/usuario.model';
import { TemplateServiceService } from 'src/app/services/template-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.css']
})
export class PedidoComponent implements OnInit {

  formaPedido: FormGroup;
  usuarios:Usuario[] = [];
  productos:ProductoModel[] = [];
  pedidos:PedidoModel[] = [];
  valor:number;
  constructor(private fb: FormBuilder, private service:TemplateServiceService,private router: Router,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.crearFormularioUsuario();
    this.ConsultarUsuarios();
    this.ConsultarProductos();
    this.ConsultarPedidos();
  }
  
  crearFormularioUsuario(){
    this.formaPedido = this.fb.group({
      PedUsu : ['', Validators.required],
      PedProdID: ['', Validators.required],
      PedVrUnit: ['', Validators.required],
      PedCant: ['', Validators.required]
    });
  }

  get PedUsuNoValido(){
    return this.formaPedido.get('PedUsu').invalid && this.formaPedido.get('PedUsu').touched;
  }
   
  get PedProdIDNoValido(){
    return this.formaPedido.get('PedProdID').invalid && this.formaPedido.get('PedProdID').touched;
  }
  get PedVrUnitNoValido(){
    return this.formaPedido.get('PedVrUnit').invalid && this.formaPedido.get('PedVrUnit').touched;
  }
   
  get PedCantNoValido(){
    return this.formaPedido.get('PedCant').invalid && this.formaPedido.get('PedCant').touched;
  }

  CrearPedido(){    
    const dataPedido = new PedidoModel();
    dataPedido.PedUsu = this.formaPedido.value.PedUsu;
    dataPedido.PedProdID = this.formaPedido.value.PedProdID;
    dataPedido.PedVrUnit = this.valor;
    dataPedido.PedCant = this.formaPedido.value.PedCant;
    this.service.CrearPedido(dataPedido).subscribe((resp:any) =>{
      if(resp){
        Swal.fire({
          icon: 'success',
          title: 'Exitoso',
          text: 'Proceso realizado con exito',
          confirmButtonColor: '#f53201'
        }).then((result) => {
          if (result.isConfirmed) {
            window.location.reload();            
          }
        });
      }else{
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Ocurrio un error al crear pedido',
          confirmButtonColor: '#f53201'
        });
      }    
    });
    
  }

  ConsultarUsuarios(){
    this.service.ConsultarUsuarios().subscribe((resp:Usuario[]) =>{
       this.usuarios = resp;       
    });
  }

  ConsultarProductos(){
    this.service.ConsultarProductos().subscribe((resp:ProductoModel[]) =>{
       this.productos = resp;
    });
  }

  ConsultarPedidos(){
    this.service.ConsultarPedido().subscribe((resp:PedidoModel[]) =>{
       this.pedidos = resp;
       console.log(this.pedidos);
       
    });
  }

  asignarValor(){    
    var product = this.productos.find(x => x.proID === this.formaPedido.value.PedProdID);
    this.formaPedido.value.PedVrUnit =  product.proValor;
    (document.getElementById('PedVrUnit') as HTMLInputElement).value = product.proValor.toString(); 
    this.valor = product.proValor;
  }

}
