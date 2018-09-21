import { Component } from '@angular/core';
import { CloudData, CloudOptions } from 'angular-tag-cloud-module';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
 options: CloudOptions = {
    // if width is between 0 and 1 it will be set to the size of the upper element multiplied by the value 
    width: 500,
    height: 400,
    overflow: true,
  }

  data: CloudData[] = [
    { text: 'Weight-8-link-color', weight: 8, link: 'https://google.com', color: '#ffaaee' },
    { text: 'Weight-10-link', weight: 10, link: 'https://google.com' },
    { text: 'Weight-10-link', weight: 9, link: 'https://google.com' },
    { text: 'Weight-10-link', weight: 8, link: 'https://google.com' },
    { text: 'Weight-10-link', weight: 7, link: 'https://google.com' },
    { text: 'Weight-10-link', weight: 6, link: 'https://google.com' },
    { text: 'Weight-10-link', weight: 5, link: 'https://google.com' },
    // ...
  ]
}
