import { Component, OnInit } from '@angular/core';
import {MatDialogRef} from '@angular/material';
import { EmployeeService } from 'src/app/services/employee.service';
import { NgForm } from '@angular/forms';
import {MatSnackBar} from '@angular/material';

@Component({
  selector: 'app-edit-emp',
  templateUrl: './edit-emp.component.html',
  styleUrls: ['./edit-emp.component.css']
})
export class EditEmpComponent implements OnInit {

departments: any = [];
departmentData : any;
departid: number;
g:any;
gvalue:any;
genMale:boolean;
genFemale:boolean;
male="male";
female="female";

  constructor(public dialogbox: MatDialogRef<EditEmpComponent>,
    private service:EmployeeService,
    private snackBar:MatSnackBar) { }

    
public listItems: Array<string> = [];
public listItems1: Array<string> = [];
model = { options: 'male' };
minDate = new Date(1921,1,1);
maxDate = new Date();

  ngOnInit() {
    if(this.service.formData.gender != undefined)
    {
    if(this.service.formData.gender.trim().toString().toLowerCase()=='male'){
      this.genMale = true;
      this.genFemale = false;
    }
    else{
      this.genMale = false;
      this.genFemale = true;
    }
  }
    this.dropdownRefresh();
  }

  dropdownRefresh() {
    this.service.getDepDropDownValues().subscribe(data => {
      data.forEach(element => {
        this.departmentData = {
          deptId:element["deptId"],
          deptName:element["deptName"]
        }
        this.departments.push(this.departmentData);
      });
    });
  }

  onClose(){
    this.dialogbox.close();
    this.service.filter('Register click');
  }

  genderSave($event){
    let x = event.target['value'];
    this.g = x;
    this.service.formData.gender = x;
  }

  onSubmit(form:NgForm){
    form.value.gender = this.service.formData.gender.toString().trim();
    form.value.deptId = this.service.formData.deptId;
    form.value.deptName = this.service.formData.deptName;
    this.service.updateEmployee(form.value).subscribe(res=>{
      this.snackBar.open('Employee Details','Updated Successfully',{
        duration:5000,
        verticalPosition:'top'
      })
      this.onClose();
    })
  }
  onChange(x){
    this.departid = x;
    this.service.formData.deptId=x;
      }
}