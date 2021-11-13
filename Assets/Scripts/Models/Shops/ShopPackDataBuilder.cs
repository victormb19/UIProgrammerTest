using SimpleJSON;
using Ubisoft.UIProgrammerTest.Models.Currencies;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class ShopPackDataBuilder
    {
        private ShopPackData m_shopPackData;
		private JSONNode m_data;


		public ShopPackDataBuilder(JSONNode data)
        {
			m_shopPackData = new ShopPackData();
			m_data = data;
		}
		
		public ShopPackData Build()
		{
			return m_shopPackData;
		}

		public ShopPackData CreateFromJson()
		{
			if (m_data.HasKey("id"))
			{
				m_shopPackData.id = m_data["id"];
			}

			if (m_data.HasKey("type"))
			{
				ShopType shopType;
				Utils.EnumTryParse(m_data["type"], true, out shopType);
				m_shopPackData.type = shopType;
			}

			// Secondary data
			if (m_data.HasKey("order"))
			{
				m_shopPackData.order = m_data["order"].AsInt;
			}

			if (m_data.HasKey("duration"))
			{
				m_shopPackData.duration = m_data["duration"].AsFloat;
			}

			// Visuals
			if (m_data.HasKey("tidName"))
			{
				m_shopPackData.tidName = m_data["tidName"];
			}

			if (m_data.HasKey("featured"))
			{
				m_shopPackData.featured = m_data["featured"].AsBool;
			}

			// Pricing
			if (m_data.HasKey("price"))
			{
				m_shopPackData.price = m_data["price"].AsFloat;
			}

			if (m_data.HasKey("currency"))
			{
				CurrencyType currency;
				Utils.EnumTryParse(m_data["currency"], true, out currency);
				m_shopPackData.currency = currency;
			}

			if (m_data.HasKey("discount"))
			{
				m_shopPackData.discount = m_data["discount"].AsFloat;
			}

			// Items
			if (m_data.HasKey("items"))
			{
				SimpleJSON.JSONArray itemsData = m_data["items"].AsArray;
				m_shopPackData.items = new ShopItemData[itemsData.Count];
				for (int i = 0; i < itemsData.Count; ++i)
				{
					m_shopPackData.items[i] = ShopItemData.CreateFromJson(itemsData[i]);
				}
			}

			return m_shopPackData;
		}

	}
}
