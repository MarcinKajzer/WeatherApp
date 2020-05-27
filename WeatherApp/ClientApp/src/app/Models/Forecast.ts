import { PlaceInfo } from './PlaceInfo';
import { Detail } from './ForecastDetails';


export interface Forecast {
    placeInfo: PlaceInfo;
    details: Detail[];
}
