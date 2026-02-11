day 6 week 5 session 3 ques 2
 
product.model.ts
 
export interface Product {
    id: number;
    name: string;
    category: string;
    price: number;
 }
 
app.component.ts
 
import { Component } from '@angular/core';
import { Product } from './product.model';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angularapp';
  productData: Product[] = [
    {id: 10, name: 'Sanjay', category: 'hr', price:12000},
    {id: 11, name: 'Say', category: 'it', price:12002}
  ];
}
 
 
app.component.html
 
<h1>Product Management</h1>
<table>
  <thead>
    <tr>
      <th>ID</th>
      <th>Name</th>
      <th>Category</th>
      <th>Price</th>
    </tr>
  </thead>
  <tbody>
    <tr *ngFor="let e of productData">
      <td>{{e.id}}</td>
      <td>{{e.name}}</td>
      <td>{{e.category}}</td>
      <td>{{e.price}}</td>
    </tr>
  </tbody>
</table>
 
