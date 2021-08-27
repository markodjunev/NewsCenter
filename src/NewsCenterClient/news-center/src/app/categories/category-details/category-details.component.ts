import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArticlesService } from '../../services/articles/articles.service';
import { ICategoryDetails } from '../../models/categories/ICategoryDetails';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.css']
})
export class CategoryDetailsComponent implements OnInit {
  id: number;
  page: number;
  model: ICategoryDetails;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private articlesService: ArticlesService,
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.page = params['page'];
    });

    this.route.queryParams.subscribe(params => {
      this.page = params['page'];
    });

    if (this.page === undefined) {
      this.page = 1;
    }

    this.articlesService.byCategory(this.id, this.page).subscribe(data => {
      this.model = data;
      console.log(this.model);
    });
  }

  array(i: number) {
    return new Array(i);
  }

  changePage(p: number) {
    this.router.navigate(['categories/' + this.id], { queryParams: { page: p } })
      .then(() => {
        window.location.reload();
      });
  }
}
