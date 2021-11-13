import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario.model';
import { TemplateServiceService } from 'src/app/services/template-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  formaUsuario: FormGroup;

  constructor(private fb: FormBuilder, private service:TemplateServiceService,private router: Router,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.crearFormularioUsuario();
  }

  crearFormularioUsuario(){
    this.formaUsuario = this.fb.group({
      UsuNombre : ['', Validators.required],
      UsuPass: ['', Validators.required]
    });
  }

  get NombreNoValido(){
    return this.formaUsuario.get('UsuNombre').invalid && this.formaUsuario.get('UsuNombre').touched;
  }
   
  get PassNoValido(){
    return this.formaUsuario.get('UsuPass').invalid && this.formaUsuario.get('UsuPass').touched;
  }

  CrearUsuario(){    
    const dataUsuario = new Usuario();
    dataUsuario.UsuNombre = this.formaUsuario.value.UsuNombre;
    dataUsuario.UsuPass = this.formaUsuario.value.UsuPass;
    this.service.CrearUsuario(dataUsuario).subscribe((resp:any) =>{
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
          text: 'Ocurrio un error al crear usuario',
          confirmButtonColor: '#f53201'
        });
      }    
    });
    
  }

}
