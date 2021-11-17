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
			if (IsExpired())
			{
				m_state = ShopPackState.Expired;
			}
		}

		public bool IsExpired()
		{
			return m_data.isTimed && remainingTime.TotalSeconds < 0;
		}

    }
}
