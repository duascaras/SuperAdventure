namespace Engine
{
    public class Location
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Item ItemNecessarioParaEntrar { get; set; }
        public Quest MissaoDisponivel { get; set; }
        public Monster MonstroNolocal { get; set; }
        public Location LocalParaCima { get; set; }
        public Location LocalParaDireita { get; set; }
        public Location LocalParaBaixo { get; set; }
        public Location LocalParaEsquerda { get; set; }

        public Location(int id, string nome, string descricao, Item itemNecessarioParaEntrar = null, Quest missaoDisponivel = null, Monster monstroNolocal = null)
        {
            ID = id;
            Nome = nome;
            Descricao = descricao;
            ItemNecessarioParaEntrar = itemNecessarioParaEntrar;
            MissaoDisponivel = missaoDisponivel;
            MonstroNolocal = monstroNolocal;
        }
    }
}