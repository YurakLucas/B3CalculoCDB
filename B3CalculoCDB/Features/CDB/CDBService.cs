using B3CalculoCDB.Models;
using MediatR;
using System;

namespace B3CalculoCDB.Features.CDB
{
    public interface ICdbService
    {
        InvestimentoResponse CalcularInvestimento(InvestimentoRequest request);
    }

    public class CdbService : ICdbService
    {
        private const double CDI = 0.009;
        private const double TB = 1.08;

        public InvestimentoResponse CalcularInvestimento(InvestimentoRequest request)
        {

            double valorAtual = request.Valor;
            int prazo = request.Prazo;

            double resultadoBruto = Math.Round(valorAtual + CalcularCDB(valorAtual, prazo), 2);

            double rendimento = resultadoBruto - valorAtual;

            double resultadoLiquido = (Math.Round(resultadoBruto - CalcularImposto(rendimento, prazo), 2));

            var response = new InvestimentoResponse
            {
                ResultadoBruto = resultadoBruto,
                ResultadoLiquido = resultadoLiquido
            };

            return response;
        }
     
        public double CalcularCDB(double valorInicial, int meses)
        {
            double VI = valorInicial;

            double VF = VI;

            for (int i = 0; i < meses; i++)
            {
                VF *= (1 + (CDI * TB));
            }

            double lucro = VF - VI;

            return lucro;
        }

        public double CalcularImposto(double rendimento, int meses)
        {
            double imposto;

            if (meses <= 6)
            {
                imposto = rendimento * 0.225;
            }
            else if (meses <= 12)
            {
                imposto = rendimento * 0.20;
            }
            else if (meses <= 24)
            {
                imposto = rendimento * 0.175;
            }
            else
            {
                imposto = rendimento * 0.15;
            }

            return imposto;
        }

    }
}
