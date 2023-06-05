namespace Engine
{
    public class PocaoDeVida : Item
    {
        public int QuantidadeDeHeal { get; set; }

        public PocaoDeVida(int id, string nome, string namePlural, int quantidadeDeHeal) : base(id, nome, namePlural) //todo -> checar a necessidade de namePlural 
        {
            QuantidadeDeHeal = quantidadeDeHeal;
        }
    }
}