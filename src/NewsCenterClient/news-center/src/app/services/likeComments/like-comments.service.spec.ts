import { TestBed } from '@angular/core/testing';

import { LikeCommentsService } from './like-comments.service';

describe('LikeCommentsService', () => {
  let service: LikeCommentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LikeCommentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
