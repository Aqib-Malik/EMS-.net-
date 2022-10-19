using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace EMS.filtration
{
    public class LogAttribute : Attribute, IActionFilter
    {
        public LogAttribute()
        {

        }

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            Trace.WriteLine(string.Format("Action Method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");

            var result = continuation();

            result.Wait();

            Trace.WriteLine(string.Format("Action Method {0} executed at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");

            return result;
        }

        public bool AllowMultiple
        {
            get { return true; }
        }
    }

}
