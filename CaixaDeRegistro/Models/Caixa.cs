using System;
using System.Collections.Generic;

namespace CaixaDeRegistro.Models
{
    public class Caixa
    {
        public int Id { get; private set; }
        public List<Moeda> Moedas { get; private set; }
        public double Saldo { get; private set; }

        public void ObterSaldo()
        {
            foreach (var item in Moedas)
            {
                Saldo += item.Quantidade * item.Valor;
            }
        }

        public string ObterTroco(double valorDaCompra, double pagamento)
        {
            int[] centavos = { 100, 50, 25, 10, 5, 1 };
            string result;
            int i, vlr, ct;

            var troco = pagamento - valorDaCompra;
            result = "\nTroco = R$" + troco + "\n\n";

            result = result + "\n";

            vlr = (int)Math.Round((troco - (int)troco) * 100);
            i = 0;
            while( vlr != 0)
            {
                ct = vlr / centavos[i];
                if(ct != 0)
                {
                    result = result + (ct + "moeda(s) de" + centavos[i] + "centavo(s) \n");
                }
                i = i + 1;
            }
            return (result);
        }
    }
}
