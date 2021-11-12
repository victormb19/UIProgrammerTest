using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class LoadingViewModel : ViewModelBase
    {
        private bool m_isVisible;

        public bool isVisible
        {
            get { return m_isVisible; }
            set
            {
                if (value != m_isVisible)
                {
                    m_isVisible = value;
                    NotifyPropertyChanged(nameof(isVisible));
                }
            }
        }
    }
}
