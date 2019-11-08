import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User, Cita } from '../_models';
import { UserService, AuthenticationService } from '../_services';

@Component({ templateUrl: 'cita.component.html' })
export class CitaComponent implements OnInit {
    loading = false;
    citas: Cita[] = [];
    currentUser: User;

    displayDialog: boolean;

    cita: Cita = {
        citaID:0,
        paciente:{pacienteID:"",pacienteFullName:""},
        tipoCita:{tipoCitaID:0,tipoCitaNombre:""},
        activa:false, 
        fechaCita: new Date()
    };

    selectedCar: Cita;
    newCar: boolean;
    cols: any[];

    constructor(
        private userService: UserService,
        private authenticationService: AuthenticationService
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        this.loading = false;
        //console.log(this.currentUser)
        this.userService.GetCitasByPacienteId(this.currentUser.id).pipe(first()).subscribe(citas => {
            this.loading = false;
            this.citas = citas;
            console.log(citas)
        });

        this.cols = [
            { field: 'citaID', header: 'Id' },
            { field: 'tipoCita.tipoCitaNombre', header: 'Tipo de cita' },
            { field: 'fechaCita', header: 'Fecha de Cita' }
        ];
    }

    showDialogToAdd() {
        this.newCar = true;
        this.cita = {
            citaID:0,
            paciente:{pacienteID:"",pacienteFullName:""},
            tipoCita:{tipoCitaID:0,tipoCitaNombre:""},
            activa:false, 
            fechaCita: new Date()
        };
        this.displayDialog = true;
    }

    save() {
        let citas = [...this.citas];
        if (this.newCar)
            citas.push(this.cita);
        else
            citas[this.citas.indexOf(this.selectedCar)] = this.cita;

        this.citas = citas;
        this.cita = null;
        this.displayDialog = false;
    }

    delete() {
        let index = this.citas.indexOf(this.selectedCar);
        this.citas = this.citas.filter((val, i) => i != index);
        this.cita = null;
        this.displayDialog = false;
    }

    onRowSelect(event) {
        this.newCar = false;
        this.cita = this.cloneCar(event.data);
        this.displayDialog = true;
    }

    cloneCar(c: Cita): Cita {
        let cita = {
            citaID:0,
            paciente:{pacienteID:"",pacienteFullName:""},
            tipoCita:{tipoCitaID:0,tipoCitaNombre:""},
            activa:false, 
            fechaCita: new Date()
        };
        // for (let prop in c) {
        //     console.log(c)
        //     cita[prop] = c[prop];
        // }
        return cita;
    }
}