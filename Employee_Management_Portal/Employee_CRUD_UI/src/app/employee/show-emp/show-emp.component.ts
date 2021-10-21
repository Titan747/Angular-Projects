import { Component, OnInit ,ViewChild } from '@angular/core';
import { MatTableDataSource,MatSort } from '@angular/material';
import { Employee } from 'src/app/models/employee-model';
import { EmployeeService } from 'src/app/services/employee.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { AddEmpComponent } from 'src/app/employee/add-emp/add-emp.component';
import { MatSnackBar } from '@angular/material';
import { EditEmpComponent } from '../edit-emp/edit-emp.component';


@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {
gen:any;
  constructor(private service: EmployeeService,
    private dialog:MatDialog,
    private snackBar:MatSnackBar)  { 
      this.service.listen().subscribe((m:any)=>{
        console.log(m);
        this.refreshEmpList();
      })
    }
    public listItems: Array<string> = [];

  listData : MatTableDataSource<any>;
  displayedColumns : string[] = ['EmployeeID', 
  'EmployeeName','DepartmentID','Department', 'EmailId', 'DateOfBirth', 'Gender', 'Address', 'PinCode','Options']

  @ViewChild(MatSort, null) sort: MatSort;

  ngOnInit() {
    this.dropdownRefresh();
    this.refreshEmpList();
  }

  dropdownRefresh(){
    this.service.getDepDropDownValues().subscribe(data=>{
      data.forEach(element => {
        this.listItems.push(element["deptName"]);
      });
    })
    }

  refreshEmpList(){
    this.service.getEmpList().subscribe(data => {
      this.listData  = new MatTableDataSource(data);
      this.listData.sort = this.sort;
  });
}

  applyFilter(filtervalue:  string){
    this.listData.filter= filtervalue.trim().toLocaleLowerCase();
  }

  onEdit(emp: Employee){
    this.service.formData = emp;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus= true;
    dialogConfig.width= "70%";
    this.dialog.open(EditEmpComponent, dialogConfig);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete??')){
      this.service.deleteEmployee(id).subscribe(res=>{
        //this.refreshEmpList();
        this.snackBar.open('Employee Details','Deleted Successfully', {
        duration:2000,
        verticalPosition:'top'
        });
        this.refreshEmpList();
      });
    }
  }

  onAdd(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus= true;
    dialogConfig.width= "70%";
    this.dialog.open(AddEmpComponent, dialogConfig);
    this.refreshEmpList();
      }

}


// this.snackBar.open(res.toString(), '',