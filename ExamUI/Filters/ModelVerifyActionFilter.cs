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
            //do some things...
        }

        //action调用前触发事件,模型同一验证
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var httpResult = new ProcessResult{ Success=false, Path=string.Empty };
                foreach (var item in context.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        httpResult.Message += error.ErrorMessage;
                    }
                }
                context.Result = new JsonResult(httpResult);
            }
        }
    }
}