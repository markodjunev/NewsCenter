export interface ICommentDetails{
    id: number;
    content: string;
    articleId: number;
    parentCommentId: number;
    creatorId: string,
    creatorUserName: string,
    createdOn: Date;
    isLiked: boolean;
    likesCount: number;
}