namespace Engine
{
    public class Player : LivingCreature
    {
        public int Ouro { get; set; }
        public int PontosDeExperiencia { get; set; }
        public int Nivel
        {
            get { return ((PontosDeExperiencia / 100) + 1); }
        }
        public List<ItemDeInventario> Inventario { get; set; }
        public List<PlayerQuest> Missoes { get; set; }
        public Location LocalAtual { get; set; }

        public Player(int hpAtual, int hpMaximo, int ouro, int pontosDeExperiencia) : base(hpAtual, hpMaximo)
        {
            Ouro = ouro;
            PontosDeExperiencia = pontosDeExperiencia;
            Inventario = new List<ItemDeInventario>();
            Missoes = new List<PlayerQuest>();
        }

        public bool PossuiItemNecessarioParaAcessar(Location local)
        {
            if (local.ItemNecessarioParaEntrar == null)
            {
                // Não precisa de item para entrar no local.
                return true;
            }
            // Caso tenha, verifica se o player tem o item no inventário.
            foreach (ItemDeInventario ii in Inventario)
            {
                if (ii.Detalhes.ID == local.ItemNecessarioParaEntrar.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PossuiMissao(Quest missao)
        {
            foreach (PlayerQuest missaoDoPlayer in Missoes)
            {
                if (missaoDoPlayer.Detalhes.ID == missao.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool MissaoCompletada(Quest missao)
        {
            foreach (PlayerQuest missaoDoPlayer in Missoes)
            {
                if (missaoDoPlayer.Detalhes.ID == missao.ID)
                {
                    return missaoDoPlayer.Finalizada;
                }
            }
            return false;
        }

        public bool PossuiItensParaCompletarMissao(Quest missao)
        {
            foreach (QuestCompletionItem qci in missao.ItensMissaoCompleta)
            {
                bool foundItemInPlayersInventory = false;

                foreach (ItemDeInventario ii in Inventario)
                {
                    // Ele possuí o item da missão
                    if (ii.Detalhes.ID == qci.Detalhes.ID)
                    {
                        foundItemInPlayersInventory = true;
                        // Verifica se ele tem a quantidade necessária para concluir a missão.
                        if (ii.Quantidade < qci.Quantidade)
                        {
                            return false;
                        }
                    }
                }
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }
            // Se bateu aqui, ele tem todos os itens e suas quantidades.
            return true;
        }

        public void RemoveItensDaMissaoCompletada(Quest missao) // como se o player estivesse devolvendo o item que ele foi buscar na missão
        {
            foreach (QuestCompletionItem qci in missao.ItensMissaoCompleta)
            {
                foreach (ItemDeInventario ii in Inventario)
                {
                    if (ii.Detalhes.ID == qci.Detalhes.ID)
                    {
                        ii.Quantidade -= qci.Quantidade;
                        break;
                    }
                }
            }
        }

        public void AdicionaItemAoInventario(Item itemParaSerAdicionado)
        {
            foreach (ItemDeInventario ii in Inventario)
            {
                if (ii.Detalhes.ID == itemParaSerAdicionado.ID)
                {
                    //Caso ele tenha o item no inventário, apenas incrementamos.
                    ii.Quantidade++;
                    return;
                }
            }
            //Caso não tenha, adicionamos 1.
            Inventario.Add(new ItemDeInventario(itemParaSerAdicionado, 1));
        }

        public void MarcaMIssaoComoCompleta(Quest missao)
        {
            foreach (PlayerQuest pq in Missoes)
            {
                if (pq.Detalhes.ID == missao.ID)
                {
                    pq.Finalizada = true;
                    return;
                }
            }
        }
    }
}