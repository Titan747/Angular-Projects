import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MatSort, MatTableDataSource } from '@angular/material';
import { EmployeeService } from 'src/app/services/employee.service';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-add-emp',
  templateUrl: './add-emp.component.html',
  styleUrls: ['./add-emp.component.css']
})
export class AddEmpComponent implements OnInit {
registerForm: FormGroup;
submitted = false;
departments: any = [];
departmentData : any;
departid: number;
  isValidFormSubmitted: boolean;
  genderreq:boolean;
  selectedGender: any;
  constructor(public dialogbox: MatDialogRef<AddEmpComponent>,
    private service: EmployeeService,
    private snackBar: MatSnackBar,private formBuilder: FormBuilder) {
    this.service.listen().subscribe((m: any) => {
      console.log(m);
      this.refreshEmpList();
    })
  }
  public listItems: any;
  public listItems1 : Array<string> = [];
  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['EmployeeID',
    'EmployeeName', 'DepartmentID', 'Department', 'EmailId', 'DateOfBirth', 'Gender', 'Address', 'PinCode', 'Options']

  @ViewChild(MatSort, null) sort: MatSort;
  model = { options: '' };
  minDate = new Date(1921, 1, 1);
  maxDate = new Date();
  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      empName: ['',[Validators.required]],
      departmentName: ['',[Validators.required]],
      emailId: ['', [Validators.required,Validators.email,Validators.pattern('[a-zA-Z0-9.-_]{1,}@[a-zA-Z.-]{2,}[.]{1}[a-zA-Z]{2,}')]],
      dateOfBirth: ['', [Validators.required]],
      dob: ['', [Validators.required, Validators.pattern(/^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$/)]],
      options: ['', [Validators.required]],
      address: ['', [Validators.required]],
      pinCode: ['', [Validators.required,Validators.pattern('[0-9]{5}'),Validators.minLength(5)]]
  });
    this.resetForm();
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
        console.log(this.departments);
      });
    });
  }
  refreshEmpList() {
    this.service.getEmpList().subscribe(data => {
      this.listData = new MatTableDataSource(data);
      this.listData.sort = this.sort;
    });
  }
  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    
    this.service.formData = {
      empId:0,
      deptId:this.departid,
      empName: '',
      deptName:'',
      emailId: '',
      dateOfBirth: new Date("dd/mm/yyyy"),
      gender: '',
      address: '',
      pinCode: null,
      isActive: true
    }

  }

  get f() { return this.registerForm.controls; }

  onClose() {
    this.dialogbox.close();
    this.service.filter('Register click');
  }

  regexp = new RegExp(/[a-zA-Z0-9.-_]{1,}@[a-zA-Z.-]{2,}[.]{1}[a-zA-Z]{2,}/); 

  changeGender(e) {
    if(this.model.options==null||this.model.options==''){
      this.genderreq = true;
    }
    else{
      this.genderreq = false;
    }
  }
  
  onSubmit(form: NgForm) {
    this.submitted = true;
    this.isValidFormSubmitted = false; 
    /*if(this.registerForm.invalid){
      return false;
    }*/
    if(this.model.options==null||this.model.options==''){
      this.genderreq = true;
      return false;
    }
    if(form.value.pinCode == null || form.value.pinCode == '' || form.value.pinCode.toString().length < 5 ||
       form.value.address == null || form.value.address == '' ||
       form.value.empName == null || form.value.empName == '' ||
       this.departid == null || this.departid <= 0 ||
       form.value.dateOfBirth == null || form.value.dateOfBirth == '' ||
       form.value.emailId == null || form.value.emailId == '' || !this.regexp.test(form.value.emailId))
     {
      return false;
     }   
     
    //if(this.model.options==null||this.model.options==''){
    //  this.genderreq = true;
    //  return false;
    //}
    form.value.dateOfBirth = new Date(form.value.dateOfBirth).getFullYear().toString()
      + '-' + (new Date(form.value.dateOfBirth).getMonth() + 1).toString()
      + '-' + new Date(form.value.dateOfBirth).getDate().toString();
    form.value.gender = this.model.options;
    form.value.deptId = this.departid;
    this.service.addEmployee(form.value).subscribe(res => {
      this.resetForm(form);
      this.snackBar.open('Employee','Added Successfully', {
        duration: 2000,
        verticalPosition: 'top'
      });
      this.refreshEmpList();
      this.onClose();
    })
    this.refreshEmpList();
  }
onChange(x){
console.log(x);
this.departid = x;
this.service.formData.deptId=x;
console.log(this.service.formData.deptId);
  }
}



//console.log(form.value.pinCode);
//console.log(form.value.address);
//console.log(form.value.empName);
//console.log(form.value.dateOfBirth);
//console.log(form.value.emailId);
//console.log(this.departid);

//.alert{
//  height:40px;
//}
//.validprop{
//  height:0px;
//  margin-top: 0px;
//} 