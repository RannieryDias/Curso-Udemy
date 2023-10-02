import { EventModel } from "./EventModel";
import { SocialNetwork } from "./SocialNetwork";

export interface Speaker {
  id: number;
  name: string;
  miniProfile: string;
  imageURL: string;
  phone: string;
  email: string;
  socialNetworks?: SocialNetwork[];
  eventSpeakers?: EventModel[];
}
