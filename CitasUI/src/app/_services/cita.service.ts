import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Cita } from '../_models';

@Injectable({ providedIn: 'root' })
export class CitaService {
    constructor(private http: HttpClient) { }

    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }

    cancelCita(citaID: number) {
        
        return this.http.put<any>(`${environment.apiUrl}/citas/CancelCita/${citaID}`, this.httpOptions);
    }

    GetCitasByPacienteId(pacienteID: string) {
        return this.http.get<Cita[]>(`${environment.apiUrl}/citas/GetCitasByPacienteId/${pacienteID}`);
    }
    
}