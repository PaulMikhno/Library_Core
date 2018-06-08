using AutoMapper;
using Library.Entities.Models;
using Library.ViewEntities.Models.MagazineView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.MapperProfiles
{
    public class MagazineProfile : Profile
    {
        public MagazineProfile()
        {
            CreateMap<Magazine, MagazineView>();
            CreateMap<MagazineView, Magazine>();
            CreateMap<Magazine, MagazineViewToUpdate>();
            CreateMap<MagazineViewToUpdate, Magazine>();

        }

    }
}

