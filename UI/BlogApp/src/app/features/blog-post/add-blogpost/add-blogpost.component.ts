import { Component, OnInit } from '@angular/core';
import { AddBlogPost } from '../models/add-blog-post.model';
import { BlogPostService } from '../services/blog-post.service';
import { Router } from '@angular/router';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnInit {
  model : AddBlogPost;
  categories$ ? : Observable<Category[]>;
  constructor(private blogpostSerive : BlogPostService,
    private router : Router,
    private categoryService : CategoryService){
    this.model = {
      title : '',
      shortDescription : '',
      featuredImageUrl : '',
      urlHandle : '',
      content : '',
      author : '',
      publishedDate : new Date(),
      isVisible : true,
      categories : []
    }
  }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getCategories();
  }

  onFormSubmit() : void {
    this.blogpostSerive.createBlogPost(this.model)
    .subscribe({
      next : (response) => {
        this.router.navigateByUrl('/admin/blogposts');
      }
    });
  }

}
