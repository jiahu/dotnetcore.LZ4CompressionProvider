using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace hu.jia.ZippedWebAPI.Filters
{
    public class LoggingFilterAttribute : TypeFilterAttribute
    {
        public LoggingFilterAttribute() : base(typeof(LoggingFilterImpl))
        {
        }

        private class LoggingFilterImpl : IActionFilter
        {
            private readonly string _value;
            private readonly ILogger<LoggingFilterImpl> _logger;

            public LoggingFilterImpl(string value, ILogger<LoggingFilterImpl> logger)
            {
                _logger = logger;
                _value = value;
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                _logger.LogInformation(_value);
            }

            public void OnActionExecuted(ActionExecutedContext context)
            { }
        }
    }
}
