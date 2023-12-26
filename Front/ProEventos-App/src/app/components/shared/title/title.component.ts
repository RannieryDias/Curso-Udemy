import { Component, Input, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit{
  @Input() title: string = "";
  @Input() subTitle: string = "Desde 2023";
  @Input() iconClass: string = "fa fa-user";
  @Input() isBtnAvailable: boolean = false;
  constructor(private router: Router) { }

  ngOnInit(): void {  }
  list(): void {
    this.router.navigate([`/${this.title.toLocaleLowerCase()}/lista`])
  }
}
