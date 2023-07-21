import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-investimento',
  templateUrl: './investimento.component.html',
  styleUrls: ['./investimento.component.css']
})
export class InvestimentoComponent {
  valorMonetario: number = 0;
  prazoMeses: number = 1;
  resultadoBruto: number | undefined;
  resultadoLiquido: number | undefined;

  constructor(private http: HttpClient) { }

  calcularInvestimento() {
    if (this.valorMonetario <= 0 || this.prazoMeses < 1) {
      alert('Por favor, insira um valor monetário positivo e um prazo maior que 1 mês.');
      return;
    }

    const url = 'https://localhost:44381/api/cdb/calcular';
    const basicAuth = btoa('teste:b3');
    const headers = new HttpHeaders().set('Authorization', 'Basic ' + basicAuth);

    const requestData = {
      valor: this.valorMonetario,
      prazo: this.prazoMeses
    };

    this.http.post<any>(url, requestData, { headers }).subscribe({
      next: data => {
        this.resultadoBruto = data.resultadoBruto;
        this.resultadoLiquido = data.resultadoLiquido;
      },
      error: error => {
        console.error('Erro ao calcular investimento:', error);
        alert('Ocorreu um erro ao calcular o investimento. Verifique os valores informados e tente novamente.');
      }
    });
  }
}
