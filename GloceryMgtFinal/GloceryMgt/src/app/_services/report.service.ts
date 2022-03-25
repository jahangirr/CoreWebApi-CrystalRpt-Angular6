import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Report } from '../_models/report';
import { globalcomponet } from '../globalComponent';



@Injectable({
  providedIn: 'root'
})
export class ReportService {

  http: HttpClient;
  constructor(private _http: HttpClient) { 
   this.http = _http;
  }

   GetPdf(reportName : String  , userName : String )
   {
        let  url  = globalcomponet.apiUrl+"/api/Report/Report/"+reportName+"/"+userName;
         return this.http.get<Report>(url);
   }

   
  


}
