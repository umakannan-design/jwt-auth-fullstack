import { Routes } from '@angular/router';
import { DashboardComponent } from './component/dashboard.component/dashboard.component';
import { LoginComponent } from './component/login.component/login.component';
import { RegisterComponent } from './component/register.component/register.component';
import { AuthGuard } from './guard/auth.guard-guard';

export const routes: Routes = [

  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },

  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard]
  },

  { path: '', redirectTo: 'login', pathMatch: 'full' }
];