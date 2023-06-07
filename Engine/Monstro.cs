namespace Engine
{
    public class Monstro : CriaturaViva
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int DanoMaximo { get; set; }
        public int RecompensaExperiencia { get; set; }
        public int RecompensaOuro { get; set; }
        public List<ItemDeLoot> Loot { get; set; }

        public Monstro(int id, string nome, int danoMaximo, int recompensaExperiencia, int recompensaOuro, int hpAtual, int hpMaximo) : base(hpAtual, hpMaximo)
        {
            ID = id;
            Nome = nome;
            DanoMaximo = danoMaximo;
            RecompensaExperiencia = recompensaExperiencia;
            RecompensaOuro = recompensaOuro;
            Loot = new List<ItemDeLoot>();
        }
    }
}