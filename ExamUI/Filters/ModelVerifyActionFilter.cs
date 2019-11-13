using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExamUI.Filters
{
    /// <summary>
    /// 模型验证过滤器
    /// </summary>
    public class ModelVerifyActionFilter : IActionFilter
    {
        //action调用后触发事件
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        //action调用前触发事件
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var httpResult=new XcHttpResult{ result=false, path=string.Empty };
                foreach (var item in context.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        httpResult.message+=error.ErrorMessage;
                    }
                }
                context.Result=new JsonResult(httpResult);
            }
        }
    }
}