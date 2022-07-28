export interface IBasis {
    Category: string;
    Incidents: number;
    Id: number;
}  

export interface IBasisUpdate {
    Category?: string;
    Incidents?: number;
}

export interface IBasisCreate {
    Category?: string;
    Incidents?: number;
}
