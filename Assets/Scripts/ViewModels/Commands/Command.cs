using UnityMVVM.Util;

namespace Ubisoft.UIProgrammerTest.ViewModels.Commands
{
    public abstract class Command
    {
        protected ViewModelProvider m_viewModelProvider;

        public Command()
        {
            m_viewModelProvider = ViewModelProvider.Instance;
        }

        public abstract void Execute();
    }
}
