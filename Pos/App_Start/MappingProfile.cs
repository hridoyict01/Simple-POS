using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Pos.Dtos;
using Pos.Models;

namespace Pos.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();
        }
    }
}