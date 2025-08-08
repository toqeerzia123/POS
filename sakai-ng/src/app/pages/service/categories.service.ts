import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface InventoryStatus {
    label: string;
    value: string;
}

export interface Category {
  name: string
  imageUrl: string
  description: string
  lastModificationTime: any
  lastModifierUserId: any
  creatorUserId: any
  id: string
}
export interface AbpResponse<T> {
  result: T;
  success: boolean;
  error: any;
  unAuthorizedRequest: boolean;
  __abp: boolean;
}
@Injectable()
export class CategoryService {
    getProductsData():Observable< AbpResponse<Category[]>> {
        debugger
       return this.http.get<AbpResponse<Category[]>>('https://localhost:44311/api/services/app/Category/GetAll');
      
    }
   getAllCategories():Observable< AbpResponse<Category[]>> {
        debugger
       return this.http.get<AbpResponse<Category[]>>('https://localhost:44311/api/services/app/Category/GetAllParents');
      
    }
       getsubcategoriesbyParentId(parentId:any):Observable< AbpResponse<Category[]>> {
        debugger
       return this.http.get<AbpResponse<Category[]>>('https://localhost:44311/api/services/app/Category/GetClield?parentId=' + parentId);
      
    }
    getProductsWithOrdersData() {
        return [
            {
                id: '1029',
                code: 'gwuby345v',
                name: 'Yoga Set',
                description: 'Product Description',
                image: 'yoga-set.jpg',
                price: 20,
                category: 'Fitness',
                quantity: 25,
                inventoryStatus: 'INSTOCK',
                rating: 8,
                orders: [
                    {
                        id: '1029-0',
                        productCode: 'gwuby345v',
                        date: '2020-02-14',
                        amount: 4,
                        quantity: 80,
                        customer: 'Maryann Royster',
                        status: 'DELIVERED'
                    }
                ]
            }
        ];
    }

    status: string[] = ['OUTOFSTOCK', 'INSTOCK', 'LOWSTOCK'];

    productNames: string[] = [
        'Bamboo Watch',
        'Black Watch',
        'Blue Band',
        'Blue T-Shirt',
        'Bracelet',
        'Brown Purse',
        'Chakra Bracelet',
        'Galaxy Earrings',
        'Game Controller',
        'Gaming Set',
        'Gold Phone Case',
        'Green Earbuds',
        'Green T-Shirt',
        'Grey T-Shirt',
        'Headphones',
        'Light Green T-Shirt',
        'Lime Band',
        'Mini Speakers',
        'Painted Phone Case',
        'Pink Band',
        'Pink Purse',
        'Purple Band',
        'Purple Gemstone Necklace',
        'Purple T-Shirt',
        'Shoes',
        'Sneakers',
        'Teal T-Shirt',
        'Yellow Earbuds',
        'Yoga Mat',
        'Yoga Set'
    ];

    constructor(private http: HttpClient) {}

    getProductsMini() {
        return Promise.resolve(this.getProductsData());
    }

    getProductsSmall() {
        return Promise.resolve(this.getProductsData());
    }

    getProductsWithOrdersSmall() {
        return Promise.resolve(this.getProductsWithOrdersData().slice(0, 10));
    }

    generatePrduct(): Category {
        const product: Category = {
            id: this.generateId(),
            name: this.generateName(),
            description: 'Product Description',
            imageUrl: this.generateName().toLocaleLowerCase().split(/[ ,]+/).join('-') + '.jpg',
            lastModificationTime: new Date().toISOString(),
            lastModifierUserId: null,
            creatorUserId: null
        };
        return product;
    }

    generateId() {
        let text = '';
        let possible = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';

        for (var i = 0; i < 5; i++) {
            text += possible.charAt(Math.floor(Math.random() * possible.length));
        }

        return text;
    }

    generateName() {
        return this.productNames[Math.floor(Math.random() * Math.floor(30))];
    }

    generatePrice() {
        return Math.floor(Math.random() * Math.floor(299) + 1);
    }

    generateQuantity() {
        return Math.floor(Math.random() * Math.floor(75) + 1);
    }

    generateStatus() {
        return this.status[Math.floor(Math.random() * Math.floor(3))];
    }

    generateRating() {
        return Math.floor(Math.random() * Math.floor(5) + 1);
    }
}
