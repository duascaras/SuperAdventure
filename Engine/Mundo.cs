namespace Engine
{
    public static class Mundo
    {
        //Pagina 51
        /* O propósito da classe World é termos uma classe que possui tudo 
         * do jogo: Monstros que pertencem a um determinado local, items dropados
         * que você pode coletar após matar um monstro e etc.
         * E também conecta os lugartes uns aos outros. */

        public static readonly List<Item> Itens = new List<Item>();
        public static readonly List<Monstro> Monstros = new List<Monstro>();
        public static readonly List<Quest> Missoes = new List<Quest>();
        public static readonly List<Local> Locais = new List<Local>();

        public const int ITEM_ID_ESPADA_ENFERRUJADA = 1;
        public const int ITEM_ID_CHAVE = 2;
        public const int ITEM_ID_OLHO_DE_ORC = 3;
        public const int ITEM_ID_PEDACO_CARNE_PODRE = 4;
        public const int ITEM_ID_PEDACO_DE_CARNE = 5;
        public const int ITEM_ID_PORRETA = 6;
        public const int ITEM_ID_POCAO_DE_CURA = 7;
        public const int ITEM_ID_CABECA = 8;
        public const int ITEM_ID_ESPADA_DE_GAIL = 9;
        public const int ITEM_ID_MOEDA = 10;
        public const int ITEM_ID_MEDALHA_DE_VENCEDOR = 11;

        public const int MONSTER_ID_ORC = 1;
        public const int MONSTER_ID_MORTO_VIVO = 2;
        public const int MONSTER_ID_MUNRAH = 3;
        public const int MONSTER_ID_GAIL = 4;

        public const int QUEST_ID_LUTA_GAIL = 1;
        public const int QUEST_ID_MATAR_ORC = 2;
        public const int QUEST_ID_LUTA_FINAL = 3;

        public const int LOCATION_ID_CASA = 1;
        public const int LOCATION_ID_FLORESTA = 2;
        public const int LOCATION_ID_CENTRO = 3;
        public const int LOCATION_ID_LOJA_DO_GAIL = 4;
        public const int LOCATION_ID_BAR_DO_MOE = 5;
        public const int LOCATION_ID_CAVERNA_DO_ORC = 6;
        public const int LOCATION_ID_CIDADE_ABANDONADA = 7;
        public const int LOCATION_ID_PONTE = 8;
        public const int LOCATION_ID_TORRE_DO_DRAGAO = 9;
        public const int LOCATION_ID_QUINTAL = 10;

        static Mundo()
        {
            PreencherItens();
            PreencherMonstros();
            PreencherQuests();
            PreencherLocais();
        }

        private static void PreencherItens()
        {
            Itens.Add(new Arma(ITEM_ID_ESPADA_ENFERRUJADA, "Espada Enferrujada", "Espada Enferrujadas", 0, 5));
            Itens.Add(new Arma(ITEM_ID_PORRETA, "Porreta", "Porreta", 3, 10));
            Itens.Add(new Arma(ITEM_ID_ESPADA_DE_GAIL, "Espada do Gail", "Espada do Gail", 1, 9));

            Itens.Add(new PocaoDeVida(ITEM_ID_POCAO_DE_CURA, "Poção de Cura", "Poção de Cura", 5));

            Itens.Add(new Item(ITEM_ID_CHAVE, "Chave", "Chave"));
            Itens.Add(new Item(ITEM_ID_OLHO_DE_ORC, "Olho de Orc", "Olho de Orc"));
            Itens.Add(new Item(ITEM_ID_PEDACO_CARNE_PODRE, "Pedaço de Carne Podre", "Pedaço de Carne Podre"));
            Itens.Add(new Item(ITEM_ID_CABECA, "Cabeça de Munrah", "Cabeça de Munrah"));
            Itens.Add(new Item(ITEM_ID_MOEDA, "Moeda", "Moeda"));
            Itens.Add(new Item(ITEM_ID_MEDALHA_DE_VENCEDOR, "Moeda de Vencedor", "Moeda de Vencedor"));
        }

        private static void PreencherMonstros()
        {
            Monstro orc = new Monstro(MONSTER_ID_ORC, "Orc", 5, 3, 10, 4, 4);
            orc.Loot.Add(new ItemDeLoot(ItemByID(ITEM_ID_OLHO_DE_ORC), 75, true));

            Monstro mortoVivo = new Monstro(MONSTER_ID_MORTO_VIVO, "Morto-Vivo", 5, 3, 10, 5, 5);
            mortoVivo.Loot.Add(new ItemDeLoot(ItemByID(ITEM_ID_PEDACO_CARNE_PODRE), 75, false));

            Monstro munrah = new Monstro(MONSTER_ID_MUNRAH, "Munrah", 10, 5, 40, 10, 10);
            munrah.Loot.Add(new ItemDeLoot(ItemByID(ITEM_ID_CABECA), 75, true));

            Monstro gail = new Monstro(MONSTER_ID_GAIL, "Lorthus Gail", 7, 3, 0, 4, 4);
            gail.Loot.Add(new ItemDeLoot(ItemByID(ITEM_ID_MOEDA), 0, true));

            Monstros.Add(orc);
            Monstros.Add(mortoVivo);
            Monstros.Add(munrah);
            Monstros.Add(gail);
        }

        private static void PreencherQuests()
        {
            Quest lutarComGail = new Quest(QUEST_ID_LUTA_GAIL,
                    "Lute com o Gail",
                    "Lute e ganhe de Lorthus Gail. Você receberá uma Poção de Cura e uma espada.", 20, 0);

            lutarComGail.ItensMissaoCompleta.Add(new ItemQuestCompleta(ItemByID(ITEM_ID_MOEDA), 1));

            lutarComGail.RecompensaItem = ItemByID(ITEM_ID_ESPADA_DE_GAIL);

            Quest matarOrc = new Quest(QUEST_ID_MATAR_ORC,
                    "Mate o Orc da Caverna",
                    "Mate o Orc da Caverna e traga de volta 3 olhos de Orc. Você receberá uma Chave e 20 peças de ouro", 20, 20);

            matarOrc.ItensMissaoCompleta.Add(new ItemQuestCompleta(ItemByID(ITEM_ID_OLHO_DE_ORC), 3));

            matarOrc.RecompensaItem = ItemByID(ITEM_ID_CHAVE);

            Quest matarMunrah = new Quest(QUEST_ID_LUTA_FINAL,
                "Mate o Dragão da Torre",
                "Existe um dragão que vive na antiga torre da cidade abandonada. Alguem precisa mata-lo.", 30, 30);

            matarMunrah.ItensMissaoCompleta.Add(new ItemQuestCompleta(ItemByID(ITEM_ID_CABECA), 1));

            matarMunrah.RecompensaItem = ItemByID(ITEM_ID_MEDALHA_DE_VENCEDOR);

            Missoes.Add(matarMunrah);
            Missoes.Add(lutarComGail);
            Missoes.Add(matarOrc);
        }

        private static void PreencherLocais()
        {
            Local casa = new Local(LOCATION_ID_CASA,
                "Casa",
                "Parece tão calmo aqui.");

            Local floresta = new Local(LOCATION_ID_FLORESTA,
                "Floresta",
                "As arvores daqui são realmente belas.");

            Local lojaDoGail = new Local(LOCATION_ID_LOJA_DO_GAIL,
                "Loja do Lorthus Gail",
                "Vamos fazer negocios hoje?");
            lojaDoGail.MissaoDisponivel = QuestByID(QUEST_ID_LUTA_GAIL);

            Local quintalDoGail = new Local(LOCATION_ID_QUINTAL,
                "Quintal do Gail",
                "Você avista um ringue, ele parece fazer isso sempre...");
            quintalDoGail.MonstroNolocal = MonsterByID(MONSTER_ID_GAIL);

            Local barDoMoe = new Local(LOCATION_ID_BAR_DO_MOE,
                "O bar do incrivel Moe.",
                "Tem muita gente estranha aqui.");
            barDoMoe.MissaoDisponivel = QuestByID(QUEST_ID_MATAR_ORC);

            Local cavernaDoOrc = new Local(LOCATION_ID_CAVERNA_DO_ORC,
                "Uma caverna escura.",
                "Você ouve muitos barulhos incompreensíveis.");
            cavernaDoOrc.MonstroNolocal = MonsterByID(MONSTER_ID_ORC);

            Local cidadeAbandonada = new Local(LOCATION_ID_CIDADE_ABANDONADA,
                "Um lugar abandonada da cidade.",
                "Você encontra um mural de avisos que te chama atenção.",
                ItemByID(ITEM_ID_CHAVE));
            cidadeAbandonada.MissaoDisponivel = QuestByID(QUEST_ID_LUTA_FINAL);
            //cidadeAbandonada.MonstroNolocal = MonsterByID(MONSTER_ID_MORTO_VIVO);
            //cidadeAbandonada.MissaoDisponivel = QuestByID(QUEST_ID_LUTA_FINAL);
            //ItemByID(ITEM_ID_CHAVE);

            Local centro = new Local(LOCATION_ID_CENTRO,
                "O centro é lugar movimentado.",
                "Tem bastante comercio por aqui.");

            Local ponte = new Local(LOCATION_ID_PONTE,
                "Ponte",
                "Uma ponte de pedra que atravessa um rio." + Environment.NewLine + "Gravado em uma placa você lê: PELO AMOR DE DEUS, EXTERMINE MUNRAH DA TERRA!!!");

            Local torreDoDragao = new Local(LOCATION_ID_TORRE_DO_DRAGAO,
                "Uma torre alta.",
                "Você vê restos do que já foi uma igreja..." + Environment.NewLine + "O som parece perturbador.");
            torreDoDragao.MonstroNolocal = MonsterByID(MONSTER_ID_MUNRAH);

            //Linkagem dos locais
            casa.LocalParaCima = floresta;

            floresta.LocalParaCima = centro;
            floresta.LocalParaBaixo = casa;

            centro.LocalParaCima = cidadeAbandonada;
            centro.LocalParaBaixo = floresta;
            centro.LocalParaDireita = barDoMoe;
            centro.LocalParaEsquerda = lojaDoGail;

            lojaDoGail.LocalParaBaixo = quintalDoGail;
            lojaDoGail.LocalParaDireita = centro;

            quintalDoGail.LocalParaCima = lojaDoGail;

            barDoMoe.LocalParaEsquerda = centro;
            barDoMoe.LocalParaDireita = cavernaDoOrc;

            cavernaDoOrc.LocalParaEsquerda = barDoMoe;

            cidadeAbandonada.LocalParaBaixo = centro;
            cidadeAbandonada.LocalParaCima = ponte;

            ponte.LocalParaBaixo = cidadeAbandonada;
            ponte.LocalParaCima = torreDoDragao;

            torreDoDragao.LocalParaBaixo = ponte;

            // Adiciona a lista de locais.
            Locais.Add(casa);
            Locais.Add(floresta);
            Locais.Add(centro);
            Locais.Add(lojaDoGail);
            Locais.Add(barDoMoe);
            Locais.Add(cavernaDoOrc);
            Locais.Add(cidadeAbandonada);
            Locais.Add(ponte);
            Locais.Add(torreDoDragao);
        }

        public static Item ItemByID(int id)
        {
            foreach
            (Item item in Itens)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Monstro MonsterByID(int id)
        {
            foreach
            (Monstro monster in Monstros)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }
            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach
                (Quest missao in Missoes)
            {
                if (missao.ID == id)
                {
                    return missao;
                }
            }
            return null;
        }

        public static Local LocationByID(int id)
        {
            foreach
                (Local local in Locais)
            {
                if (local.ID == id)
                {
                    return local;
                }
            }
            return null;
        }
    }
}