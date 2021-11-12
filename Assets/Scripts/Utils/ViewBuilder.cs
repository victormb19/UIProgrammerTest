using UnityEngine;

namespace Ubisoft.UIProgrammerTest
{
    [CreateAssetMenu(fileName = "ViewBuilder", menuName = "Configuration/ViewBuilder", order = 1)]
    public class ViewBuilder : ScriptableObject
    {
        [SerializeField]
        private GameObject m_mainView;

        public void InstantiateView()
        {

        }


    }
}
