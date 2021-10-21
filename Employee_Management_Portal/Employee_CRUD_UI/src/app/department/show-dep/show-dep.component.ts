import { Component, OnInit ,ViewChild} from '@angular/core';
import {MatTableDataSource,MatSort} from '@angular/material';
import { Department } from 'src/app/models/department-model';
import { DepartmentService } from 'src/app/services/department.service';
import {MatDialog, MatDialogConfig} from '@angular/material';
import {AddDepComponent} from 'src/app/department/add-dep/add-dep.component';
import {MatSnackBar} from '@angular/material';
import { EditDepComponent } from '../edit-dep/edit-dep.component';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {

  constructor(private service: DepartmentService,
    private dialog:MatDialog,
    private snackBar:MatSnackBar ) { 
      this.service.listen().subscribe((m:any)=>{
        console.log(m);
        this.refreshDepList();
      })
    }

  listData : MatTableDataSource<any>;
  displayedColumns : string[] = ['DepartmentID', 'DepartmentName','Options'];

  @ViewChild(MatSort, null) sort: MatSort;

  ngOnInit() {
    this.refreshDepList();
  }

  ngAfterViewInit(): void {
    this.listData.sort = this.sort;
  }

  refreshDepList(){
this.service.getDepList().subscribe(data => {
  this.listData  = new MatTableDataSource(data);
  this.listData.sort = this.sort;
});
}

  applyFilter(filtervalue:  string){
    this.listData.filter= filtervalue.trim().toLocaleLowerCase();
  }

  onEdit(dept: Department){
    this.service.formData = dept;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus= true;
    dialogConfig.width= "70%";
    this.dialog.open(EditDepComponent, dialogConfig);
    this.refreshDepList();
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete??')){
      this.service.deleteDepartment(id).subscribe(res=>{
        this.refreshDepList();
        this.snackBar.open('Department Deleted', 'Successfully', {
          duration:2000,
          verticalPosition:'top'
        });
        this.refreshDepList();
      });
    }
  }

  onAdd(){
const dialogConfig = new MatDialogConfig();
dialogConfig.disableClose = true;
dialogConfig.autoFocus= true;
dialogConfig.width= "70%";
this.dialog.open(AddDepComponent, dialogConfig);

  }

}
