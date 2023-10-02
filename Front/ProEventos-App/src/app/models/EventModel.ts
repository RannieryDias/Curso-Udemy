import { BatchModel } from "./Batch";
import { SocialNetwork } from "./SocialNetwork";
import { Speaker } from "./Speaker";

export interface EventModel {
  id: number;
  location: string;
  eventDate?: Date;
  theme: string;
  capacity: number;
  imageUrl : string;
  phone: string;
  batches: BatchModel[];
  socialNetworks: SocialNetwork[];
  speaker: Speaker[];
}
