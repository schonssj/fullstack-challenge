import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { LegislatorService } from '../../services/legislator.service';

@Component({
  selector: 'app-legislators-votes',
  imports: [CommonModule, MatTableModule, MatCardModule, MatPaginatorModule, MatPaginator],
  templateUrl: './legislator.component.html',
  styleUrl: './legislator.component.css'
})
export class LegislatorComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'supported', 'opposed'];
  legislatorsVotes: ILegislatorVotes[] = [];
  dataSource!: MatTableDataSource<ILegislatorVotes>;
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private legislatorService: LegislatorService) {}

  ngOnInit(): void {
    this.legislatorService.getLegislatorsVotes().subscribe({
      next: (response) => {
        this.legislatorsVotes = response
        this.dataSource = new MatTableDataSource<ILegislatorVotes>(this.legislatorsVotes);
        this.dataSource.paginator = this.paginator;
      }
    });
  }
}

export interface ILegislatorVotes {
  legislatorId: number;
  legislatorName: string;
  supportedBills: number;
  opposedBills: number;
}