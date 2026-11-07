import { Component } from '@angular/core';
import { Category } from '../../category/models/category.model';

@Component({
  selector: 'app-admin-category-list',
  templateUrl: './admin-category-list.component.html',
  styleUrls: ['./admin-category-list.component.css']
})
export class AdminCategoryListComponent {
  readonly categories: Category[] = [
    {
      id: 'technology',
      categoryName: 'Technology',
      description: 'Technology articles and updates.',
      urlHandle: 'technology'
    },
    {
      id: 'travel',
      categoryName: 'Travel',
      description: 'Travel stories and destination guides.',
      urlHandle: 'travel'
    }
  ];
}
