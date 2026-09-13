export interface AddBlogPost {
    title : string;
    shortDescription : string;
    content : string;
    featuredImageUrl : string;
    urlHandle : string;
    userId : string;
    publishedDate : Date;
    isVisible : boolean;
    categories : string[];
} 