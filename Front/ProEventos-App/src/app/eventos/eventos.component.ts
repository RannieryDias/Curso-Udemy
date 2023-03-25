import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent {
  public eventos: any = [];
  public filteredEventos: any = [];
  isImageCollapsed: boolean = false;

  widthImg: number = 50;
  marginImg: number = 2;


  private _filterList: string = '';

  public get filterList(){
    return this._filterList;
  }

  public set filterList(value: string){
    this._filterList = value
    this.filteredEventos = this.filterList ?
                                    this.filterEvent(this.filterList) :
                                    this.eventos;
  }

  private filterEvent(filterBy: string) : any{
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento : any) => evento.tema.toLocaleLowerCase()
                           .indexOf(filterBy) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  changeIsImageCollapsedEvent(){
    this.isImageCollapsed = !this.isImageCollapsed;
  }

  public getEventos(): void {
    this.http.get('http://localhost:5216/api/eventos').subscribe({
      next: (response) => this.filteredEventos = this.eventos = response,
      error: (e) => console.log(e)
    });

  }
}
