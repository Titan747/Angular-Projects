import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './employee/employee.component';
import { DepartmentComponent } from './department/department.component';
import { DeletedemployeesComponent } from './deletedemployees/deletedemployees.component';

const routes: Routes = [
  {path:'employee', component:EmployeeComponent},
  {path:'department', component:DepartmentComponent},
  {path:'deletedemployees', component:DeletedemployeesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
