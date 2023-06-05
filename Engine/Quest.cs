namespace Engine
{
    public class Quest
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int RecompensaExperiencia { get; set; }
        public int RecompensaOuro { get; set; }
        public Item RecompensaItem { get; set; }
        public List<QuestCompletionItem> ItensMissaoCompleta { get; set; }

        public Quest(int id, string nome, string description, int recompensaExperiencia, int recompensaOuro)
        {
            ID = id;
            Nome = nome;
            Descricao = description;
            RecompensaExperiencia = recompensaExperiencia;
            RecompensaOuro = recompensaOuro;
            ItensMissaoCompleta = new List<QuestCompletionItem>();
        }
    }
}