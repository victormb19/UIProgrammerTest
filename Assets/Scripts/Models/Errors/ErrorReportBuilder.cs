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
                             {ErrorType.NotEnoughCurrency, "Not Enough currency!" /*LocalizationManager.instance.Localize("")*/ },
                             {ErrorType.StoreFailed,"Store Failed!" /*LocalizationManager.instance.Localize("")*/ },
                             {ErrorType.Unknown, LocalizationManager.instance.Localize("TID_ERROR_GENERIC")}
                         };
        }

        public ErrorReport Build(ErrorType errorType)
        {
            m_errorMessages.TryGetValue(errorType, out string errorMesage);
            return new ErrorReport(errorMesage);
        }
    }
}
