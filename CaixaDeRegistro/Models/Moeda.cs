namespace CaixaDeRegistro.Models
{
    public class Moeda
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        public int Quantidade { get; private set; }
        public int CaixaId { get; set; }
        public Caixa Caixa { get; private set; }
    }
}
