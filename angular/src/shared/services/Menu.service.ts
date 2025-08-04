import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { MenuItem } from '../layout/menu-item';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

constructor(private http: HttpClient) {}

  getMenuItems(): Observable<MenuItem[]> {
    return this.http.get<any[]>('/assets/menu-items.json').pipe(
      map(items => this.buildMenuItems(items))
    );
  }

  private buildMenuItems(data: any[]): MenuItem[] {
    return data.map(item => new MenuItem(
      this.l(item.label),
      item.url,
      item.icon,
      item.permission,
      item.children ? this.buildMenuItems(item.children) : undefined
    ));
  }

  private l(text: string): string {
    // Replace with your localization logic or remove if not needed
    return text;
  }
}
