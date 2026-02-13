================================================================================
ANGULAR NAMES COMPONENT
================================================================================

--- FILE: names.component.ts ---
import { Component } from '@angular/core';

@Component({
  selector: 'app-names',
  templateUrl: './names.component.html',
  styleUrls: ['./names.component.css']
})
export class NamesComponent {
  names: string[] = ["sachin", "prakash"];
  n: string;

  addName() {
    this.names.push(this.n);
  }
}

--- FILE: names.component.html ---
<h1>Show All</h1>
<table>
  <thead>
    <tr>
      <th>Names</th>
    </tr>
  </thead>
  <tbody>
    <tr *ngFor="let n of names">
      <td>{{n}}</td>
    </tr>
  </tbody>
</table>

<hr>

<div>
  <label>Name</label>
  <input type="text" name="n" [(ngModel)]="n">
  <button (click)="addName()">Add Name</button>
</div>
