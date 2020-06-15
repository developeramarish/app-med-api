import { Injectable } from '@angular/core';
import { HttpUtilService } from '../../../services/http-util.service';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  resources: BehaviorSubject<[]> = new BehaviorSubject([]);

  constructor(private httpUtilService: HttpUtilService) { }


  getResources(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath);
  }

  updateProvinces(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath);
  }

  updateDistricts(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath);
  }

  save(patient: any) {
    return this.httpUtilService.invoke('POST', patient, 'users/patient');
  }
}
