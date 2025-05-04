import { Component, OnInit } from '@angular/core';
import { BillService } from '../../services/bill.service';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-bills-results',
  imports: [CommonModule, MatTableModule, MatCardModule],
  templateUrl: './bills.component.html',
  styleUrl: './bills.component.css',
  standalone: true
})
export class BillsComponent implements OnInit {

  billsResults: IBillResults[] = [];
  displayedColumns: string[] = ['id', 'billTitle', 'supporters', 'opposers', 'primarySponsor'];

  constructor(private billService: BillService) {}

  ngOnInit(): void {
    this.billService.getBillResults().subscribe({
      next: (response) => this.billsResults = response
    })
  }
}  

export interface IBillResults {
  id: number;
  billTitle: string;
  supporters: number;
  opposers: number;
  primarySponsor: string;
}