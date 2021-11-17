using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class ErrorViewModel : ViewModelBase
    {
        private bool m_isVisible = true;
        private string m_errorMessage = "";

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

        public string errorMessage
        {
            get { return m_errorMessage; }
            set
            {
                if (value != m_errorMessage)
                {
                    m_errorMessage = value;
                    NotifyPropertyChanged(nameof(errorMessage));
                }
            }
        }

        public void Initialize()
        {
            Deactive();
        }

        public void Active()
        {
            isVisible = true;
        }

        public void Deactive()
        {
            isVisible = false;
        }
    }
}
