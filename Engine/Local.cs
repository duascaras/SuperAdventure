namespace Engine
{
    public class Local
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Item ItemNecessarioParaEntrar { get; set; }
        public Quest MissaoDisponivel { get; set; }
        public Monstro MonstroNolocal { get; set; }
        public Local LocalParaCima { get; set; }
        public Local LocalParaDireita { get; set; }
        public Local LocalParaBaixo { get; set; }
        public Local LocalParaEsquerda { get; set; }

        public Local(int id, string nome, string descricao, Item itemNecessarioParaEntrar = null, Quest missaoDisponivel = null, Monstro monstroNolocal = null)
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