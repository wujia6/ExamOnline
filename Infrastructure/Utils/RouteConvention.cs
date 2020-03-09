using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Infrastructure.Utils
{
    /// <summary>
    /// 添加全局路由统一前缀
    /// </summary>
    public class RouteConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _centralPrefix;

        public RouteConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            this._centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        //实现接口
        public void Apply(ApplicationModel application)
        {
            //循环所有controller
            foreach (var controller in application.Controllers)
            {
                //已标记的RouteAttribute的controller
                var matcheds = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                if (matcheds.Any())
                {
                    foreach (var selectorModel in matcheds)
                    {
                        //当前路由前添加路由前缀
                        selectorModel.AttributeRouteModel = AttributeRouteModel
                            .CombineAttributeRouteModel(this._centralPrefix, selectorModel.AttributeRouteModel);
                    }
                }
                //未标记的RouteAttribute的controller
                var unMatcheds = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
                if (unMatcheds.Any())
                {
                    foreach (var selectModel in unMatcheds)
                    {
                        //当前路由前添加路由前缀
                        selectModel.AttributeRouteModel = this._centralPrefix;
                    }
                }
            }
        }
    }
}
