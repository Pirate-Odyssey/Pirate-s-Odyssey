import { Injectable, TemplateRef, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SideContentService {
  public ref = signal<TemplateRef<any> | null>(null);
}
