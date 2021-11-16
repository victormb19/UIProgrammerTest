using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

namespace Ubisoft.UIProgrammerTest.Models.Shops.Builders
{
    public class ShopBuilder
    {
        private const string PacksKey = "packs";
        private readonly JSONNode m_data;

        private List<ShopPackData> m_shopPackDatas;

        public ShopBuilder()
        {
            TextAsset txt = Resources.Load<TextAsset>("Data/shop_manager");
            m_data = JSONNode.Parse(txt.text);
            m_shopPackDatas = new List<ShopPackData>();
        }

        public Shop Build()
        {
            if (m_data.HasKey(PacksKey))
            {
                JSONArray packsData = m_data[PacksKey].AsArray;

                for (int i = 0; i < packsData.Count; ++i)
                    m_shopPackDatas.Add(new ShopPackDataBuilder(packsData[i]).Build());
            }
            return new Shop(m_shopPackDatas);
        }
    }
}
