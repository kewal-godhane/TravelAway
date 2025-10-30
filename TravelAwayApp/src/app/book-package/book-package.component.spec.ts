import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookPackageComponent } from './book-package.component';

describe('BookPackageComponent', () => {
  let component: BookPackageComponent;
  let fixture: ComponentFixture<BookPackageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookPackageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
