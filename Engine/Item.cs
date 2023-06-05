namespace Engine
{
    public class Item
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NamePlural { get; set; } //todo -> verificar a necessidade dessa prop

        public Item(int id, string nome, string namePlural)
        {
            ID = id;
            Nome = nome;
            NamePlural = namePlural;
        }
    }
}