import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [];


// const routes: Routes = [
//   { path: '', pathMatch: 'full', redirectTo: 'login' },
//   { path: 'login', component: LoginComponent },
//   //{ path: 'register', component: RegisterComponent }
// ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
