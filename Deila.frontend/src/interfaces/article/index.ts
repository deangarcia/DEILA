export interface IArticle {
    id: number;
    title: string;
    content: string;
    basis: number;
    origin: string;
    sentiment: boolean;
}
export interface IArticleCreate {
    title: string;
    content: string;
    basis: number;
    origin: string;
    sentiment: boolean;
}

export interface IArticleUpdate {
    title?: string;
    content?: string;
    basis?: number;
    origin?: string;
    sentiment?: boolean;
}
