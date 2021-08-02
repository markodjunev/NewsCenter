﻿namespace NewsCenter.Web.ViewModels.ViewModels.Articles.OutputViewModels
{
    using System.Collections.Generic;

    public class ArticlesViewModel
    {
        public IEnumerable<AllArticlesByCategory> AllArticlesByCategory { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public int ArticlesCount { get; set; }

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.PagesCount ? this.PagesCount : this.CurrentPage + 1;
    }
}
