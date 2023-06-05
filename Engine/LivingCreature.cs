namespace Engine
{
    public class LivingCreature
    {
        public int HpAtual { get; set; }
        public int HpMaximo { get; set; }

        public LivingCreature(int hpAtual, int hpMaximo)
        {
            HpAtual = hpAtual;
            HpMaximo = hpMaximo;
        }
    }
}