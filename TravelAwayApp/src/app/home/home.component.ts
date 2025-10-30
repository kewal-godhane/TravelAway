import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  roleId!: string; 
  constructor(private router: Router) {

  }
  ngOnInit() {

    if (!sessionStorage.getItem('EmailId')) {
      this.router.navigate(['/login'])
    }
    this.roleId = sessionStorage.getItem('RoleId') || "";
  }
}
