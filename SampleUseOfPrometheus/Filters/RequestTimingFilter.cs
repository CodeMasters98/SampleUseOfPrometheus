using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace SampleUseOfPrometheus.Filters;

public class RequestTimingFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        context.HttpContext.Items["Timer"] = Stopwatch.StartNew();
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        var timer = context.HttpContext.Items["Timer"] as Stopwatch;
        timer.Stop();
        //Record request duration
        //var appMetrics = context.HttpContext.RequestServices.GetRequiredService<IAppMetrics>();
        //appMetrics.Measure.RequestDuration.Measure(timer.Elapsed);
    }
}
