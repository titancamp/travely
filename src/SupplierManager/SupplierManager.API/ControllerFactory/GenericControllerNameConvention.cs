using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using SupplierManager.API.Controllers;

namespace SupplierManager.API.ControllerFactory
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GenericControllerNameConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerType.IsGenericType || controller.ControllerType.GetGenericTypeDefinition() !=
                typeof(SupplierController<,,>)) return;
            var entityType = controller.ControllerType.GenericTypeArguments[0];
            controller.ControllerName = entityType.Name;
            controller.RouteValues["Controller"] = entityType.Name;
        }
    }
}