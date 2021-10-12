import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "http://localhost:62950/api"
  
  constructor(private http:HttpClient) { }

  getUser():Observable<any[]>
  {
    return this.http.get<any>(this.APIUrl+'/user');
  }

  addUser(val:any)
  {
    return this.http.post<any>(this.APIUrl+'/user',val);
  }

  updateUser(val:any)
  {
    return this.http.put<any>(this.APIUrl+'/user',val);
  }

  deleteUser(val:any)
  {
    return this.http.delete<any>(this.APIUrl+'/user/'+val);
  }

  getSexo():Observable<any[]>
  {
    return this.http.get<any>(this.APIUrl+'/sex');
  }
  getSexoSingle(val:any)
  {
    return this.http.get<any>(this.APIUrl+'/sex/'+val);
  }

}
