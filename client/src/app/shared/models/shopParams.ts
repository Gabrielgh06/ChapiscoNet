export class ShopParams{
    sizes: string[] = [];
    categories: string[] = [];
    sort?: 'name';
    pageNumer = 1;
    pageSize = 10;
    search = '';
}