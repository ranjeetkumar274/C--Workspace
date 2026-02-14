import { Component } from '@angular/core';

@Component({
  selector: 'app-color-viewer',
  templateUrl: './color-viewer.component.html',
  styleUrls: ['./color-viewer.component.css']
})
export class ColorViewerComponent {

  receivedColor:string='#ff0000';
  updateColor(newColor:string){
    this.receivedColor=newColor;
  }

}



import { Component ,EventEmitter,Output} from '@angular/core';

@Component({
  selector: 'app-color-picker',
  templateUrl: './color-picker.component.html',
  styleUrls: ['./color-picker.component.css']
})
export class ColorPickerComponent {
selectedColor:string='#ff0000';

@Output() colorSelected=new EventEmitter<string>();

onColorChange(){
  this.colorSelected.emit(this.selectedColor);
}
}





import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ColorPickerComponent } from './color-picker/color-picker.component';
import { ColorViewerComponent } from './color-viewer/color-viewer.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ColorPickerComponent,
    ColorViewerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }






<h1>Pick a color</h1>
<input type="color"
[(ngModel)]="selectedColor"
(change)="onColorChange()">

<h1>Selected Color:</h1>
<div class="selected-color-box"

[style.background-color]="selectedColor">
</div>


  <p>color-viewer works!</p>
<h1>Color Viewer/h1>
    <div class="color-box" [style.background-color]="receivedColor">

        Color received from the ColorPicker component
    </div>




<h1>Color Picker</h1>
<div>
  <img src="assets/colorpickerbird.png">
</div>

<div>
  <app-color-picker (colorSelected)="colorViewer.updateColor($event)"> </app-color-picker>
</div>

<app-color-viewer #colorViewer> </app-color-viewer>
