import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // Importe esta linha

import { AppComponent } from './app.component';
import { InvestimentoComponent } from './investimento/investimento.component';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    InvestimentoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, // Adicione esta linha
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
