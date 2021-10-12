import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

    
@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements OnInit {

  constructor(private service:SharedService) { }

  
  UserList:any=[];
  modalTitle:string="";
  ActivateAddEdit:boolean=false;
  user:any;

  UsersNameFilter:string="";
  UsersStatusFilter:string="";
  UserListWithoutFilter:any=[];
  
  ngOnInit(): void {
    this.refreshUserList();
    
  }

  addClick(){
    this.user={
      UsuarioId:0,
      Nome:"",
      DataNascimento:"",
      Email:"",
      Senha:"",
      Ativo:"",
      SexoId:""

    }
    this.modalTitle = "Adicionar Usuário";
    this.ActivateAddEdit=true;
  }

  editClick(item: any){
    this.user=item;
    this.modalTitle = "Editar Usuário";
    this.ActivateAddEdit=true;
  
  }

  deleteClick(item:any){
    if(confirm("Confirmar Deletar")){
      this.service.deleteUser(item).subscribe(data=>{
        alert(data.toString());
        this.refreshUserList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEdit=false;
    this.refreshUserList();
  }

  refreshUserList(){
    this.service.getUser().subscribe(data=>{
      this.UserList=data;
      this.UserListWithoutFilter=data;
    })
  }

  filterFunction(){
    var UsersNameFilter = this.UsersNameFilter;
    var UsersStatusFilter = this.UsersStatusFilter;

    this.UserList = this.UserListWithoutFilter.filter(function (el: { Nome: { toString: () => string; }; Ativo: { toString: () => string; }; }){
      return el.Nome.toString().toLowerCase().includes(
        UsersNameFilter.toString().trim().toLowerCase()
        )&&
        el.Ativo.toString().toLowerCase().includes(
          UsersStatusFilter.toString().toLowerCase()
        )
      
    });
  }

 

}
