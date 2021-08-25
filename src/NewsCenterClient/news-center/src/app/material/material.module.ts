import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import {MatButtonModule} from '@angular/material/button';
import { MatDialogModule } from "@angular/material/dialog";
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { DialogCreateCommentComponent } from './dialog-create-comment/dialog-create-comment.component';


const modules = [
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    FormsModule,
];

@NgModule({
imports: [...modules],
exports: [...modules],
declarations: [
  DialogCreateCommentComponent
]
,
})export class MaterialModule {};