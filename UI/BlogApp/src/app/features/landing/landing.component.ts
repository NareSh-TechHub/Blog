import { Component, ElementRef, ViewChild } from '@angular/core';
import { Category } from '../category/models/category.model';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent {
  @ViewChild('categoryTrack') private categoryTrack?: ElementRef<HTMLDivElement>;

  categories: Category[] = [
    {
      id: 'art-culture',
      categoryName: 'Art & Culture',
      description: 'Discover interesting articles about art & culture.',
      urlHandle: 'art-culture'
    },
    {
      id: 'food-drinks',
      categoryName: 'Food & Drinks',
      description: 'Discover interesting articles about food & drinks.',
      urlHandle: 'food-drinks'
    },
    {
      id: 'health',
      categoryName: 'Health',
      description: 'Discover interesting articles about health and wellbeing.',
      urlHandle: 'health'
    },
    {
      id: 'travel',
      categoryName: 'Travel',
      description: 'Explore destinations, travel tips, and memorable journeys.',
      urlHandle: 'travel'
    },
    {
      id: 'technology',
      categoryName: 'Technology',
      description: 'Ideas and stories about the technology shaping our lives.',
      urlHandle: 'technology'
    },
    {
      id: 'lifestyle',
      categoryName: 'Lifestyle',
      description: 'Fresh perspectives on everyday living and finding balance.',
      urlHandle: 'lifestyle'
    }
  ];

  scrollCategories(direction: -1 | 1): void {
    this.categoryTrack?.nativeElement.scrollBy({
      left: direction * 340,
      behavior: 'smooth'
    });
  }

}
