using AutoMapper;
using Library.Entities.Models;
using Library.ViewEntities.Models.BrochureView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.MapperProfiles
{
    public class BrochureProfile : Profile
    {
        public BrochureProfile()
        {

            CreateMap<Brochure, BrochureView>();
            CreateMap<BrochureView, Brochure>();
            CreateMap<Brochure, BrochureViewToUpdate>();
            CreateMap<BrochureViewToUpdate, Brochure>();

        }

    }
}

