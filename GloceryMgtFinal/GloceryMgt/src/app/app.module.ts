import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule }    from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {ReportComponent} from './report/report.component';
import { ReportService } from  './_services/report.service'
import { routing }        from './app.routing';

// used to create fake backend

import { AppComponent }  from './app.component';
import { MenuComponetComponent } from './menu-componet/menu-componet.component';



@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        routing

    ],
    declarations: [
        AppComponent,
      
  ReportComponent,
      
  MenuComponetComponent
    ],
    providers: [
       
        ReportService
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }