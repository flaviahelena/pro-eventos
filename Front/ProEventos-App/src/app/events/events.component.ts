import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  public events: any = [];
  public filterEvents: any = [];
  widthImg: number = 150;
  marginImg: number =2;
  showImg: boolean = true;
  private _listFilter: string = '';

  public get listFilter(): string {
    return this._listFilter;
  }
  public set listFilter(value: string){
    this._listFilter = value;
    this.filterEvents = this._listFilter ? this.eventFilter(this.listFilter) : this.events;
  }
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEvents();
  }

  handleStatusImage(){
    this.showImg = !this.showImg;
  }

  eventFilter(filterBy: string): any{
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event: any) => event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      event.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    )
  }
  public getEvents(): void {

    this.http.get('https://localhost:5001/api/events').subscribe(
      response => {
        this.events = response
        this.filterEvents = this.events
      },
      error => console.log(error)
    );
  }
}
