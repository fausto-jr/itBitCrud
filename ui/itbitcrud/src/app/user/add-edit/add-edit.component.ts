import { Component, OnInit, Input,  } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SharedService } from 'src/app/shared.service';


@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css']
})
export class AddEditComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() user:any;
  UsuarioId:string="";
  Nome:string="";
  DataNascimento:string="";
  Email:string="";
  Senha:string="";
  Ativo:boolean=false;
  SexoId:string="";

  SexoList:any=[];

 

  ngOnInit(): void {
    this.loadSexo();

  }

  
  loadSexo(){
    this.service.getSexo().subscribe((data:any)=>{
      this.SexoList = data;
      this.UsuarioId = this.user.UsuarioId;
      this.Nome = this.user.Nome;
      this.DataNascimento = this.user.DataNascimento;
      this.Email = this.user.Email;
      this.Senha = this.user.Senha;
      this.Ativo = this.user.Ativo;
      this.SexoId = this.user.SexoId;
    })

  }

    form = new FormGroup({

    Nome: new FormControl('', [Validators.required, Validators.minLength(3)]),

    Email: new FormControl('', [Validators.required, Validators.email]),

    DataNascimento: new FormControl('', Validators.required),

    Senha: new FormControl('', [Validators.required, Validators.minLength(6)]),

    Ativo: new FormControl('', Validators.required),

    SexoId: new FormControl('', Validators.required)

  });
  get f(){

    return this.form.controls;

  }
  addUser(){
    var val = {
      UsuarioId:this.UsuarioId,
      Nome:this.Nome,
      DataNascimento:this.DataNascimento,
      Email:this.Email,
      Senha:this.Senha,
      Ativo:this.Ativo,
      SexoId:this.SexoId,
    };
    console.log(val);
   
    this.service.addUser(val).subscribe(res=>{
      alert(res.toString());
    });
    
  }

  updateUser(){
    var val = {
      UsuarioId:this.UsuarioId,
      Nome:this.Nome,
      DataNascimento:this.DataNascimento,
      Email:this.Email,
      Senha:this.Senha,
      Ativo:this.Ativo,
      SexoId:this.SexoId

    };
    this.service.updateUser(val).subscribe(res=>{
      alert(res.toString());
    });
  }


}
