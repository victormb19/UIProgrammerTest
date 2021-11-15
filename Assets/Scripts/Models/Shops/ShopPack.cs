using System;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class ShopPack
    {
        private ShopPackData m_data = null;
        private ShopPackState m_state = ShopPackState.PendingActivation;
        private DateTime m_endTimestamp = DateTime.MaxValue;

		public ShopPackData data
		{
			get { return m_data; }
			set { m_data = value; }
		}

		public TimeSpan remainingTime
		{
			get { return m_endTimestamp - DateTime.UtcNow; }
		}

		public ShopPackState state
		{
			get { return m_state; }
		}

		public void Activate()
		{
			// Only for packs in the right state
			if (m_state != ShopPackState.PendingActivation)
				return;

			// Calculate expiration timestiamp
			m_endTimestamp = DateTime.UtcNow + TimeSpan.FromMinutes(m_data.duration);

			// Change state
			m_state = ShopPackState.Active;
		}

		/// <summary>
		/// Check whether this shop pack needs to be expired and mark it as expired if so.
		/// Only valid for packs in ACTIVE state.
		/// </summary>
		public void CheckExpiration()
		{
			// Only active packs
			if (m_state != ShopPackState.Active)
				return;

			// If pack is timed and expiration date has passed, mark it as expired
			if (m_data.isTimed && remainingTime.TotalSeconds < 0)
			{
				m_state = ShopPackState.Expired;
			}
		}

		/// <summary>
		/// Apply this pack's rewards to the current User Profile.
		/// Won't do any checks!
		/// </summary>
		public void Apply()
		{
			// Apply rewards!
			for (int i = 0; i < m_data.items.Length; ++i)
			{
				//m_data.items[i].Apply();
			}

			// If offer pack, mark it as expired so the pack is removed from the manager
			if (m_data.type == ShopType.Offer)
			{
				m_state = ShopPackState.Expired;
			}
		}

		/// <summary>
		/// String representation of this pack.
		/// </summary>
		public override string ToString()
		{
			// Pack Type + ID
			string str = data.type + " " + data.id;

			// Price
			str += " [" + data.price + " " + data.currency + "]";

			// Remaining time
			if (data.isTimed && state == ShopPackState.Active)
			{
				str += "\n" + remainingTime.ToString();
			}

			// Items
			for (int i = 0; i < data.items.Length; ++i)
			{
				str += "\n\t" + data.items[i].ToString();
			}

			return str;
		}
	}
}
