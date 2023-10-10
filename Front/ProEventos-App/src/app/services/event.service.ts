import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EventModel } from '../models/EventModel';
import { Observable } from 'rxjs';

@Injectable(
  // { providedIn: 'root'}
)
export class EventService {
  baseUrl = 'https://localhost:44332/api/eventos';

  constructor(private http: HttpClient) {}

  public getEvents(): Observable<EventModel[]>{
    return this.http.get<EventModel[]>(this.baseUrl);
  }

  public getEventByTheme(theme: string): Observable<EventModel[]>{
    return this.http.get<EventModel[]>(`${this.baseUrl}/${theme}/theme`);
  }

  public getEventById(id: number): Observable<EventModel>{
    return this.http.get<EventModel>(`${this.baseUrl}/${id}`);
  }

  //public insertEvent(eventModel: EventModel){
  //   return this.http.post(this.baseUrl);
  // }

  public editEvent(id: number){
    return this.http.get(this.baseUrl + id);
  }

  public deleteEvent(id: number){
    return this.http.delete(this.baseUrl + id);
  }
}
