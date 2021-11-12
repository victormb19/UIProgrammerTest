namespace Ubisoft.UIProgrammerTest.Models
{
    public interface IObserver
    {
        void Confirmation();
        void Loading();
        void Error();
    }
}