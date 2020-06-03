import { ThreeHoursDetails } from './ThreeHoursDetails';
import { PlaceInfo } from './PlaceInfo';

export interface ThreeHoursForecast {
    placeInfo: PlaceInfo;
    details: ThreeHoursDetails[];
}
