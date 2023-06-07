namespace Engine
{
    public class ItemDeLoot
    {
        public Item Detalhes { get; set; }
        public int PorcentagemDrop { get; set; }
        public bool ItemPadrao { get; set; }

        public ItemDeLoot(Item detalhes, int porcentagemDrop, bool itemPadrao)
        {
            Detalhes = detalhes;
            PorcentagemDrop = porcentagemDrop;
            ItemPadrao = itemPadrao;
        }
    }
}