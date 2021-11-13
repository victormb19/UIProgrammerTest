using System.Collections.Generic;
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

		public Shop()
        {
			TextAsset txt = Resources.Load<TextAsset>("Data/shop_manager");

			// Parse json data
			SimpleJSON.JSONNode data = SimpleJSON.JSONNode.Parse(txt.text);

			// Load all packs data
			Clear();
			if (data.HasKey("packs"))
			{
				SimpleJSON.JSONArray packsData = data["packs"].AsArray;
				for (int i = 0; i < packsData.Count; ++i)
				{
					// Create pack data
					ShopPackData packData = new ShopPackDataBuilder(packsData[i]).Build();

					// Is it an offer pack?
					if (packData.type != ShopType.Offer)
					{
						// No! Activate it directly
						CreateAndActivatePack(packData);
					}
					else
					{
						// Yes! Put it in the offers pool and it will be automatically activated when needed
						m_offerPacksDatabase.Add(packData);
					}
				}
			}
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

			// Notify listeners
			//OnPackActivated.Invoke(newPack);
		}

		public  void Clear()
        {
            m_offerPacksDatabase.Clear();
            m_activeOfferPacks.Clear();
            m_activePacks.Clear();
        }
    }
}
