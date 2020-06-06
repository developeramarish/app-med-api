import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NoteService } from '../../services/note.service';

@Component({
  selector: 'app-dialog-diabetes-risk',
  templateUrl: './dialog-diabetes-risk.component.html',
  styleUrls: ['./dialog-diabetes-risk.component.scss']
})
export class DialogDiabetesRiskComponent implements OnInit {
  public patient: any = {
    sex: 'M',
    cigarettes: 0,
    personalBackground: ['HIPERTENSION'],
    medicines: ['ANTIHIPERTENSIVOS'],
    age: 20,
    fatherBackground: ['HIPERTENSION'],
    motherBackground: ['HIPERTENSION'],
    physicalActivity: 'MODERADA'
  }

  constructor(public dialogRef: MatDialogRef<DialogDiabetesRiskComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private noteService: NoteService) {
    console.log(data, 'data');
  }

  ngOnInit(): void {
  }

  cancel(): void {
    this.dialogRef.close();
  }

  answer(): void {
    this.dialogRef.close({
      accept: true,
      note: this.data.note
    });
  }

  updateComputedFields() {
    this.noteService.updateComputedFieldsEvent.emit(this.data.note);
  }
}
