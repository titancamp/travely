using AutoMapper;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using Travely.Common;
using Travely.ReportingManager.Profiles.Converters;
using Travely.ReportingManager.Protos;
using Travely.ReportingManager.Services.Models.Commands;
using Travely.ReportingManager.Services.Models.Responses;

namespace Travely.ReportingManager.Profiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<DateTime, Timestamp>().ConvertUsing((s, d) =>
            {
                return Timestamp.FromDateTime(DateTime.SpecifyKind(s, DateTimeKind.Utc));
            });

            CreateMap<Timestamp, DateTime>().ConvertUsing((s, d) =>
            {
                return s.ToDateTime();
            });
        }
    }
}
