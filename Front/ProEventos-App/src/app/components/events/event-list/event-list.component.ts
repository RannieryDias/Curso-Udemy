import { Router } from '@angular/router';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { EventModel } from '@app/models/EventModel';
import { EventService } from '@app/services/event.service';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss']
})
export class EventListComponent {
  modalRef?: BsModalRef;

  public eventos: EventModel[] = [];
  public filteredEventos: EventModel[] = [];

  public isImageCollapsed: boolean = false;
  public widthImg: number = 50;
  public marginImg: number = 2;

  private filterListed: string = '';

  public get filterList() {
    return this.filterListed;
  }

  public set filterList(value: string) {
    this.filterListed = value
    this.filteredEventos = this.filterList ?
      this.filterEvent(this.filterList) :
      this.eventos;
  }

  public filterEvent(filterBy: string): EventModel[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: EventModel) => evento.theme.toLocaleLowerCase()
        .indexOf(filterBy) !== -1 ||
        evento.location.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(private eventService: EventService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEvents();
  }

  public changeIsImageCollapsedEvent(): void {
    this.isImageCollapsed = !this.isImageCollapsed;
  }

  public getEvents(): void {
    this.eventService.getEvents().subscribe({
      next: (events: EventModel[]) => this.filteredEventos = this.eventos = events,
      error: (e) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar eventos', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  public getEventsByTheme(): void {
    this.eventService.getEvents().subscribe({
      next: (response: EventModel[]) => this.filteredEventos = this.eventos = response,
      error: (e) => console.log(e),
    });
  }


  public editEvent(id: number): void {
    this.eventService.editEvent
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento apagado', 'Sucesso');
  }

  decline(): void {
    this.modalRef?.hide();
  }

  eventDetail(id: number): void {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }
}
