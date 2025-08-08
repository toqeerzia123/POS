/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { POSScreenComponent } from './POS-screen.component';

describe('POSScreenComponent', () => {
  let component: POSScreenComponent;
  let fixture: ComponentFixture<POSScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ POSScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(POSScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
