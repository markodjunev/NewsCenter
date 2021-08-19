import { ICommentDetails } from "../comments/ICommentDetails";

export interface IArticleDetails{
    id: number;
    title: string;
    imageUrl: string;
    content: string;
    createdOn: Date;
    comments: Array<ICommentDetails>;
}