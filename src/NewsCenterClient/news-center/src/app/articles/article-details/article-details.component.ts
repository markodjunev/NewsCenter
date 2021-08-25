import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogCreateCommentComponent } from 'src/app/material/dialog-create-comment/dialog-create-comment.component';
import { ICreateComment } from 'src/app/models/comments/ICreateComment';
import { CommentsService } from 'src/app/services/comments/comments.service';
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
  article: IArticleDetails;
  content: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private articlesService: ArticlesService,
    private likeCommentsService: LikeCommentsService,
    private dialog: MatDialog,
    private commentsService: CommentsService,
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.fetchArticle();
  }

  fetchArticle() {
    this.articlesService.details(this.id).subscribe(data => {
      this.article = data;
    });
  }

  like(id: number) {
    this.likeCommentsService.like(id).subscribe(data =>
      this.fetchArticle()
    );
  }

  dislike(id: number) {
    this.likeCommentsService.dislike(id).subscribe(data =>
      this.fetchArticle()
    );
  }

  openDialog() {
    let dialogRef = this.dialog.open(DialogCreateCommentComponent, {
      data: { content: this.content }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.content = result;
      if(this.content?.length > 0){
        const comment: ICreateComment = Object.assign({}, { content: this.content, articleId: this.id });
        this.commentsService.create(comment).subscribe(data => {
          this.fetchArticle();
        });
        this.content = '';
      }
    });
  }
}
