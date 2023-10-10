import { Component, TemplateRef } from '@angular/core';
import { EventService } from '../services/event.service';
import { EventModel } from '../models/EventModel';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
  //providers: [EventService]
})
export class EventosComponent {
  modalRef?: BsModalRef;

  public eventos: EventModel[] = [];
  public filteredEventos: EventModel[] = [];

  public isImageCollapsed: boolean = false;
  public widthImg: number = 50;
  public marginImg: number = 2;

  private filterListed: string = '';

  public get filterList(){
    return this.filterListed;
  }

  public set filterList(value: string){
    this.filterListed = value
    this.filteredEventos = this.filterList ?
                                    this.filterEvent(this.filterList) :
                                    this.eventos;
  }

  public filterEvent(filterBy: string): EventModel[]{
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento : EventModel) => evento.theme.toLocaleLowerCase()
                           .indexOf(filterBy) !== -1 ||
      evento.location.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(private eventService: EventService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService) {}

  public ngOnInit(): void {
     /** spinner starts on init */
     this.spinner.show();

     setTimeout(() => {
       /** spinner ends after 5 seconds */
       this.spinner.hide();
     }, 5000);
    this.getEvents();
  }

  public changeIsImageCollapsedEvent(): void{
    this.isImageCollapsed = !this.isImageCollapsed;
  }

  public getEvents(): void {
    this.eventService.getEvents().subscribe({
      next: (events: EventModel[]) => this.filteredEventos = this.eventos = events,
      error: (e) => console.log(e)
    });
  }

  public getEventsByTheme(): void {
    this.eventService.getEvents().subscribe({
      next: (response: EventModel[]) => this.filteredEventos = this.eventos = response,
      error: (e) => console.log(e)
    });
  }

  // public getEventById(id: number): void {
  //   this.eventService.getEventById(id).subscribe({
  //     next: (event: EventModel) => this.filteredEventos = this.eventos = event,
  //     error: (e) => console.log(e)
  //   });
  // }

  public editEvent(id: number): void {
    this.eventService.editEvent
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento apagado', 'Sucesso')
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
