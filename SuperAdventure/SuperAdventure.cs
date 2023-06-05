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

            _player = new Player(10, 10, 20, 0);
            MoveTo(World.LocationByID(World.LOCATION_ID_CASA));
            _player.Inventario.Add(new ItemDeInventario(World.ItemByID(World.ITEM_ID_ESPADA_ENFERRUJADA), 1));
            _player.Inventario.Add(new ItemDeInventario(World.ItemByID(World.ITEM_ID_PORRETA), 1));

            lblHitPoints.Text = _player.HpAtual.ToString();
            lblGold.Text = _player.Ouro.ToString();
            lblExperience.Text = _player.PontosDeExperiencia.ToString();
            lblLevel.Text = _player.Nivel.ToString();
        }

        private void MoveTo(Location newLocation)
        {
            if (!_player.PossuiItemNecessarioParaAcessar(newLocation))
            {
                rtbMensagens.Text +=
                    "Você preecisa possuir " +
                    newLocation.ItemNecessarioParaEntrar.Nome +
                    " para acessar esse local." + Environment.NewLine;

                RolagemDasMensagens();
                return;
            }

            //atualiza o local do player
            _player.LocalAtual = newLocation;

            //mostra/esconde os botões de movimento
            btnNorte.Visible = (newLocation.LocalParaCima != null);
            btnSul.Visible = (newLocation.LocalParaBaixo != null);
            btnLeste.Visible = (newLocation.LocalParaDireita != null);
            btnOeste.Visible = (newLocation.LocalParaEsquerda != null);

            //exibe o nome do local atual e sua descrição
            rtbLocal.Text = newLocation.Nome + Environment.NewLine;
            rtbLocal.Text += newLocation.Descricao + Environment.NewLine;

            //cura o player
            _player.HpAtual = _player.HpMaximo;

            //atualiza o HP na interface
            lblHitPoints.Text = _player.HpAtual.ToString();

            if (newLocation.MissaoDisponivel != null)
            {
                bool playerTemAQuest = _player.PossuiMissao(newLocation.MissaoDisponivel);
                bool playerCompletouAQuest = _player.MissaoCompletada(newLocation.MissaoDisponivel);

                if (playerTemAQuest)
                {
                    if (!playerCompletouAQuest)
                    {
                        bool playerTemItensParaCompletarQuest = _player.PossuiItensParaCompletarMissao(newLocation.MissaoDisponivel);

                        if (playerTemItensParaCompletarQuest)
                        {
                            rtbMensagens.Text += Environment.NewLine;
                            rtbMensagens.Text += "Você completou a " + newLocation.MissaoDisponivel.Nome + " missao." + Environment.NewLine;
                            // TODO -> Checar questão do Som.
                            //SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\MissionCompleted.wav");
                            //simpleSound.Play();

                            _player.RemoveItensDaMissaoCompletada(newLocation.MissaoDisponivel);

                            //Recompensas Quest
                            rtbMensagens.Text += "Você ganhou: " + Environment.NewLine;
                            rtbMensagens.Text += newLocation.MissaoDisponivel.RecompensaExperiencia.ToString() + " Pontos de Experiência" + Environment.NewLine;
                            rtbMensagens.Text += newLocation.MissaoDisponivel.RecompensaOuro.ToString() + " Ouro" + Environment.NewLine;
                            rtbMensagens.Text += newLocation.MissaoDisponivel.RecompensaItem.Nome + Environment.NewLine;
                            rtbMensagens.Text += Environment.NewLine;

                            _player.PontosDeExperiencia += newLocation.MissaoDisponivel.RecompensaExperiencia;
                            _player.Ouro += newLocation.MissaoDisponivel.RecompensaOuro;

                            _player.AdicionaItemAoInventario(newLocation.MissaoDisponivel.RecompensaItem);
                            _player.MarcaMIssaoComoCompleta(newLocation.MissaoDisponivel);

                            lblExperience.Text = _player.PontosDeExperiencia.ToString();
                        }
                    }
                }
                else  //o player não tem a missao
                {
                    rtbMensagens.Text += "Você recebeu a missão: " + newLocation.MissaoDisponivel.Nome + Environment.NewLine;
                    rtbMensagens.Text += newLocation.MissaoDisponivel.Descricao + Environment.NewLine;
                    rtbMensagens.Text += "Para completar ela, retorne nesse local com:" + Environment.NewLine;

                    foreach (QuestCompletionItem qci in newLocation.MissaoDisponivel.ItensMissaoCompleta)
                    {
                        if (qci.Quantidade == 1)
                        {
                            rtbMensagens.Text += qci.Quantidade.ToString() + " " + qci.Detalhes.Nome + Environment.NewLine;
                        }
                        else
                        {
                            rtbMensagens.Text += qci.Quantidade.ToString() + " " + qci.Detalhes.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMensagens.Text += Environment.NewLine;
                    //adiciona a missao pro player
                    _player.Missoes.Add(new PlayerQuest(newLocation.MissaoDisponivel));
                }
            }
            if (newLocation.MonstroNolocal != null) //o local tem um monstro?
            {
                rtbMensagens.Text += "Você vê: " + newLocation.MonstroNolocal.Nome + Environment.NewLine;

                //criando um monstro
                Monster standardMonster = World.MonsterByID(newLocation.MonstroNolocal.ID);
                _currentMonster = new Monster(standardMonster.ID, standardMonster.Nome, standardMonster.DanoMaximo, standardMonster.RecompensaExperiencia, standardMonster.RecompensaOuro, standardMonster.HpAtual, standardMonster.HpMaximo);

                foreach (LootItem lootItem in standardMonster.Loot)
                {
                    _currentMonster.Loot.Add(lootItem);
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

            AtualizaInventario();
            AtualizaMissoes();
            AtualizaArmas();
            AtualizaPocoes();
            RolagemDasMensagens();
        }

        private void AtualizaInventario()
        {
            dgvInventorio.RowHeadersVisible = false;
            dgvInventorio.ColumnCount = 2;
            dgvInventorio.Columns[0].Name = "Nome";
            dgvInventorio.Columns[0].Width = 197;
            dgvInventorio.Columns[1].Name = "Quantidade";
            dgvInventorio.Rows.Clear();
            foreach (ItemDeInventario inventoryItem in _player.Inventario)
            {
                if (inventoryItem.Quantidade > 0)
                {
                    dgvInventorio.Rows.Add(new[] { inventoryItem.Detalhes.Nome, inventoryItem.Quantidade.ToString() });
                }
            }
        }

        private void AtualizaMissoes()
        {
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Nome";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Finalizado?";
            dgvQuests.Rows.Clear();
            foreach (PlayerQuest missaoDoPlayer in _player.Missoes)
            {
                dgvQuests.Rows.Add(new[] { missaoDoPlayer.Detalhes.Nome, missaoDoPlayer.Finalizada.ToString() });
            }
        }

        private void AtualizaArmas()
        {
            List<Weapon> weapons = new List<Weapon>();
            foreach (ItemDeInventario inventoryItem in _player.Inventario)
            {
                if (inventoryItem.Detalhes is Weapon)
                {
                    if (inventoryItem.Quantidade > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Detalhes);
                    }
                }
            }
            if (weapons.Count == 0)
            {
                //Player sem armas, então escondemos as opções
                cboArmas.Visible = false;
                btnUsarArma.Visible = false;
            }
            else
            {
                cboArmas.DataSource = weapons;
                cboArmas.DisplayMember = "Nome";
                cboArmas.ValueMember = "ID";
                cboArmas.SelectedIndex = 0;
            }
        }

        private void AtualizaPocoes()
        {
            List<PocaoDeVida> healingPotions = new List<PocaoDeVida>();
            foreach (ItemDeInventario inventoryItem in _player.Inventario)
            {
                if (inventoryItem.Detalhes is PocaoDeVida)
                {
                    if (inventoryItem.Quantidade > 0)
                    {
                        healingPotions.Add(
                        (PocaoDeVida)inventoryItem.Detalhes);
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
                cboPocoes.DisplayMember = "Nome";
                cboPocoes.ValueMember = "ID";
                cboPocoes.SelectedIndex = 0;
            }
        }

        private void btnNorte_Click(object sender, EventArgs e)
        {
            MoveTo(_player.LocalAtual.LocalParaCima);
        }

        private void btnSul_Click(object sender, EventArgs e)
        {
            MoveTo(_player.LocalAtual.LocalParaBaixo);
        }

        private void btnLeste_Click(object sender, EventArgs e)
        {
            MoveTo(_player.LocalAtual.LocalParaDireita);
        }

        private void btnOeste_Click(object sender, EventArgs e)
        {
            MoveTo(_player.LocalAtual.LocalParaEsquerda);
        }

        private void btnUsarArma_Click(object sender, EventArgs e)
        {
            Weapon currentWeapon = (Weapon)cboArmas.SelectedItem;
            int damageToMonster = RandomNumberGeneorcr.NumeroEntreValores(currentWeapon.DanoMinimo, currentWeapon.DanoMaximo);
            _currentMonster.HpAtual -= damageToMonster;
            rtbMensagens.Text += "Você deu " + _currentMonster.Nome + " pontos de " +
            damageToMonster.ToString() + " dano." + Environment.NewLine;

            if (_currentMonster.HpAtual <= 0) // Monstro morreu
            {
                rtbMensagens.Text += Environment.NewLine;
                rtbMensagens.Text += "Você derrotou o " + _currentMonster.Nome +
                 Environment.NewLine;

                // Incrementa o XP
                _player.PontosDeExperiencia += _currentMonster.RecompensaExperiencia;
                rtbMensagens.Text += "Você recebeu " +
                 _currentMonster.RecompensaExperiencia.ToString() +
                 " pontos de experiência" + Environment.NewLine;
                lblExperience.Text = _player.PontosDeExperiencia.ToString();

                // Incrementa Ouro
                _player.Ouro += _currentMonster.RecompensaOuro;
                rtbMensagens.Text += "Você recebeu " +
                _currentMonster.RecompensaOuro.ToString() + " moedas de ouro" + Environment.NewLine;

                // Loot do monstro
                List<ItemDeInventario> lootedItems = new List<ItemDeInventario>();

                // Adiciona itens ao inventário, usando a porcentagem do drop
                foreach (LootItem lootItem in _currentMonster.Loot)
                {
                    if (RandomNumberGeneorcr.NumeroEntreValores(1, 100) <= lootItem.PorcentagemDrop)
                    {
                        lootedItems.Add(new ItemDeInventario(lootItem.Detalhes, 1));
                    }
                }

                // Dropa o padrão, caso nenhum de cima tenha retornado.s
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in _currentMonster.Loot)
                    {
                        if (lootItem.ItemPadrao)
                        {
                            lootedItems.Add(new ItemDeInventario(lootItem.Detalhes, 1));
                        }
                    }
                }

                // Adiciona o item looteado ao inventário
                foreach (ItemDeInventario inventoryItem in lootedItems)
                {
                    _player.AdicionaItemAoInventario(inventoryItem.Detalhes);

                    if (inventoryItem.Quantidade == 1)
                    {
                        rtbMensagens.Text += "Você recebeu " +
                         inventoryItem.Quantidade.ToString() + " " +
                         inventoryItem.Detalhes.Nome + Environment.NewLine;
                    }
                    else
                    {
                        rtbMensagens.Text += "Você recebeu " +
                       inventoryItem.Quantidade.ToString() + " " +
                       inventoryItem.Detalhes.NamePlural + Environment.NewLine;
                    }
                }

                // Atualiza as informações do player
                lblHitPoints.Text = _player.HpAtual.ToString();
                lblGold.Text = _player.Ouro.ToString();
                lblExperience.Text = _player.PontosDeExperiencia.ToString();
                lblLevel.Text = _player.Nivel.ToString();

                AtualizaInventario();
                AtualizaArmas();
                AtualizaPocoes();

                rtbMensagens.Text += Environment.NewLine;

                // Reseta o local (HP pra full e monstro respawna
                MoveTo(_player.LocalAtual);
            }
            else //monstro não morreu
            {
                int damageToPlayer = RandomNumberGeneorcr.NumeroEntreValores(0, _currentMonster.DanoMaximo);
                rtbMensagens.Text += "O " + _currentMonster.Nome + " deu " + damageToPlayer.ToString() + " pontos de dano." + Environment.NewLine;
                _player.HpAtual -= damageToPlayer;
                lblHitPoints.Text = _player.HpAtual.ToString();

                if (_player.HpAtual <= 0)
                {
                    rtbMensagens.Text += "Você morreu." +
                    Environment.NewLine;
                    // Respawna player na casa.
                    MoveTo(World.LocationByID(World.LOCATION_ID_CASA));
                }
            }
            RolagemDasMensagens();
        }

        private void btnUsarPocao_Click(object sender, EventArgs e)
        {
            PocaoDeVida potion = (PocaoDeVida)cboPocoes.SelectedItem;
            _player.HpAtual = (_player.HpAtual + potion.QuantidadeDeHeal);

            if (_player.HpAtual > _player.HpMaximo)
            {
                _player.HpAtual = _player.HpMaximo;
            }

            foreach (ItemDeInventario ii in _player.Inventario)
            {
                if (ii.Detalhes.ID == potion.ID)
                {
                    ii.Quantidade--;
                    break;
                }
            }

            rtbMensagens.Text += "Você usou: " + potion.Nome + Environment.NewLine;

            // Após usar a poção, o turno é do monstro.
            int damageToPlayer = RandomNumberGeneorcr.NumeroEntreValores(0, _currentMonster.DanoMaximo);
            rtbMensagens.Text += "Você recebeu: " + _currentMonster.Nome +
            damageToPlayer.ToString() + " pontos de dano." + Environment.NewLine;
            _player.HpAtual -= damageToPlayer;

            if (_player.HpAtual <= 0)
            {
                rtbMensagens.Text += "Você morreu." +
                Environment.NewLine;
                MoveTo(World.LocationByID(World.LOCATION_ID_CASA)); //respawna player na casa.
            }

            lblHitPoints.Text = _player.HpAtual.ToString();
            AtualizaInventario();
            AtualizaPocoes();
            RolagemDasMensagens();
        }

        private void RolagemDasMensagens()
        {
            rtbMensagens.SelectionStart = rtbMensagens.Text.Length;
            rtbMensagens.ScrollToCaret();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            WorldMap telaMapa = new WorldMap();
            telaMapa.StartPosition = FormStartPosition.CenterParent;
            telaMapa.ShowDialog(this);
        }
    }
}