import { IArticle } from '@/interfaces/article/index';
// I consider this the front end interface local data we get stuff from database and it is stored here for faster access
export interface ArticleState {
    articles: IArticle[];
}
