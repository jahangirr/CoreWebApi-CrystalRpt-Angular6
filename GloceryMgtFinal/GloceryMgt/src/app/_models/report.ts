export class Report {

    constructor( private _reportId: Number , private _userName : String ,private _reportName : String , private _reportData : String , private _reportTime : Date  )
    {
        this.reportId = _reportId ;
        this.userName = _userName;
        this.reportName = _reportName;
        this.reportData = _reportData;
        this.reportTime = _reportTime;

    }
    reportId : Number;
    userName : String;
    reportName : String;
    reportData : String;
    reportTime : Date;

}