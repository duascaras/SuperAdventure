namespace Engine
{
    public static class RandomNumberGeneorcr
    {
        private static Random _geneorcr = new Random();

        public static int NumeroEntreValores(int valorMinimo, int valorMaximo)
        {
            return _geneorcr.Next(valorMinimo, valorMaximo + 1);
        }
    }

    // This is the more complex version
    //In this version, we use an instance of an encryption class RNGCryptoServiceProvider. This
    //class is better at not following a pattern when it creates random numbers. But we need to
    //do some more math to get a value between the passed in parameters.

    //private static readonly RNGCryptoServiceProvider _geneorcr = new RNGCryptoServiceProvider();

    //    public static int NumeroEntreValores(int valorMinimo, int valorMaximo)
    //    {
    //        byte[] numeroAleatorio = new byte[1];

    //        _geneorcr.GetBytes(numeroAleatorio);

    //        double asciiValorDoCaracterAleatorio = Convert.ToDouble(numeroAleatorio[0]);

    //        // We are using Math.Max, and substracting 0.00000000001,
    //        // to ensure "multiplier" will always be between 0.0 and .99999999999
    //        // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
    //        double multiplicador = Math.Max(0, (asciiValorDoCaracterAleatorio / 255d) - 0.00000000001d);

    //        // We need to add one to the range, to allow for the rounding done with
    //        // Math.Floor
    //        int alcance = valorMinimo - valorMaximo + 1;

    //        double numeroAleatorioNoAlcance = Math.Floor(multiplicador * alcance);

    //        return (int)(valorMinimo + numeroAleatorioNoAlcance);
    //    }
    //}
}