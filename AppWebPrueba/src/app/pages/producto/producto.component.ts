import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductoModel } from 'src/app/models/producto.model';
import { TemplateServiceService } from 'src/app/services/template-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {

  formaProducto: FormGroup;

  constructor(private fb: FormBuilder, private service:TemplateServiceService,private router: Router,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.crearFormularioUsuario();
  }

  crearFormularioUsuario(){
    this.formaProducto = this.fb.group({
      ProDesc : ['', Validators.required],
      ProValor: ['', Validators.required]
    });
  }

  get ProDescNoValido(){
    return this.formaProducto.get('ProDesc').invalid && this.formaProducto.get('ProDesc').touched;
  }
   
  get ProValorNoValido(){
    return this.formaProducto.get('ProValor').invalid && this.formaProducto.get('ProValor').touched;
  }

  CrearProducto(){    
    const dataUsuario = new ProductoModel();
    dataUsuario.proDesc = this.formaProducto.value.ProDesc;
    dataUsuario.proValor = this.formaProducto.value.ProValor;
    this.service.CrearProducto(dataUsuario).subscribe((resp:any) =>{
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
          text: 'Ocurrio un error al crear producto',
          confirmButtonColor: '#f53201'
        });
      }    
    });
    
  }

}
