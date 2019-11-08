import { Paciente } from "./paciente";
import { TipoCita } from "./tipoCita";

export class Cita {
    citaID: number;
    paciente: Paciente;
    tipoCita: TipoCita;
    activa: boolean;
    fechaCita: Date;
}
