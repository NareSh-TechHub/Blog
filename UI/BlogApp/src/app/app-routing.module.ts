import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCategoryComponent } from './features/category/add-category/add-category.component';
import { EditCategoryComponent } from './features/category/edit-category/edit-category.component';
import { AddBlogpostComponent } from './features/blog-post/add-blogpost/add-blogpost.component';
import { EditBlogpostComponent } from './features/blog-post/edit-blogpost/edit-blogpost.component';
import { LoginComponent } from './features/auth/login/login.component';
import { RegisterComponent } from './features/auth/register/register.component';
import { LandingComponent } from './features/landing/landing.component';
import { AdminDashboardComponent } from './features/admin/admin-dashboard/admin-dashboard.component';
import { CreatorAccessComponent } from './features/admin/creator-access/creator-access.component';
import { AdminBlogPostListComponent } from './features/admin/blog-post-list/admin-blog-post-list.component';
import { AdminCategoryListComponent } from './features/admin/category-list/admin-category-list.component';

const routes: Routes = [
  {
    path: 'admin',
    component: AdminDashboardComponent,
    children: [
      {
        path: '',
        redirectTo: 'blogposts',
        pathMatch: 'full'
      },
      {
        path: 'categories/add',
        component: AddCategoryComponent
      },
      {
        path: 'categories/:id',
        component: EditCategoryComponent
      },
      {
        path: 'blogposts/add',
        component: AddBlogpostComponent
      },
      {
        path: 'blogposts/:id',
        component: EditBlogpostComponent
      },
      {
        path: 'categories',
        component: AdminCategoryListComponent
      },
      {
        path: 'blogposts',
        component: AdminBlogPostListComponent
      },
      {
        path: 'creator-access',
        component: CreatorAccessComponent
      }
    ]
  },
  { 
    path: 'login', 
    component: LoginComponent 
  },
  { 
    path: 'register', 
    component: RegisterComponent 
  },
  { 
    path: '', 
    component: LandingComponent 
  },
  { 
    path: '**', 
    redirectTo: '' 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
