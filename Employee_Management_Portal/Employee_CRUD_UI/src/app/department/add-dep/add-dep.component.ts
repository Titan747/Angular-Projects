import { Component, OnInit, ViewChild } from '@angular/core';
import {MatDialogRef, MatSort, MatTableDataSource} from '@angular/material';
import { DepartmentService } from 'src/app/services/department.service';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import {MatSnackBar} from '@angular/material';

@Component({
  selector: 'app-add-dep',
  templateUrl: './add-dep.component.html',
  styleUrls: ['./add-dep.component.css']
})
export class AddDepComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;
  constructor(public dialogbox: MatDialogRef<AddDepComponent>,
    public service:DepartmentService,
    public snackBar:MatSnackBar,private formBuilder: FormBuilder) { }
    listData : MatTableDataSource<any>;
    displayedColumns : string[] = ['DepartmentID', 'DepartmentName','Options']
    @ViewChild(MatSort, null) sort: MatSort;
    
  ngOnInit() {
this.resetForm();
this.refreshDepList();
this.registerForm = this.formBuilder.group({
  deptName: ['',[Validators.required]]
});
}
  refreshDepList(){
    this.service.getDepList().subscribe(data => {
      this.listData  = new MatTableDataSource(data);
      this.listData.sort = this.sort;
    });
  }
  resetForm(form?:NgForm){
    if(form!=null)
    form.resetForm();
    this.service.formData = {
      deptId:0,
      deptName:'',
      isActive:true
    }
  }

  get f() { return this.registerForm.controls; }
  
  onClose(){
    this.dialogbox.close();
    this.service.filter('Register click');
  }

  onSubmit(form:NgForm){ 
    this.submitted = true;
    if(form.value.deptName == null || form.value.deptName == ''){
      return false;
    }
    this.service.addDepartment(form.value).subscribe(res=>
      {
        this.resetForm(form);
        this.snackBar.open('Department', 'Added Successfully', {
          duration:2000,
          verticalPosition:'top'
        });
        this.refreshDepList();
        this.onClose();
      })
      this.refreshDepList();
  }
}

//<div *ngIf="deptName.errors && (deptName.dirty||deptName.touched)" class="alert alert-danger">
//          <div [hidden]="!deptName.errors.required">
//            department name is required
//          </div>
//        </div>