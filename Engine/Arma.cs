namespace Engine
{
    public class Arma : Item
    {
        public int DanoMinimo { get; set; }
        public int DanoMaximo { get; set; }

        public Arma(int id, string nome, string namePlural, int danoMinimo, int danoMaximo) : base(id, nome, namePlural)
        {
            DanoMinimo = danoMinimo;
            DanoMaximo = danoMaximo;
        }
    }
}