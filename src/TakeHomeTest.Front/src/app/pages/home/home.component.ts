import { Component } from '@angular/core';
import { BillsComponent } from '../bills/bills.component';
import { LegislatorComponent } from '../legislator/legislator.component';
import { MatDivider } from '@angular/material/divider';
import { MatTabsModule } from '@angular/material/tabs';

@Component({
  selector: 'app-home',
  imports: [BillsComponent, LegislatorComponent, MatDivider, MatTabsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  standalone: true
})
export class HomeComponent {}