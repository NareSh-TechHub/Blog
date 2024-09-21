import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { BlogPostService } from '../services/blog-post.service';
import { BlogPost } from '../models/blog-post.model';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';
import { UpdateBlogPost } from '../models/update-blog-post-model';

@Component({
  selector: 'app-edit-blogpost',
  templateUrl: './edit-blogpost.component.html',
  styleUrls: ['./edit-blogpost.component.css']
})
export class EditBlogpostComponent implements OnInit,OnDestroy {
  id : string| null = null;
  model? : BlogPost;
  categories$? : Observable<Category[]>;
  selectedCategories? : string[];

  routeSubscription? : Subscription;
  updateBlogPostSubscription ? : Subscription;
  getBlogPostSubscription ? : Subscription;
  deleteBlogPostSubscription ? : Subscription;

  constructor(private route : ActivatedRoute,
    private blogPostService : BlogPostService,
    private categoryService : CategoryService,
    private router : Router
  ){

  }
  
  ngOnInit(): void {
    this.categories$ = this.categoryService.getCategories();

    this.routeSubscription = this.route.paramMap
    .subscribe({
      next : (params) => {
       this.id = params.get('id');

       //Get BlogPost from API based on Id
       if(this.id)
       {
        this.getBlogPostSubscription = this.blogPostService.getBlogPostById(this.id).subscribe({
          next : (response) => {
            this.model = response;

            //Mapping the categories associated with Blog post with local variable
            this.selectedCategories = response.categories.map(x=>x.id);
          }
        })
       }
      }
    });
  }

  onFormSubmit(): void {
    if(this.model && this.id)
    {
      var updatedBlogPost : UpdateBlogPost = {
        author : this.model.author,
        content : this.model.content,
        featuredImageUrl : this.model.featuredImageUrl,
        publishedDate : this.model.publishedDate,
        isVisible : this.model.isVisible,
        shortDescription : this.model.shortDescription,
        title : this.model.title,
        urlHandle : this.model.urlHandle,
        categories : this.selectedCategories ?? []
      }

      this.updateBlogPostSubscription = this.blogPostService.updateBlogPost(this.id,updatedBlogPost).subscribe({
        next : (response) => {
          this.router.navigateByUrl('/admin/blogposts')
        }
      })
    }
  }

  onDelete() : void {
    if(this.id){
      this.deleteBlogPostSubscription = this.blogPostService.deleteBlogPost(this.id).subscribe({
        next : (response) => {
          this.router.navigateByUrl('/admin/blogposts')
        }
      });
    }
    
  }


  ngOnDestroy(): void {
    this.routeSubscription?.unsubscribe();
    this.updateBlogPostSubscription?.unsubscribe();
    this.getBlogPostSubscription?.unsubscribe();
    this.deleteBlogPostSubscription?.unsubscribe();
  }

}
