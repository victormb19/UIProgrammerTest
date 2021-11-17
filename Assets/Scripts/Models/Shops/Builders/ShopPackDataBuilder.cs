using SimpleJSON;
using Ubisoft.UIProgrammerTest.Models.Currencies;

namespace Ubisoft.UIProgrammerTest.Models.Shops.Builders
{
    public class ShopPackDataBuilder
    {
		private const string IdKey = "id";
		private const string TypeKey = "type";
		private const string OrderKey = "order";
		private const string DurationKey = "duration";
		private const string TidNameKey = "tidName";
		private const string FeaturedKey = "featured";
		private const string PriceKey = "price";
		private const string CurrencyKey = "currency";
		private const string DiscountKey = "discount";
		private const string ItemsKey = "items";

		private ShopPackData m_shopPackData;
		private JSONNode m_data;

		public ShopPackDataBuilder(JSONNode data)
        {
			m_shopPackData = new ShopPackData();
			m_data = data;
		}
		public ShopPackData Build()
		{
			if (m_data.HasKey(IdKey))
			{
				m_shopPackData.id = m_data[IdKey];
			}

			if (m_data.HasKey(TypeKey))
			{
				ShopType shopType;
				Utils.EnumTryParse(m_data[TypeKey], true, out shopType);
				m_shopPackData.type = shopType;
			}

			// Secondary data
			if (m_data.HasKey(OrderKey))
			{
				m_shopPackData.order = m_data[OrderKey].AsInt;
			}

			if (m_data.HasKey(DurationKey))
			{
				m_shopPackData.duration = m_data[DurationKey].AsFloat;
			}

			// Visuals
			if (m_data.HasKey(TidNameKey))
			{
				m_shopPackData.tidName = m_data[TidNameKey];
			}

			if (m_data.HasKey(FeaturedKey))
			{
				m_shopPackData.featured = m_data[FeaturedKey].AsBool;
			}

			// Pricing
			if (m_data.HasKey(PriceKey))
			{
				m_shopPackData.price = m_data[PriceKey].AsFloat;
			}

			if (m_data.HasKey(CurrencyKey))
			{
				CurrencyType currency;
				Utils.EnumTryParse(m_data[CurrencyKey], true, out currency);
				m_shopPackData.currency = currency;
			}

			if (m_data.HasKey(DiscountKey))
			{
				m_shopPackData.discount = m_data[DiscountKey].AsFloat;
			}

			// Items
			if (m_data.HasKey(ItemsKey))
			{
				JSONArray itemsData = m_data[ItemsKey].AsArray;
				m_shopPackData.items = new ShopItemData[itemsData.Count];
				for (int i = 0; i < itemsData.Count; ++i)
				{
					m_shopPackData.items[i] = new ShopItemDataBuilder(itemsData[i]).Build();
				}
			}

			return m_shopPackData;
		}

	}
}
