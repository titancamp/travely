using System.Collections.Generic;
using System.Reflection;
using SupplierManager.API.Requests;
using SupplierManager.API.Responses;
using SupplierManager.Service.Models;

namespace SupplierManager.API.ControllerFactory
{
    public static class EntityTypes
    {
        public static Dictionary<TypeInfo, List<TypeInfo>> ModelTypes => new()
        {
            {
                typeof(Accommodation).GetTypeInfo(),
                new List<TypeInfo>
                    {typeof(AccommodationRequest).GetTypeInfo(), typeof(AccommodationResponse).GetTypeInfo()}
            },
            {
                typeof(Transportation).GetTypeInfo(),
                new List<TypeInfo>
                    {typeof(TransportationRequest).GetTypeInfo(), typeof(TransportationResponse).GetTypeInfo()}
            }
        };
    }
}