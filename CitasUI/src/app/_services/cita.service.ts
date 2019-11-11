import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Cita, TipoCita } from '../_models';

@Injectable({ providedIn: 'root' })
export class CitaService {
    constructor(private http: HttpClient) { }

    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }

    CancelCita(citaID: number) {
      return this.http.put<void>(`${environment.apiUrl}/citas/CancelCita/${citaID}`, this.httpOptions);
    }

    GetCitasByPacienteId(pacienteID: string) {
      return this.http.get<Cita[]>(`${environment.apiUrl}/citas/GetCitasByPacienteId/${pacienteID}`);
    }

    GetTiposCitas() {
      return this.http.get<TipoCita[]>(`${environment.apiUrl}/citas/GetTiposCitas`);
    }
    
    AddCita(cita: Cita) {
      console.log("CITACTA : ", cita)
      return this.http.post<Cita>(`${environment.apiUrl}/citas/AddCita/`, cita);
    }
}