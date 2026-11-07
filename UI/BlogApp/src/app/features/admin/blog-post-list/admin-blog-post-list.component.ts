import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-blog-post-list',
  templateUrl: './admin-blog-post-list.component.html',
  styleUrls: ['./admin-blog-post-list.component.css']
})
export class AdminBlogPostListComponent {
  readonly posts = [
    { title: 'Sample Post', category: 'Technology', date: '5/31/2025' }
  ];
}
