import { IArticleByCategory } from "./IArticleByCategory";

export interface ICategoryDetails {
    allArticlesByCategory: Array<IArticleByCategory>;
    articlesCount: number;
    currentPage: number;
    nextPage: number;
    pagesCount: number;
    previousPage: number;
}