import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { CitaComponent } from './cita';
import { AdminComponent } from './admin';
import { LoginComponent } from './login';
import { Role } from './_models';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
    },
    {
        path: 'cita',
        component: CitaComponent
    },
    {
        path: 'admin',
        component: AdminComponent,
        data: { roles: [Role.Admin] }
    },
    {
        path: 'login',
        component: LoginComponent
    },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
