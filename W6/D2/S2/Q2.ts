================================================================================
PROJECT: TEXT TRANSFORMATION COMPONENT
================================================================================

--- FILE: text-transformation.component.ts ---
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-text-transformation',
  templateUrl: './text-transformation.component.html',
  styleUrls: ['./text-transformation.component.css']
})
export class TextTransformationComponent implements OnInit {
  transformedText: string = "";
  textLength: number = 0;
  lowercaseCount: number = 0;
  uppercaseCount: number = 0;
  numberCount: number = 0;
  specialCharCount: number = 0;

  transformText(inputText: string): void {
    this.transformedText = inputText.toUpperCase();
    this.textLength = inputText.length;
    
    // Reset counters before recalculating
    this.lowercaseCount = 0;
    this.uppercaseCount = 0;
    this.numberCount = 0;
    this.specialCharCount = 0;

    for (let char of inputText) {
      if (char >= 'a' && char <= 'z') {
        this.lowercaseCount++;
      } else if (char >= 'A' && char <= 'Z') {
        this.uppercaseCount++;
      } else if (char >= '0' && char <= '9') {
        this.numberCount++;
      } else {
        this.specialCharCount++;
      }
    }
  }

  constructor() { }

  ngOnInit(): void {
  }
}

--- FILE: text-transformation.component.html ---
<div>
  <input type="text" (input)="transformText($event.target.value)" placeholder="Enter text here">
  
  <p>Transformed Text: {{ transformedText }}</p>
  <p>Length of Text: {{ textLength }}</p>
  <p>Lowercase Count: {{ lowercaseCount }}</p>
  <p>Uppercase Count: {{ uppercaseCount }}</p>
  <p>Number Count: {{ numberCount }}</p>
  <p>Special Character Count: {{ specialCharCount }}</p>
</div>


================================================================================
PROJECT: NAMES COMPONENT (UPDATED)
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
    this.n = ''; // Clears the input field after adding
  }
}

--- FILE: names.component.html ---
<h1>Show All</h1>
<table>
  <thead>
    <tr><th>Names</th></tr>
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
