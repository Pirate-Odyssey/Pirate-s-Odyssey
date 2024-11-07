import { TestBed } from '@angular/core/testing';

import { SideContentService } from './side-content.service';

describe('SideContentService', () => {
  let service: SideContentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SideContentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
