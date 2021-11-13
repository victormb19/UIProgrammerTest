using Ubisoft.UIProgrammerTest.Models.Currencies;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class ShopPackData
    {
        private string m_id = "";
		private ShopType  m_type = ShopType.Coins;
		private int m_order = 0;  // Order in the shop
		private float m_duration = -1f; // Minutes, negative if it doesn't expire
		private string m_tidName = "";    // Text ID of the pack name
		protected bool m_featured = false;  // Put in the featured spot?
		protected float m_price = 0;

		protected CurrencyType m_currency = CurrencyType.Gems;
		protected float m_discount = 0f;    // [0..1] Percentage of discount
		protected ShopItemData[] m_items = null;

		public string id
		{
			get { return m_id; }
			set { m_id = value; }
		}

		public ShopType type
		{
			get { return m_type; }
			set { m_type = value; }
		}

		// Secondary data
		public int order
		{
			get { return m_order; }
			set { m_order = value; }
		}

		
		public float duration
		{
			get { return m_duration; }
			set { m_duration = value; }
		}

		public bool isTimed
		{
			get { return m_duration > 0f; }
		}

		// Visuals
		public string tidName
		{
			get { return m_tidName; }
			set { m_tidName = tidName; }
		}

		public bool featured
		{
			get { return m_featured; }
			set { m_featured = value; }
		}

		// Pricing
		public float price
		{
			get { return m_price; }
			set { m_price = value; }
		}

		public float priceBeforeDiscount
		{
			get { return m_price / (1f - m_discount); }
		}

		public CurrencyType currency
		{
			get { return m_currency; }
			set { m_currency = value; }
		}

		public float discount
		{
			get { return m_discount; }
			set { m_discount = value; }
		}

		// Items
		public ShopItemData[] items
		{
			get { return m_items; }
			set { m_items =value; }
		}
	}
}
