import { Routes, RouterModule } from '@angular/router';
import { ReportComponent } from '../app/report/report.component';
import {AppComponent} from '../app/app.component'


const appRoutes: Routes = [
    { path: 'showReport', component: ReportComponent  }
];

export const routing = RouterModule.forRoot(appRoutes);