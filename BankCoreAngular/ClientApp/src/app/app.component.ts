import { Component } from '@angular/core';
import { CloudData, CloudOptions } from 'angular-tag-cloud-module';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  options: CloudOptions = {
    // if width is between 0 and 1 it will be set to the size of the upper element multiplied by the value 
    width: 300,
    height: 800,
    overflow: true,
  }

  data: CloudData[] = [
    { text: 'Weight-8-link-color', weight: 8, link: 'https://google.com', color: '#ffaaee' },
    { text: 'Weight-10-link', weight: 10, link: 'https://google.com' },
    { text: 'Weight-9-link', weight: 9, link: 'https://google.com' },
    { text: 'Weight-8-link', weight: 8, link: 'https://google.com' },
    { text: 'Weight-7-link', weight: 7, link: 'https://google.com' },
    { text: 'Weight-6-link', weight: 6, link: 'https://google.com' },
    { text: 'Weight-5-link', weight: 5, link: 'https://google.com' },
    { text: 'Weight-4-link', weight: 4, link: 'https://google.com' },
    { text: 'Weight-4-link', weight: 4, link: 'https://google.com' },
    { text: 'Weight-4-link', weight: 4, link: 'https://google.com' },
    { text: 'Weight-4-link', weight: 4, link: 'https://google.com' },
    { text: 'Weight-3-link', weight: 3, link: 'https://google.com' },
    { text: 'Weight-2-link', weight: 2, link: 'https://google.com' },
    { text: 'Weight-1-link', weight: 1, link: 'https://google.com' },
    // ...
  ]
}
