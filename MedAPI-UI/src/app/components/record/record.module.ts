import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecordComponent } from './record.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { NoteComponent } from '../note/note.component';

const routes: Routes = [
  {
    path: '', component: RecordComponent, children: [
      { path: 'notes', component: NoteComponent },
    ]
  }
];

@NgModule({
  declarations: [RecordComponent, NoteComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class RecordModule { }
