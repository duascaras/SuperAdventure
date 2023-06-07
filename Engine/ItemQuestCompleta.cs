namespace Engine
{
    public class ItemQuestCompleta
    {
        public Item Detalhes { get; set; }
        public int Quantidade { get; set; }

        public ItemQuestCompleta(Item detalhes, int quantidade)
        {
            Detalhes = detalhes;
            Quantidade = quantidade;
        }
    }
}