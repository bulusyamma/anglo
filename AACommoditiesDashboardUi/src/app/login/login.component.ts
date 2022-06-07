import { Input, Component, Output, EventEmitter } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent {
  public readonly form: FormGroup;

  @Input() error: string | null = null;
  @Output() submitEvent = new EventEmitter();

  public constructor() {
    this.form = new FormGroup({
      username: new FormControl(""),
      password: new FormControl(""),
    });
  }

  submit() {
    if (this.form.valid) {
      this.submitEvent.emit(this.form.value);
    }
  }
}
