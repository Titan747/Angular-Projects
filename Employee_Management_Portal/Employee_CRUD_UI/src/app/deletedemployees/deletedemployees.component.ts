import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatSnackBar, MatTableDataSource, MatSort } from '@angular/material';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-deletedemployees',
  templateUrl: './deletedemployees.component.html',
  styleUrls: ['./deletedemployees.component.css']
})
export class DeletedemployeesComponent implements OnInit {
  constructor(private service: EmployeeService,
    private dialog:MatDialog,
    private snackBar:MatSnackBar)  { 
      this.service.listen().subscribe((m:any)=>{
        console.log(m);
        this.refreshEmpList();
      })
    }

    listData : MatTableDataSource<any>;
  displayedColumns : string[] = ['EmployeeID', 
  'EmployeeName', 'Department', 'MailID', 'DOJ', 'Gender', 'Address', 'PinCode']

  @ViewChild(MatSort, null) sort: MatSort;

  ngOnInit() {

    this.refreshEmpList();
  }
  applyFilter(filtervalue:  string){
    this.listData.filter= filtervalue.trim().toLocaleLowerCase();
  }


  refreshEmpList(){
this.service. getInactiveEmployees().subscribe(data => {
  this.listData  = new MatTableDataSource(data);
  this.listData.sort = this.sort;
});
  }


}