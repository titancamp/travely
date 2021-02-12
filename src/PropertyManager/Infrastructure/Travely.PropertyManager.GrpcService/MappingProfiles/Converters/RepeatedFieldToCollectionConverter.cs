using AutoMapper;
using Google.Protobuf.Collections;
using System.Collections.Generic;

namespace Travely.PropertyManager.GrpcService.MappingProfiles.Converters
{
    internal class RepeatedFieldToCollectionConverter<TITemSource, TITemDest> : ITypeConverter<RepeatedField<TITemSource>, ICollection<TITemDest>>
    {
        public ICollection<TITemDest> Convert(RepeatedField<TITemSource> source, ICollection<TITemDest> destination, ResolutionContext context)
        {
            destination = destination ?? new List<TITemDest>();
            foreach (var item in source)
            {
                destination.Add(context.Mapper.Map<TITemDest>(item));
            }
            return destination;
        }
    }
}
