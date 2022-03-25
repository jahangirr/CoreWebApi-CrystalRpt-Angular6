import { Component, OnInit } from '@angular/core';
import { ReportService } from '../_services/report.service';
import { Report } from '../_models/report';
import { first } from 'rxjs/operators';
import { fail } from 'assert';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  report : Report;

  constructor(private _ReportService : ReportService) {

   }

  ngOnInit() {

  }


  downloadPdf(base64String, fileName){

    const source = `data:application/pdf;base64,${base64String}`;
    const link = document.createElement("a");
    link.href = source;
    link.download = `${fileName}.pdf`
    link.click();
  
  }

  _repName : String ;
  _userName : String ;
  _stratOperation : Boolean = false ;
    onClickDownloadPdf(){


      alert("Start downloading...");

      this._stratOperation = true;

      // Milton : I created a CrystalReport;
      // Jahangir : is the user Name
      this._repName = "Milton";
      this._userName = "Jahangir";

       this._ReportService.GetPdf(this._repName , this._userName )
      .pipe(first()).subscribe(data => {

         this.report = data;
         let base64String = this.report.reportData;
         this.downloadPdf(base64String, this._repName+"_"+this._userName );

      });

      this._stratOperation = false;

   
    }


}
