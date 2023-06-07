namespace Engine
{
    public class CriaturaViva
    {
        public int HpAtual { get; set; }
        public int HpMaximo { get; set; }

        public CriaturaViva(int hpAtual, int hpMaximo)
        {
            HpAtual = hpAtual;
            HpMaximo = hpMaximo;
        }
    }
}