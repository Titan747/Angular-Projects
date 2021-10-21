import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletedemployeesComponent } from './deletedemployees.component';

describe('DeletedemployeesComponent', () => {
  let component: DeletedemployeesComponent;
  let fixture: ComponentFixture<DeletedemployeesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeletedemployeesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeletedemployeesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
