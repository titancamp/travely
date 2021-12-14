using AutoMapper;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travely.ReportingManager.Profiles.Converters
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
