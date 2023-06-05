namespace Engine
{
    public class Monster : LivingCreature
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int DanoMaximo { get; set; }
        public int RecompensaExperiencia { get; set; }
        public int RecompensaOuro { get; set; }
        public List<LootItem> Loot { get; set; }

        public Monster(int id, string nome, int danoMaximo, int recompensaExperiencia, int recompensaOuro, int hpAtual, int hpMaximo) : base(hpAtual, hpMaximo)
        {
            ID = id;
            Nome = nome;
            DanoMaximo = danoMaximo;
            RecompensaExperiencia = recompensaExperiencia;
            RecompensaOuro = recompensaOuro;
            Loot = new List<LootItem>();
        }
    }
}