import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'BookShop Web';
  books: any;

  constructor(private http: HttpClient){}
  ngOnInit(){
    this.getBooks();
  }

  getBooks(){
    this.http.get('https://localhost:5001/api/books').subscribe(response => {
      this.books = response;
    }, error => {
        console.log(error);        
    })
  }
}
