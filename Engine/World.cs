namespace Engine
{
    public static class World
    {
        //Pagina 51
        /*What does the code do? The purpose of the World class is to have one place to hold everything that exists in the game world. In it, we'll have things such as the monster that exist at a location, the loot items you can collect after defeating a monster, etc. It will also show how the locations connect with each other, building our game map*/

        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

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

        public const int MONSTER_ID_ORC = 1;
        public const int MONSTER_ID_MORTO_VIVO = 2;
        public const int MONSTER_ID_MUNRAH = 3;
        public const int MONSTER_ID_GAIL = 4;

        public const int QUEST_ID_LUTA = 1;
        public const int QUEST_ID_MATAR_ORC = 2;
        public const int QUEST_ID_LUTA_FINAL = 3;

        public const int LOCATION_ID_CASA = 1;
        public const int LOCATION_ID_FLORESTA = 2;
        public const int LOCATION_ID_CENTRO = 3;
        public const int LOCATION_ID_DIREITA1 = 4;
        public const int LOCATION_ID_ESQUERDA1 = 5;
        public const int LOCATION_ID_ESQUERDA2 = 6;
        public const int LOCATION_ID_CIMA1 = 7;
        public const int LOCATION_ID_CIMA2 = 8;
        public const int LOCATION_ID_CIMA3 = 9;
        public const int LOCATION_ID_QUINTAL = 10;

        static World()
        {
            PreencherItens();
            PreencherMonstros();
            PreencherQuests();
            PreencherLocais();
        }

        private static void PreencherItens()
        {
            Items.Add(new Weapon(ITEM_ID_ESPADA_ENFERRUJADA, "Espada Enferrujada", "Espada Enferrujadas", 0, 5));
            Items.Add(new Weapon(ITEM_ID_PORRETA, "Porreta", "Porreta", 3, 10));
            Items.Add(new HealingPotion(ITEM_ID_POCAO_DE_CURA, "Poção de Cura", "Poção de Cura", 5));
            Items.Add(new Item(ITEM_ID_CHAVE, "Chave", "Chave"));
            Items.Add(new Item(ITEM_ID_OLHO_DE_ORC, "Olho de Orc", "Olho de Orc"));
            Items.Add(new Item(ITEM_ID_PEDACO_CARNE_PODRE, "Pedaço de Carne Podre", "Pedaço de Carne Podre"));
            Items.Add(new Item(ITEM_ID_CABECA, "Cabeça de Munrah", "Cabeça de Munrah"));
            Items.Add(new Item(ITEM_ID_ESPADA_DE_GAIL, "Espada do Gail", "Espada do Gail"));
            Items.Add(new Item(ITEM_ID_MOEDA, "Moeda", "Moeda"));
        }

        private static void PreencherMonstros()
        {
            Monster orc = new Monster(MONSTER_ID_ORC, "Orc", 5, 3, 10, 3, 3);

            orc.LootTable.Add(new LootItem(ItemByID(ITEM_ID_OLHO_DE_ORC), 75, true));

            Monster mortoVivo = new Monster(MONSTER_ID_MORTO_VIVO, "Morto-Vivo", 5, 3, 10, 3, 3);
            mortoVivo.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PEDACO_CARNE_PODRE), 75, false));

            Monster munrah = new Monster(MONSTER_ID_MUNRAH, "Munrah", 10, 5, 40, 10, 10);
            munrah.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CABECA), 75, true));

            Monster gail = new Monster(MONSTER_ID_GAIL, "Lorthus Gail", 7, 3, 0, 4, 4);
            gail.LootTable.Add(new LootItem(ItemByID(ITEM_ID_MOEDA), 0, true));

            Monsters.Add(orc);
            Monsters.Add(mortoVivo);
            Monsters.Add(munrah);
            Monsters.Add(gail);
        }

        private static void PreencherQuests()
        {
            Quest lutarComGail = new Quest(QUEST_ID_LUTA,
                    "Lute com o Gail",
                    "Lute e ganhe de Lorthus Gail. Você receberá uma Poção de Cura e uma espada.", 20, 0);

            lutarComGail.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_MOEDA), 1));

            lutarComGail.RewardItem = ItemByID(ITEM_ID_ESPADA_DE_GAIL);

            Quest matarOrc = new Quest(QUEST_ID_MATAR_ORC,
                    "Mate o Orc da Caverna",
                    "Mate o Orc da Caverna e traga de volta 3 olhos de Orc. Você receberá uma Chave e 20 peças de ouro", 20, 20);

            matarOrc.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_OLHO_DE_ORC), 3));

            matarOrc.RewardItem = ItemByID(ITEM_ID_CHAVE);

            Quest matarMunrah = new Quest(QUEST_ID_LUTA_FINAL,
                "Mate o Dragão da Torre",
                "Existe um dragão que vive na antiga torre da cidade abandonada. Alguem precisa mata-lo.", 30, 30);

            matarMunrah.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_CABECA), 1));

            Quests.Add(matarMunrah);
            Quests.Add(lutarComGail);
            Quests.Add(matarOrc);
        }

        private static void PreencherLocais()
        {
            // Create each location
            Location casa = new Location(LOCATION_ID_CASA,
                "Casa",
                "Parece tão calmo aqui.");

            Location floresta = new Location(LOCATION_ID_FLORESTA,
                "Floresta",
                "As arvores daqui são realmente belas.");

            Location lojaDoGail = new Location(LOCATION_ID_DIREITA1,
                "Loja do Lorthus Gail",
                "Vamos fazer negocios hoje?");
            lojaDoGail.QuestAvailableHere = QuestByID(QUEST_ID_LUTA);

            Location quintalDoGail = new Location(LOCATION_ID_QUINTAL,
                "Quintal do Gail",
                "Você avista um ringue, ele parece fazer isso sempre...");
            quintalDoGail.MonsterLivingHere = MonsterByID(MONSTER_ID_GAIL);

            Location barDoMoe = new Location(LOCATION_ID_ESQUERDA1,
                "O bar do incrivel Moe.",
                "Tem muita gente estranha aqui.");
            barDoMoe.QuestAvailableHere = QuestByID(QUEST_ID_MATAR_ORC);

            Location cavernaDoOrc = new Location(LOCATION_ID_ESQUERDA2,
                "Uma caverna escura.",
                "Você ouve muitos barulhos incompreensíveis.");
            cavernaDoOrc.MonsterLivingHere = MonsterByID(MONSTER_ID_ORC);

            Location cidadeAbandonada = new Location(LOCATION_ID_CIMA1,
                "Um lugar abandonada da cidade.",
                "Você encontra um mural de avisos que te chama atenção.");
            cidadeAbandonada.MonsterLivingHere = MonsterByID(MONSTER_ID_MORTO_VIVO);
            cidadeAbandonada.QuestAvailableHere = QuestByID(QUEST_ID_LUTA_FINAL);
            ItemByID(ITEM_ID_CHAVE);

            Location centro = new Location(LOCATION_ID_CENTRO,
                "O centro é lugar movimentado.",
                "Tem bastante comercio por aqui.");

            Location ponte = new Location(LOCATION_ID_CIMA2,
                "Ponte",
                "Uma ponte de pedra que atravessa um rio." + Environment.NewLine + "Gravado em uma placa você lê: PELO AMOR DE DEUS, EXTERMINE MUNRAH DA TERRA!!!");

            Location torreDoDragao = new Location(LOCATION_ID_CIMA3,
                "Uma torre alta.",
                "Você vê restos do que já foi uma igreja..." + Environment.NewLine + "O som parece perturbador.");
            torreDoDragao.MonsterLivingHere = MonsterByID(MONSTER_ID_MUNRAH);

            // Link the locations together
            casa.LocationToNorth = floresta;

            floresta.LocationToNorth = centro;
            floresta.LocationToSouth = casa;

            centro.LocationToNorth = cidadeAbandonada;
            centro.LocationToSouth = floresta;
            centro.LocationToEast = barDoMoe;
            centro.LocationToWest = lojaDoGail;

            lojaDoGail.LocationToSouth = quintalDoGail;
            lojaDoGail.LocationToEast = centro;

            quintalDoGail.LocationToNorth = lojaDoGail;

            barDoMoe.LocationToWest = centro;
            barDoMoe.LocationToEast = cavernaDoOrc;

            cavernaDoOrc.LocationToWest = barDoMoe;

            cidadeAbandonada.LocationToSouth = centro;
            cidadeAbandonada.LocationToNorth = ponte;

            ponte.LocationToSouth = cidadeAbandonada;
            ponte.LocationToNorth = torreDoDragao;

            torreDoDragao.LocationToSouth = ponte;

            // Add the locations to the static list
            Locations.Add(casa);
            Locations.Add(floresta);
            Locations.Add(centro);
            Locations.Add(lojaDoGail);
            Locations.Add(barDoMoe);
            Locations.Add(cavernaDoOrc);
            Locations.Add(cidadeAbandonada);
            Locations.Add(ponte);
            Locations.Add(torreDoDragao);
        }

        public static Item ItemByID(int id)
        {
            foreach
            (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach
            (Monster monster in Monsters)
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
                (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }
            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach
                (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }
            return null;
        }
    }
}