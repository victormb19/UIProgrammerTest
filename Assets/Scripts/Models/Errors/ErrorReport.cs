namespace Ubisoft.UIProgrammerTest.Models.Errors
{
    public class ErrorReport
    {
        private string m_errorMessage;

        public ErrorReport (string errorMessage)
        {
            m_errorMessage = errorMessage;
        }

        public string errorMessage
        {
            get { return m_errorMessage; }
        }
    }
}
