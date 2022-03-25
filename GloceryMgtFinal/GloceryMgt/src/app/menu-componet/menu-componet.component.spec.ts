import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuComponetComponent } from './menu-componet.component';

describe('MenuComponetComponent', () => {
  let component: MenuComponetComponent;
  let fixture: ComponentFixture<MenuComponetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuComponetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuComponetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
