using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using SupplierManager.API.Controllers;

namespace SupplierManager.API.ControllerFactory
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var (entityType, value) in EntityTypes.ModelTypes)
            {
                Type[] typeArgs = {entityType, value[0], value[1]};
                var controllerType = typeof(SupplierController<,,>).MakeGenericType(typeArgs).GetTypeInfo();
                feature.Controllers.Add(controllerType);
            }
        }
    }
}