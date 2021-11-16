using System.Collections.Generic;

namespace Ubisoft.UIProgrammerTest.Models.Errors
{
    public class ErrorReportBuilder
    {
        private Dictionary<ErrorType, string> m_errorMessages;

        public ErrorReportBuilder()
        {
            m_errorMessages = new Dictionary<ErrorType, string>()
                         {
                             {ErrorType.NotEnoughCurrency, "" },
                             {ErrorType.StoreFailed, "" },
                             {ErrorType.Unknown, ""}
                         };
        }

        public ErrorReport Build(ErrorType errorType)
        {
            m_errorMessages.TryGetValue(errorType, out string errorMesage);
            return new ErrorReport(errorMesage);
        }
    }
}
