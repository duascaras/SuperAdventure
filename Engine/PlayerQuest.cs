namespace Engine
{
    public class PlayerQuest
    {
        public Quest Detalhes { get; set; }
        public bool Finalizada { get; set; }

        public PlayerQuest(Quest detalhes)
        {
            Detalhes = detalhes;
            Finalizada = false;
        }
    }
}