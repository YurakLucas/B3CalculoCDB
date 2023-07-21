import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvestimentoComponent } from './investimento/investimento.component';

const appRoutes: Routes = [
  { path: '', component: InvestimentoComponent }, // Rota padrão
  { path: 'investimento', component: InvestimentoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
