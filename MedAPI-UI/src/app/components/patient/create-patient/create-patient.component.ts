import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { PatientService } from '../service/patient.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router, NavigationStart } from '@angular/router';
import { CheckEmptyUtil } from '../../../shared/util/check-empty.util';

@Component({
  selector: 'app-create-patient',
  templateUrl: './create-patient.component.html',
  styleUrls: ['./create-patient.component.scss']
})
export class CreatePatientComponent implements OnInit {
  tabs: Array<{ title: string; value: string; }>;
  index = new FormControl(0);
  patient = {
    id: 0,
    name: '',
    lastnameFather: '',
    lastnameMother: '',
    country: '',
    documentType: '',
    patientDocumentNumber: '',
    birthday: '',
    sex: '',
    maritalStatus: '',
    department: '',
    province: '',
    district: '',
    address: '',
    isDonor: false,
    email: '',
    phone: '',
    race: '',
    educationalAttainment: '',
    occupation: '',
    bloodType: '',
    alcoholConsumption: '',
    physicalActivity: '',
    fvConsumption: '',
    home: {
      rooms: '',
      population: '',
      type: '',
      ownership: '',
      material: '',
      electricity: false,
      water: false,
      sewage: false
    },
    allergies: [],
    otherAllergies: '',
    medicines: [],
    otherMedicines: '',
    personalBackground: [],
    otherPersonalBackground: '',
    fatherBackground: [],
    otherFatherBackground: '',
    motherBackground: [],
    otherMotherBackground: ''
  };

  resources = null;
  submit = {
    waiting: false,
    success: false
  };
  constructor(public route: ActivatedRoute, public router: Router, private patientService: PatientService, public toastr: ToastrService) {
    //router.events.subscribe((val) => {
    //  if (val instanceof NavigationStart) {
    //    if (val.url.includes('patients/new')) {
    //      localStorage.setItem('patient', '');
    //    }
    //  }
    //});
  }

  ngOnInit(): void {
    let patientId = this.route.snapshot.paramMap.get('id');
    if (CheckEmptyUtil.isNotEmpty(patientId)) {
      let patientData = localStorage.getItem('patient');
      console.log(patientData, 'patientData');
      if (CheckEmptyUtil.isNotEmpty(patientData)) {
        const patientDetails = JSON.parse(patientData);
        this.patient.id = patientDetails.Id;
        this.patient.address = patientDetails.Address;
        this.patient.birthday = patientDetails.Birthday;
        this.patient.phone = patientDetails.Phone;
        this.patient.patientDocumentNumber = patientDetails.DocumentNumber;
        this.patient.documentType = patientDetails.DocumentType;
        this.patient.email = patientDetails.Email;
        this.patient.name = patientDetails.FirstName;
        this.patient.lastnameFather = patientDetails.LastNameFather;
        this.patient.lastnameMother = patientDetails.LastNameMother;
        this.patient.maritalStatus = patientDetails.MaritalStatus;
        if (CheckEmptyUtil.isNotEmpty(patientDetails.OrganDonor)) {
          this.patient.isDonor = true;
        } else {
          this.patient.isDonor = false;
        }
        this.patient.sex = patientDetails.Sex;
        this.patient.country = patientDetails.country;
        this.patient.district = patientDetails.district;
      }
    }
    this.tabs = [{
      title: 'Información General',
      value: 'form_1'
    }, {
      title: 'Información Adicional',
      value: 'form_2'
    }, {
      title: 'Antecedentes',
      value: 'form_3'
    }, {
      title: 'Información de Vivienda',
      value: 'form_4'
    }, {
      title: 'Resumen',
      value: 'form_5'
    }];

    this.getResources();

  }


  getResources() {
    let resourcesPath: string = 'users/resources';

    this.patientService.getResources(resourcesPath).then((response: any) => {
      this.patientService.resources.next(response);
    }).catch((error) => {
      console.log(error);
    });
  }

  submitRequest = function () {

    this.submit.waiting = true;

    this.patientService.save(
      this.patient,
      function (response) {
        console.log(response);
        this.submit.waiting = false;
        this.submit.success = true;
        this.toastr.success('Paciente afiliado correctamente.');
        this.router.navigateByUrl('/record');
      },
      function (errors) {
        console.log(errors);
        this.submit.waiting = false;
        this.submit.success = false;
        this.toastr.error('Ocurrió un error al afiliar el paciente.');
      });

  }
}
