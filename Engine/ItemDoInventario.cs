namespace Engine
{
    public class ItemDeInventario
    {
        public Item Detalhes { get; set; }
        public int Quantidade { get; set; }

        public ItemDeInventario(Item detalhes, int quantidade)
        {
            Detalhes = detalhes;
            Quantidade = quantidade;
        }
    }
}