import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Department} from 'src/app/models/department-model';
import {Observable} from 'rxjs';

import {Subject} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor( private http:HttpClient) { }

  formData: Department;

  readonly APIUrl = "http://localhost:19325/api";

  getDepList(): Observable<Department[]> {
    return this.http.get<Department[]>(this.APIUrl + '/department');
  }

  addDepartment(dept:Department){
    dept.isActive = true;
    return this.http.post(this.APIUrl+'/department/CreateDepartment', dept);
  }

  deleteDepartment(deptId: number){
    return this.http.delete(this.APIUrl+'/department/'+deptId);
  }

  updateDepartment(dept:Department) {
    return this.http.put(this.APIUrl+'/Department/UpdateDepartment',dept);
  }


  private _listners = new Subject<any>();
  listen(): Observable<any>{
    return this._listners.asObservable();
  }
  filter(filterBy: string){
    this._listners.next(filterBy);
  }
}
