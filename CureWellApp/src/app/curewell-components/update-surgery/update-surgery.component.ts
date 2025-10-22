import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { CurewellService } from '../../curewell-services/curewell.service';
import { Surgery } from '../../curewell-interfaces/surgery';

@Component({
  templateUrl: './update-surgery.component.html'
})
export class UpdateSurgeryComponent implements OnInit {

  doctorId: number=0;
  surgeryId: number = 0;
  surgeryDate: Date = new Date();
  startTime: number = 0;
  endTime: number=0;
  surgeryCategory: string="";
  status: boolean=false;
  errorMsg: string = "";

  constructor(private route: ActivatedRoute, private _cureWellService: CurewellService, private router: Router) { }

  ngOnInit() {
    //To do implement necessary logic    
  }

  editSurgery(startTime: number, endTime: number) {
    //To do implement necessary logic
  }
}
