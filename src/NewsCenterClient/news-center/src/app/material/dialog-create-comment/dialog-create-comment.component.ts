import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-dialog-create-comment',
  templateUrl: './dialog-create-comment.component.html',
  styleUrls: ['./dialog-create-comment.component.css']
})
export class DialogCreateCommentComponent implements OnInit {

  get username(): any {
    return this.authService.getUsername();
  }

  constructor(
    private authService: AuthService,
    public dialogRef: MatDialogRef<DialogCreateCommentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
