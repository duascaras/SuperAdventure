namespace Engine
{
    public class LootItem
    {
        public Item Detalhes { get; set; }
        public int PorcentagemDrop { get; set; }
        public bool ItemPadrao { get; set; }

        public LootItem(Item detalhes, int porcentagemDrop, bool itemPadrao)
        {
            Detalhes = detalhes;
            PorcentagemDrop = porcentagemDrop;
            ItemPadrao = itemPadrao;
        }
    }
}