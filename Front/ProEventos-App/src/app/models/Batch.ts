import { EventModel } from "./EventModel";

export interface BatchModel {
  id: number;
  name: string;
  price: number;
  initialDate?: Date;
  endDate?: Date;
  ammount: number;
  eventId: number;
  eventModel: EventModel;
}
