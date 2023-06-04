using Engine;
using System.Media;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Player _player;
        private Monster _currentMonster;

        public SuperAdventure()
        {
            InitializeComponent();

            _player = new Player(10, 10, 20, 0);
            MoveTo(World.LocationByID(World.LOCATION_ID_CASA));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_ESPADA_ENFERRUJADA), 1));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_PORRETA), 1));

            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
        }

        private void ScrollToBottomOfMessages()
        {
            rtbMensagens.SelectionStart = rtbMensagens.Text.Length;
            rtbMensagens.ScrollToCaret();
        }

        private void MoveTo(Location newLocation)
        {
            if (!_player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtbMensagens.Text +=
                    "Você preecisa possuir " +
                    newLocation.ItemRequiredToEnter.Name +
                    " para acessar esse local." + Environment.NewLine;

                ScrollToBottomOfMessages();
                return;
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
                bool playerTemAQuest = _player.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerCompletouAQuest = _player.CompletedThisQuest(newLocation.QuestAvailableHere);

                if (playerTemAQuest)
                {
                    if (!playerCompletouAQuest)
                    {
                        bool playerTemItensParaCompletarQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        if (playerTemItensParaCompletarQuest)
                        {
                            rtbMensagens.Text += Environment.NewLine;
                            rtbMensagens.Text += "Você completou a " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\MissionCompleted.wav");
                            simpleSound.Play();

                            _player.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);

                            //Recompensas Quest
                            rtbMensagens.Text += "Você ganhou: " + Environment.NewLine;
                            rtbMensagens.Text += newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " Pontos de Experiência" + Environment.NewLine;
                            rtbMensagens.Text += newLocation.QuestAvailableHere.RewardGold.ToString() + " Ouro" + Environment.NewLine;
                            rtbMensagens.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMensagens.Text += Environment.NewLine;
                            _player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                            _player.Gold += newLocation.QuestAvailableHere.RewardGold;

                            _player.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);

                            _player.MarkQuestCompleted(newLocation.QuestAvailableHere);

                            lblExperience.Text = _player.ExperiencePoints.ToString();
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

            // Refresh player's inventory list
            UpdateInventoryListInUI();
            // Refresh player's quest list
            UpdateQuestListInUI();
            // Refresh player's weapons combobox
            UpdateWeaponListInUI();
            // Refresh player's potions combobox
            UpdatePotionListInUI();

            ScrollToBottomOfMessages();
        }

        private void UpdateInventoryListInUI()
        {
            dgvInventorio.RowHeadersVisible = false;
            dgvInventorio.ColumnCount = 2;
            dgvInventorio.Columns[0].Name = "Nome";
            dgvInventorio.Columns[0].Width = 197;
            dgvInventorio.Columns[1].Name = "Quantidade";
            dgvInventorio.Rows.Clear();
            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventorio.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI()
        {
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
        }

        private void UpdateWeaponListInUI()
        {
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
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
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
        }

        private void UpdatePotionListInUI()
        {
            List<HealingPotion> healingPotions = new List<HealingPotion>();
            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is HealingPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add(
                        (HealingPotion)inventoryItem.Details);
                    }
                }
            }
            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
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
            // Get the currently selected weapon from the cboArmas ComboBox
            Weapon currentWeapon = (Weapon)cboArmas.SelectedItem;

            // Determine the amount of damage to do to the monster
            int damageToMonster = RandomNumberGeneorcr.NumeroEntreValores(
             currentWeapon.MinimumDamage, currentWeapon.MaximumDamage);

            // Apply the damage to the monster's CurrentHitPoints
            _currentMonster.CurrentHitPoints -= damageToMonster;

            // Display message
            rtbMensagens.Text += "Você deu " + _currentMonster.Name + " pontos de " +
            damageToMonster.ToString() + " dano." + Environment.NewLine;

            // Check if the monster is dead
            if (_currentMonster.CurrentHitPoints <= 0)
            {
                // Monster is dead
                rtbMensagens.Text += Environment.NewLine;
                rtbMensagens.Text += "Você derrotou o " + _currentMonster.Name +
                 Environment.NewLine;

                // Give player experience points for killing the monster
                _player.ExperiencePoints += _currentMonster.RewardExperiencePoints;
                rtbMensagens.Text += "Você recebeu " +
                 _currentMonster.RewardExperiencePoints.ToString() +
                 " pontos de experiência" + Environment.NewLine;

                lblExperience.Text = _player.ExperiencePoints.ToString();

                // Give player gold for killing the monster
                _player.Gold += _currentMonster.RewardGold;
                rtbMensagens.Text += "Você recebeu" +
                _currentMonster.RewardGold.ToString() + " moedas de ouro" + Environment.NewLine;

                // Get random loot items from the monster
                List<InventoryItem> lootedItems = new List<InventoryItem>();

                // Add items to the lootedItems list, comparing a random number to the drop percentage
                foreach (LootItem lootItem in _currentMonster.LootTable)
                {
                    if (RandomNumberGeneorcr.NumeroEntreValores(1, 100) <= lootItem.DropPercentage)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }
                // If no items were randomly selected, then add the default loot item(s).
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in _currentMonster.LootTable)
                    {
                        if (lootItem.IsDefaultItem)
                        {
                            lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                        }
                    }
                }

                // Add the looted items to the player's inventory
                foreach (InventoryItem inventoryItem in lootedItems)
                {
                    _player.AddItemToInventory(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        rtbMensagens.Text += "Você recebeu " +
                         inventoryItem.Quantity.ToString() + " " +
                         inventoryItem.Details.Name + Environment.NewLine;
                    }
                    else
                    {
                        rtbMensagens.Text += "Você recebeu " +
                       inventoryItem.Quantity.ToString() + " " +
                       inventoryItem.Details.NamePlural + Environment.NewLine;
                    }
                }

                // Refresh player information and inventory controls
                lblHitPoints.Text = _player.CurrentHitPoints.ToString();
                lblGold.Text = _player.Gold.ToString();
                lblExperience.Text = _player.ExperiencePoints.ToString();
                lblLevel.Text = _player.Level.ToString();

                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();

                // Add a blank line to the messages box, just for appearance.
                rtbMensagens.Text += Environment.NewLine;

                // Move player to current location (to heal player and create a new monster to fight)
                MoveTo(_player.CurrentLocation);
            }
            else
            {
                // Monster is still alive

                // Determine the amount of damage the monster does to the player
                int damageToPlayer =
                RandomNumberGeneorcr.NumeroEntreValores(0, _currentMonster.MaximumDamage);

                // Display message
                rtbMensagens.Text += "O " + _currentMonster.Name + " deu " +
                damageToPlayer.ToString() + " pontos de dano." + Environment.NewLine;

                // Subtract damage from player
                _player.CurrentHitPoints -= damageToPlayer;

                // Refresh player data in UI
                lblHitPoints.Text = _player.CurrentHitPoints.ToString();

                if (_player.CurrentHitPoints <= 0)
                {
                    // Display message
                    //rtbMensagens.Text += "The " + _currentMonster.Name + " killed you." +
                    rtbMensagens.Text += "Você morreu " +
                    Environment.NewLine;

                    // Move player to "Home"
                    MoveTo(World.LocationByID(World.LOCATION_ID_CASA));
                }
            }
            ScrollToBottomOfMessages();
        }

        private void btnUsarPocao_Click(object sender, EventArgs e)
        {
            // Get the currently selected potion from the combobox
            HealingPotion potion = (HealingPotion)cboPocoes.SelectedItem;

            // Add healing amount to the player's current hit points
            _player.CurrentHitPoints = (_player.CurrentHitPoints + potion.AmountToHeal);

            // CurrentHitPoints cannot exceed player's MaximumHitPoints
            if (_player.CurrentHitPoints > _player.MaximumHitPoints)
            {
                _player.CurrentHitPoints = _player.MaximumHitPoints;
            }

            // Remove the potion from the player's inventory
            foreach (InventoryItem ii in _player.Inventory)
            {
                if (ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }
            }

            // Display message
            rtbMensagens.Text += "Você bebeu a " + potion.Name + Environment.NewLine;

            // Monster gets their turn to attack

            // Determine the amount of damage the monster does to the player
            int damageToPlayer =
            RandomNumberGeneorcr.NumeroEntreValores(0, _currentMonster.MaximumDamage);

            // Display message
            rtbMensagens.Text += "O " + _currentMonster.Name + " deu " +
            damageToPlayer.ToString() + " pontos de dano." + Environment.NewLine;

            // Subtract damage from player
            _player.CurrentHitPoints -= damageToPlayer;

            if (_player.CurrentHitPoints <= 0)
            {
                // Display message
                //rtbMensagens.Text += "The " + _currentMonster.Name + " killed you." +
                rtbMensagens.Text += "Você morreu." +
                Environment.NewLine;

                // Move player to "Home"
                MoveTo(World.LocationByID(World.LOCATION_ID_CASA));
            }

            // Refresh player data in UI
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
            ScrollToBottomOfMessages();
        }
    }
}