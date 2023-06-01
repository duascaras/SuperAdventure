using Engine;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Player _player;
        private Monster _currentMonster;

        public SuperAdventure()
        {
            InitializeComponent();

            _player = new Player(10, 10, 20, 0, 1);
            MoveTo(World.LocationByID(World.LOCATION_ID_CASA));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_ESPADA_ENFERRUJADA), 1));

            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
        }

        private void MoveTo(Location newLocation)
        {
            //TODO - Alterar a lógica para um IF invertido.
            if (newLocation.ItemRequiredToEnter != null)
            {
                bool playerHasRequiredItem = false;

                foreach (InventoryItem ii in _player.Inventory)
                {
                    if (ii.Details.ID == newLocation.ItemRequiredToEnter.ID)
                    {
                        playerHasRequiredItem = true;
                        break;
                    }
                }
                if (!playerHasRequiredItem)
                {
                    rtbMensagens.Text += "Você precisa ter o item " + newLocation.ItemRequiredToEnter.Name + "para entrar nesse local." + Environment.NewLine;
                    return;
                }
            }
            //atualiza o local do player
            _player.CurrentLocation = newLocation;

            //mostra/esconde os botões de movimento
            btnNorte.Visible = (newLocation.LocationToNorth != null);
            btnSul.Visible = (newLocation.LocationToSouth != null);
            btnLeste.Visible = (newLocation.LocationToEast != null);
            btnOeste.Visible = (newLocation.LocationToWest != null);

            //exibe o nome do local atual e sua descrição
            rtbLocal.Text = newLocation.Name + Environment.NewLine;
            rtbLocal.Text += newLocation.Description + Environment.NewLine;

            //cura o player
            _player.CurrentHitPoints = _player.MaximumHitPoints;

            //atualiza os HIT POINTS na interface
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();

            if (newLocation.QuestAvailableHere != null)
            {
                bool playerTemAQuest = false;
                bool playerCompletouAQuest = false;

                foreach (PlayerQuest playerQuest in _player.Quests)
                {
                    if (playerQuest.Details.ID == newLocation.QuestAvailableHere.ID)
                    {
                        playerTemAQuest = true;

                        if (playerQuest.IsCompleted)
                        {
                            playerCompletouAQuest = true;
                        }
                    }
                }

                if (playerTemAQuest)
                {
                    if (!playerCompletouAQuest)
                    {
                        bool playerTemItensParaCompletarQuest = true;

                        foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                        {
                            bool temItemNoInventario = false;

                            foreach (InventoryItem ii in _player.Inventory)
                            {
                                if (ii.Details.ID == qci.Details.ID)
                                {
                                    temItemNoInventario = true;
                                    if (ii.Quantity < qci.Quantity)
                                    {
                                        playerTemItensParaCompletarQuest = false;
                                        break;
                                    }
                                    break;
                                }
                            }
                            if (!temItemNoInventario)
                            {
                                playerTemItensParaCompletarQuest = false;
                                break;
                            }
                        }
                        if (playerTemItensParaCompletarQuest)
                        {
                            rtbMensagens.Text += Environment.NewLine;
                            rtbMensagens.Text += "Você completou a " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;

                            foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                            {
                                foreach (InventoryItem ii in _player.Inventory)
                                {
                                    if (ii.Details.ID == qci.Details.ID)
                                    {
                                        ii.Quantity -= qci.Quantity;
                                        break;
                                    }
                                }
                            }

                            //Recompensas Quest
                            rtbMensagens.Text += "Você ganhou: " + Environment.NewLine;
                            rtbMensagens.Text += newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " Pontos de Experiência" + Environment.NewLine;
                            rtbMensagens.Text += newLocation.QuestAvailableHere.RewardGold.ToString() + " Ouro" + Environment.NewLine;
                            rtbMensagens.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMensagens.Text += Environment.NewLine;
                            _player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                            _player.Gold += newLocation.QuestAvailableHere.RewardGold;

                            bool adicionadoItemAoInventorio = false;

                            foreach (InventoryItem ii in _player.Inventory)
                            {
                                //se ele tiver o item, aumentamos em 1.
                                if (ii.Details.ID == newLocation.QuestAvailableHere.RewardItem.ID)
                                {
                                    ii.Quantity++;

                                    adicionadoItemAoInventorio = true;
                                    break;
                                }
                                //se não tiver o item, adicionamos pela primeira vez com o valor de 1.
                                if (!adicionadoItemAoInventorio)
                                {
                                    _player.Inventory.Add(new InventoryItem(newLocation.QuestAvailableHere.RewardItem, 1));
                                }
                                //marcamos a quest como completada.
                                foreach (PlayerQuest pq in _player.Quests)
                                {
                                    if (pq.Details.ID == newLocation.QuestAvailableHere.ID)
                                    {
                                        pq.IsCompleted = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else  //o player não tem a quest
                    {
                        rtbMensagens.Text += "Você recebeu a " + newLocation.QuestAvailableHere.Name + "quest." + Environment.NewLine;
                        rtbMensagens.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                        rtbMensagens.Text += "Para completar ela, retorne com:" + Environment.NewLine;

                        foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                        {
                            if (qci.Quantity == 1)
                            {
                                rtbMensagens.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                            }
                            else
                            {
                                rtbMensagens.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                            }
                        }
                        rtbMensagens.Text += Environment.NewLine;

                        //adiciona a quest pro player
                        _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                    }
                }
                //o local tem um monstro?
                if (newLocation.MonsterLivingHere != null)
                {
                    rtbMensagens.Text += "Você vê um " + newLocation.MonsterLivingHere.Name + Environment.NewLine;

                    //criando um monstro
                    Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);
                    _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage, standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);

                    foreach (LootItem lootItem in standardMonster.LootTable)
                    {
                        _currentMonster.LootTable.Add(lootItem);
                    }

                    cboArmas.Visible = true;
                    cboPocoes.Visible = true;
                    btnUsarArma.Visible = true;
                    btnUsarPocao.Visible = true;
                }
                else
                {
                    _currentMonster = null;

                    cboArmas.Visible = false;
                    cboPocoes.Visible = false;
                    btnUsarArma.Visible = false;
                    btnUsarPocao.Visible = false;
                }

                //atualiza inventorio
                dgvInventorio.RowHeadersVisible = false;

                dgvInventorio.ColumnCount = 2;
                dgvInventorio.Columns[0].Name = "Name";
                dgvInventorio.Columns[0].Width = 197;
                dgvInventorio.Columns[1].Name = "Quantity";

                dgvInventorio.Rows.Clear();

                foreach (InventoryItem inventoryItem in _player.Inventory)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        dgvInventorio.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                    }
                }

                //atualiza lista de quests
                dgvQuests.RowHeadersVisible = false;

                dgvQuests.ColumnCount = 2;
                dgvQuests.Columns[0].Name = "Nome";
                dgvQuests.Columns[0].Width = 197;
                dgvQuests.Columns[1].Name = "Finalizado?";

                dgvQuests.Rows.Clear();

                foreach (PlayerQuest playerQuest in _player.Quests)
                {
                    dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.IsCompleted.ToString() });
                }

                //atualiza  armas
                List<Weapon> weapons = new List<Weapon>();

                foreach (InventoryItem inventoryItem in _player.Inventory)
                {
                    if (inventoryItem.Details is Weapon)
                    {
                        if (inventoryItem.Quantity > 0)
                        {
                            weapons.Add((Weapon)inventoryItem.Details);
                        }
                    }
                }

                if (weapons.Count == 0)
                {
                    cboArmas.Visible = false;
                    btnUsarArma.Visible = false;
                }
                else
                {
                    cboArmas.DataSource = weapons;
                    cboArmas.DisplayMember = "Name";
                    cboArmas.ValueMember = "ID";

                    cboArmas.SelectedIndex = 0;
                }

                //atualiza poções
                List<HealingPotion> healingPotions = new List<HealingPotion>();

                foreach (InventoryItem inventoryItem in _player.Inventory)
                {
                    if (inventoryItem.Details is HealingPotion)
                    {
                        if (inventoryItem.Quantity > 0)
                        {
                            healingPotions.Add((HealingPotion)inventoryItem.Details);
                        }
                    }
                }

                if (healingPotions.Count == 0)
                {
                    cboPocoes.Visible = false;
                    btnUsarPocao.Visible = false;
                }
                else
                {
                    cboPocoes.DataSource = healingPotions;
                    cboPocoes.DisplayMember = "Name";
                    cboPocoes.ValueMember = "ID";

                    cboPocoes.SelectedIndex = 0;
                }
            }
        }

        private void btnNorte_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnSul_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnLeste_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnOeste_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void btnUsarArma_Click(object sender, EventArgs e)
        {
        }

        private void btnUsarPocao_Click(object sender, EventArgs e)
        {
        }
    }
}