import { Injectable, EventEmitter, Output } from '@angular/core';
import { HttpUtilService } from '../../../services/http-util.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { ResourcesService } from '../../../services/resources.service';

@Injectable({
  providedIn: 'root'
})
export class NoteService {
  resources: BehaviorSubject<[]> = new BehaviorSubject([]);
  diagnosisList: EventEmitter<[]> = new EventEmitter<[]>();

  constructor(private httpUtilService: HttpUtilService, private resourcesService: ResourcesService) { }

  getResources(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath);
  }

  save(note: any) {
    return this.httpUtilService.invoke('POST', note, '');
  }

  /* diagnosis */

  queryDiagnosis(query: string): any {
    if (!query || query.length < 3) {
      return [];
    }
    return this.resourcesService.search(query, '/admin/diagnosis').then((response) => {
      return response;
    }).catch((error) => {
      console.log(error);
      return error;
    });
  }
}