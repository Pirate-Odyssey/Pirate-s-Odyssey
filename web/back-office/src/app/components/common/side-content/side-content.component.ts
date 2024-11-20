import {
  Component,
  OnDestroy,
  TemplateRef,
  inject,
  viewChild
} from '@angular/core';
import { toObservable } from '@angular/core/rxjs-interop';

import { SideContentService } from '../../../services/side-content.service';

@Component({
    selector: 'bo-side-content',
    imports: [],
    templateUrl: './side-content.component.html',
    styleUrl: './side-content.component.scss'
})
export class SideContentComponent implements OnDestroy {
  private readonly sideContentService = inject(SideContentService);

  public ref = viewChild<TemplateRef<any>>('ref');
  private ref$ = toObservable(this.ref);

  constructor() {
    this.ref$.subscribe({
      next: (ref) => this.sideContentService.ref.set(ref ?? null)
    });
  }

  ngOnDestroy(): void {
    this.sideContentService.ref.set(null);
  }
}
