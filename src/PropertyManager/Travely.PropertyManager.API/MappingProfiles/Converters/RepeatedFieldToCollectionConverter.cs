using System.Collections.Generic;
using AutoMapper;
using Google.Protobuf.Collections;

namespace Travely.PropertyManager.API.MappingProfiles.Converters
{
    internal class RepeatedFieldToCollectionConverter<TSource, TDest> : ITypeConverter<RepeatedField<TSource>, ICollection<TDest>>
    {
        public ICollection<TDest> Convert(RepeatedField<TSource> source, ICollection<TDest> destination, ResolutionContext context)
        {
            destination ??= new List<TDest>();

            foreach (var item in source)
            {
                destination.Add(context.Mapper.Map<TDest>(item));
            }

            return destination;
        }
    }
}
