namespace Ubisoft.UIProgrammerTest.Models
{
    public class Subject
    {
		private IObserver m_observer;

		public void Register(IObserver observer)
		{
			m_observer = observer;
		}

		public void Error()
		{
			m_observer.Error();
		}
	}
}
