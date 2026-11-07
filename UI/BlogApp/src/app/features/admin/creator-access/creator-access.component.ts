import { Component } from '@angular/core';

@Component({
  selector: 'app-creator-access',
  templateUrl: './creator-access.component.html',
  styleUrls: ['./creator-access.component.css']
})
export class CreatorAccessComponent {
  readonly requests = [
    { name: 'John Smith', dateRequested: '1/15/2025' },
    { name: 'Sarah Johnson', dateRequested: '1/14/2025' }
  ];
}
