using AutoMapper;
using Library.Entities.Models;
using Library.ViewEntities.Models.PublicHouseView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.BLL.MapperProfiles
{
    public class PublicHouseProfile : Profile
    {
        public PublicHouseProfile()
        {
            CreateMap<PublicHouse, PublicHouseView>();
            CreateMap<PublicHouseView, PublicHouse>();
            CreateMap<PublicHouse, PublicHouseViewToUpdate>();
            CreateMap<PublicHouseViewToUpdate, PublicHouse>();

        }

    }
}

