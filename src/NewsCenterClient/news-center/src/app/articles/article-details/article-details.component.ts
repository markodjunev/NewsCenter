import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IArticleDetails } from '../../models/articles/IArticleDetails';
import { ArticlesService } from '../../services/articles/articles.service';
import { LikeCommentsService } from '../../services/likeComments/like-comments.service';

@Component({
  selector: 'app-article-details',
  templateUrl: './article-details.component.html',
  styleUrls: ['./article-details.component.css']
})
export class ArticleDetailsComponent implements OnInit {
  id: number;
  article: IArticleDetails

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private articlesService: ArticlesService,
    private likeCommentsService: LikeCommentsService,
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.fetchArticle();
  }

  fetchArticle(){
    this.articlesService.details(this.id).subscribe(data => {
      this.article = data;
    });
  }

  like(id: number){
    this.likeCommentsService.like(id).subscribe(data =>
      this.fetchArticle()
    );
  }

  dislike(id: number){
    this.likeCommentsService.dislike(id).subscribe(data =>
      this.fetchArticle()
    );
  }
}
