using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Store.Web
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment webHostEnviroment;

        public ExceptionFilter(IWebHostEnvironment webHostEnviroment)
        {
            this.webHostEnviroment = webHostEnviroment;
        }

        public void OnException(ExceptionContext context)
        {
            if (webHostEnviroment.IsDevelopment())
                return;

            if(context.Exception.TargetSite.Name == "ThrowNoElementsException")
            {
                context.Result = new ViewResult
                {
                    ViewName = "NotFound",
                    StatusCode = 404,
                };
            }
        }
    }
}
