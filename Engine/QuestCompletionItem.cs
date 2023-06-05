namespace Engine
{
    public class QuestCompletionItem
    {
        public Item Detalhes { get; set; }
        public int Quantidade { get; set; }

        public QuestCompletionItem(Item detalhes, int quantidade)
        {
            Detalhes = detalhes;
            Quantidade = quantidade;
        }
    }
}