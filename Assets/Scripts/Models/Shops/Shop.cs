using System.Collections.Generic;
using Ubisoft.UIProgrammerTest.Models.Shops.Builders;
using UnityEngine;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class Shop
    {
        private List<ShopPack> m_activePacks = new List<ShopPack>();    // Not sorted
        private List<ShopPack> m_activeOfferPacks = new List<ShopPack>();
        private List<ShopPackData> m_offerPacksDatabase = new List<ShopPackData>();
        private Queue<string> m_offerPacksHistory = new Queue<string>();

		private const int ActiveOfferPacks = 3;
		private const int OffersHistoryMaxSize = ActiveOfferPacks + 1;

		public List<ShopPack> activePacks
        {
            get { return m_activePacks; }
        }

        public List<ShopPack> activePacksGems
        {
            get { return m_activePacks.FindAll(item => item.data.type == ShopType.Gems); }
        }

        public List<ShopPack> activePacksCoins
        {
            get { return m_activePacks.FindAll(item => item.data.type == ShopType.Coins); }
        }

        public Shop(List<ShopPackData> m_shopPackDatas)
        {
            Clear();
            m_offerPacksDatabase.AddRange(m_shopPackDatas.FindAll(shopPackData => shopPackData.type == ShopType.Offer));
            List<ShopPackData> shopPackDatasWithoutOffer = m_shopPackDatas.FindAll(shopPackData => shopPackData.type != ShopType.Offer);
            shopPackDatasWithoutOffer.ForEach(shopPackData => CreateAndActivatePack(shopPackData));
        }

        private void CreateAndActivatePack(ShopPackData _packData)
		{
			// Create a new pack with given data
			ShopPack newPack = new ShopPackBuilder(_packData).Build();

			// Put it in the target collections
			m_activePacks.Add(newPack);

			// Some extra processing required for offer packs
			if (newPack.data.type == ShopType.Offer)
			{
				// Add it to the active offer packs
				m_activeOfferPacks.Add(newPack);

				// Put it to the offers history
				m_offerPacksHistory.Enqueue(_packData.id);

				// Purge history until we have the right size
				while (m_offerPacksHistory.Count > OffersHistoryMaxSize)
				{
					m_offerPacksHistory.Dequeue();
				}
			}

			// Activate pack!
			newPack.Activate();
		}

        public void Refresh()
        {
            RemoveExpiredPacks();

            // Do we need to activate a new offer pack?
            int loopCount = 50; // Just in case, prevent infinite loop
            while (m_activeOfferPacks.Count < ActiveOfferPacks && loopCount > 0)
            {
                // Decrease loop counter
                loopCount--;

                // Create a pool of selectable packs
                List<ShopPackData> pool = new List<ShopPackData>();
                for (int i = 0; i < m_offerPacksDatabase.Count; ++i)
                {
                    // Don't use this pack if it has been used recently
                    if (m_offerPacksHistory.Contains(m_offerPacksDatabase[i].id))
                        continue;

                    // All checks passed! Add pack to the pool
                    pool.Add(m_offerPacksDatabase[i]);
                }

                // Do we have any valid candidates?
                if (pool.Count > 0)
                {
                    // Yes!! Pick a random pack from the pool and activate it!
                    ShopPackData newPackData = pool[Random.Range(0, pool.Count)];
                    CreateAndActivatePack(newPackData);
                }
                else
                {
                    // No!! (shouldn't happen) Remove last entry from the history and skip to next loop
                    m_offerPacksHistory.Dequeue();
                    continue;
                }
            }
        }

        private void RemoveExpiredPacks()
        {
            // Aux vars
            List<ShopPack> toRemove = new List<ShopPack>();

            // Loop through all active packs and check those that need to be expired
            for (int i = 0; i < m_activePacks.Count; ++i)
            {
                // Needs to be expired?
                m_activePacks[i].CheckExpiration();
                if (m_activePacks[i].IsExpired())
                {
                    toRemove.Add(m_activePacks[i]);
                }
            }

            // Remove all the packs requiring so
            for (int i = 0; i < toRemove.Count; ++i)
            {
                RemovePack(toRemove[i]);
            }
        }

        private void RemovePack(ShopPack pack)
        {
            // Remove it for collections
            m_activePacks.Remove(pack);
            m_activeOfferPacks.Remove(pack);
        }


        public void Clear()
        {
            m_offerPacksDatabase.Clear();
            m_activeOfferPacks.Clear();
            m_activePacks.Clear();
        }
    }
}
