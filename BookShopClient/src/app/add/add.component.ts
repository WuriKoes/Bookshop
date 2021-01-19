import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  model: any = {}
  constructor() { }

  ngOnInit(): void {
  }

  add(){
    console.log(this.model);
  }

  cancel(){
    console.log('cancelled');
  }

}
