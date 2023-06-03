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
        public const int ITEM_ID_CAUDA_DE_RATO = 2;
        public const int ITEM_ID_PEDACO_DE_PELE = 3;
        public const int ITEM_ID_PRESA_DE_COBRA = 4;
        public const int ITEM_ID_PELE_DE_COBRA = 5;
        public const int ITEM_ID_PORRETA = 6;
        public const int ITEM_ID_POCAO_DE_CURA = 7;
        public const int ITEM_ID_PRESA_DE_ARANHA = 8;
        public const int ITEM_ID_TEIA_DE_ARANHA = 9;
        public const int ITEM_ID_PASSE_DO_AVENTUREIRO = 10;

        public const int MONSTER_ID_RATO = 1;
        public const int MONSTER_ID_COBRA = 2;
        public const int MONSTER_ID_ARANHA_GIGANTE = 3;

        public const int QUEST_ID_LIMPAR_JARDIM_ALQUIMISTA = 1;
        public const int QUEST_ID_LIMPAR_CAMPO_FAZENDEIROS = 2;

        public const int LOCATION_ID_CASA = 1;
        public const int LOCATION_ID_PRACA_DA_CIDADE = 2;
        public const int LOCATION_ID_POSTO_DE_GUARDA = 3;
        public const int LOCATION_ID_CABANA_DO_ALQUIMISTA = 4;
        public const int LOCATION_ID_JARDIM_DO_ALQUIMISTA = 5;
        public const int LOCATION_ID_FAZENDA = 6;
        public const int LOCATION_ID_CAMPO_DE_AGRICULTURA = 7;
        public const int LOCATION_ID_PONTE = 8;
        public const int LOCATION_ID_CAMPO_DA_COBRA = 9;

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
            Items.Add(new Item(ITEM_ID_CAUDA_DE_RATO, "Cauda de Rato", "Cauda de Ratos"));
            Items.Add(new Item(ITEM_ID_PEDACO_DE_PELE, "Pedaço de Pele", "Pedaço de Pele"));
            Items.Add(new Item(ITEM_ID_PRESA_DE_COBRA, "Presa de Cobra", "Presa de Cobra"));
            Items.Add(new Item(ITEM_ID_PELE_DE_COBRA, "Pele de Cobra", "Pele de Cobra"));
            Items.Add(new Item(ITEM_ID_PRESA_DE_ARANHA, "Presa de Aranha", "Presa de Aranha"));
            Items.Add(new Item(ITEM_ID_TEIA_DE_ARANHA, "Teia de Aranha", "Teia de Aranha"));
            Items.Add(new Item(ITEM_ID_PASSE_DO_AVENTUREIRO,"Passe do Aventureiro", "Passe do Aventureiro"));
        }

        private static void PreencherMonstros()
        {
            Monster rato = new Monster(MONSTER_ID_RATO, "Rato", 5, 3, 10, 3, 3);
            rato.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CAUDA_DE_RATO), 75, false));
            rato.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PEDACO_DE_PELE), 75, true));

            Monster cobra = new Monster(MONSTER_ID_COBRA, "Cobra", 5, 3, 10, 3, 3);
            cobra.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PRESA_DE_COBRA), 75, false));
            cobra.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PELE_DE_COBRA), 75, true));

            Monster aranhaGigante = new Monster(MONSTER_ID_ARANHA_GIGANTE, "Aranha Gigante", 20, 5, 40, 10, 10);
            aranhaGigante.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PRESA_DE_ARANHA), 75, true));
            aranhaGigante.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TEIA_DE_ARANHA), 25, false));

            Monsters.Add(rato);
            Monsters.Add(cobra);
            Monsters.Add(aranhaGigante);
        }

        private static void PreencherQuests()
        {
            Quest limparJardimAlquimista = new Quest(QUEST_ID_LIMPAR_JARDIM_ALQUIMISTA,
                    "Limpe o jardim do Alquimista",
                    "Mate os ratos no jardim do Alquimista e traga de volta 3 caudas de rato. Você receberá uma Poção de Cura e 10 peças de Ouro.", 20, 10);

            limparJardimAlquimista.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_CAUDA_DE_RATO), 3));

            limparJardimAlquimista.RewardItem = ItemByID(ITEM_ID_POCAO_DE_CURA);

            Quest LimparFazenda = new Quest(QUEST_ID_LIMPAR_CAMPO_FAZENDEIROS,
                    "Limpe a Fazenda",
                    "Mate Cobras na Fazenda e traga de volta 3 presas de cobra. Você receberá um Passe do Aventureiro e 20 peças de ouro", 20, 20);

            LimparFazenda.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_PRESA_DE_COBRA), 3));

            LimparFazenda.RewardItem = ItemByID(ITEM_ID_PASSE_DO_AVENTUREIRO);

            Quests.Add(limparJardimAlquimista);
            Quests.Add(LimparFazenda);
        }

        private static void PreencherLocais()
        {
            // Create each location
            Location casa = new Location(LOCATION_ID_CASA,
                "Casa",
                "Sua casa. Você realmente precisa limpar esse lugar...");

            Location pracaDaCidade = new Location(LOCATION_ID_PRACA_DA_CIDADE,
                "Praça da Cidade",
                "Você vê uma fonte.");

            Location cabanaDoAlquimista = new Location(LOCATION_ID_CABANA_DO_ALQUIMISTA, 
                "Cabana do Alquimista",
                "Tem muitas plantas estranhas nas prateleiras.");

            cabanaDoAlquimista.QuestAvailableHere = QuestByID(QUEST_ID_LIMPAR_JARDIM_ALQUIMISTA);

            Location jardimDoAlqumista = new Location(LOCATION_ID_JARDIM_DO_ALQUIMISTA,
                "Jardim do Alquimista",
                "Muitas plantas crescendo aqui.");
            jardimDoAlqumista.MonsterLivingHere = MonsterByID(MONSTER_ID_RATO);

            Location fazenda = new Location(LOCATION_ID_FAZENDA,
                "Fazenda",
                "Há uma pequena cabana, com um fazendeiro na frente.");
            fazenda.QuestAvailableHere = QuestByID(QUEST_ID_LIMPAR_CAMPO_FAZENDEIROS);

            Location campoDeAgricultura = new Location(LOCATION_ID_CAMPO_DE_AGRICULTURA,
                "Campo de Agricultura", 
                "Você vê vários vegetais crescendo aqui.");
            campoDeAgricultura.MonsterLivingHere = MonsterByID(MONSTER_ID_COBRA);

            Location postoDeGuarda = new Location(LOCATION_ID_POSTO_DE_GUARDA, 
                "Posto de Guarda",
                "Você enxerga um guarda com aparência de durão aqui.",
                ItemByID(ITEM_ID_PASSE_DO_AVENTUREIRO));

            Location ponte = new Location(LOCATION_ID_PONTE, 
                "Ponte",
                "Uma ponte de pedra que atravessa um rio.");

            Location campoDaCobra = new Location(LOCATION_ID_CAMPO_DA_COBRA,
                "Floresta",
                "Você vê teias de aranha cobrindo as arvores nessa floresta...");
            campoDaCobra.MonsterLivingHere = MonsterByID(MONSTER_ID_ARANHA_GIGANTE);

            // Link the locations together
            casa.LocationToNorth = pracaDaCidade;

            pracaDaCidade.LocationToNorth = cabanaDoAlquimista;
            pracaDaCidade.LocationToSouth = casa;
            pracaDaCidade.LocationToEast = postoDeGuarda;
            pracaDaCidade.LocationToWest = fazenda;

            fazenda.LocationToEast = pracaDaCidade;
            fazenda.LocationToWest = campoDeAgricultura;

            campoDeAgricultura.LocationToEast = fazenda;

            cabanaDoAlquimista.LocationToSouth = pracaDaCidade;
            cabanaDoAlquimista.LocationToNorth = jardimDoAlqumista;

            jardimDoAlqumista.LocationToSouth = cabanaDoAlquimista;

            postoDeGuarda.LocationToEast = ponte;
            postoDeGuarda.LocationToWest = pracaDaCidade;

            ponte.LocationToWest = postoDeGuarda;
            ponte.LocationToEast = campoDaCobra;

            campoDaCobra.LocationToWest = ponte;

            // Add the locations to the static list
            Locations.Add(casa);
            Locations.Add(pracaDaCidade);
            Locations.Add(postoDeGuarda);
            Locations.Add(cabanaDoAlquimista);
            Locations.Add(jardimDoAlqumista);
            Locations.Add(fazenda);
            Locations.Add(campoDeAgricultura);
            Locations.Add(ponte);
            Locations.Add(campoDaCobra);
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
   