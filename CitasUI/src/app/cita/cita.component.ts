import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User, Cita, TipoCita } from '../_models';
import { CitaService , AuthenticationService } from '../_services';

@Component({ templateUrl: 'cita.component.html' })
export class CitaComponent implements OnInit {
    loading = false;
    citas: Cita[] = [];
    tiposCitas: TipoCita[] = [];
    currentUser: User;
    displayDialog: boolean;
    hayError = false;
    error = '';

    cita: Cita = {
        citaID: 0,
        paciente: { pacienteID : "", pacienteFullName : ""},
        tipoCita: { tipoCitaID : 0, tipoCitaNombre : ""},
        activa: false, 
        fechaCita: new Date()
    };

    selectedCita: Cita;
    newCita: boolean;
    cols: any[];

    constructor(
        private citaService: CitaService,
        private authenticationService: AuthenticationService
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        this.loading = false;
        this.citaService.GetCitasByPacienteId(this.currentUser.id).pipe(first()).subscribe(citas => {
            this.loading = false;
            this.citas = citas;
            console.log(citas)
        });

        this.citaService.GetTiposCitas().pipe(first()).subscribe(tiposCitas => {
            this.loading = false;
            this.tiposCitas = tiposCitas;
        });

        this.cols = [
            { field: 'citaID', header: 'Id' },
            { field: 'tipoCita.tipoCitaNombre', header: 'Tipo de cita' },
            { field: 'fechaCita', header: 'Fecha de Cita' }
        ];
    }

    showDialogToAdd() {
        this.newCita = true;
        this.cita = {
            citaID : 0,
            paciente : { pacienteID : "", pacienteFullName : ""},
            tipoCita : { tipoCitaID : 0, tipoCitaNombre : ""},
            activa: false, 
            fechaCita : new Date()
        };
        this.displayDialog = true;
    }

    save() {
        this.cita.paciente.pacienteID = this.currentUser.id;
        console.log(this.cita)
        this.citaService.AddCita(this.cita).pipe(first()).subscribe(cita => {

            // this.loading = false;
             console.log(cita);
        },
        error => {
            this.error = error;
            this.hayError = true;
            this.displayDialog = false;
            setTimeout(() => {
                this.hayError = false;
             }, 3000);
        });
        // let citas = [...this.citas];
        // if (this.newCita)
        //     citas.push(this.cita);
        // else
        //     citas[this.citas.indexOf(this.selectedCita)] = this.cita;

        // this.citas = citas;
        // this.cita = null;
        // this.displayDialog = false;
    }

    delete() {
        let index = this.citas.indexOf(this.selectedCita);
        this.citas = this.citas.filter((val, i) => i != index);
        this.cita = null;
        this.displayDialog = false;
    }

    onRowSelect(event) {
        this.newCita = false;
        this.cita = this.cloneCar(event.data);
        this.displayDialog = true;
    }

    cloneCar(c: Cita): Cita {
        let cita = {
            citaID : 0,
            paciente : { pacienteID : "", pacienteFullName : ""},
            tipoCita : { tipoCitaID : 0, tipoCitaNombre : ""},
            activa : false, 
            fechaCita : new Date()
        };
        // for (let prop in c) {
        //     console.log(c)
        //     cita[prop] = c[prop];
        // }
        return cita;
    }

    cancelCita(cita: Cita) {
        this.selectedCita = cita;
        console.log("citaSeleccionada: ", this.selectedCita)
        // let index = this.citas.indexOf(this.selectedCita);

        this.citaService.CancelCita(this.selectedCita.citaID).subscribe(
            data => {
                //this.router.navigate([this.returnUrl]);
            },
            error => {
                this.error = error;
                this.hayError = true;
                setTimeout(() => {
                    this.hayError = false;
                 }, 3000);
            });
    }
}