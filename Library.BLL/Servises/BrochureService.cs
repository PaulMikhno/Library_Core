using AutoMapper;
using Library.DAL;
using Library.DAL.Repositories;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Library.ViewEntities.Models.BrochureView;

namespace Library.BLL.Servises
{
    public class BrochureService
    {
       // private LibraryContext _libraryContext;

        private DapperGenericRepository<Brochure> _brochureRepository;

        public BrochureService(string connectionString="")
        {
          //  this._libraryContext = new LibraryContext(connectionString);
            this._brochureRepository = new DapperGenericRepository<Brochure>(connectionString);
        }

        public IEnumerable<BrochureView> Get()
        {
            IEnumerable<Brochure> brochureFromDB = _brochureRepository.Get();
            
            var brochures = Mapper.Map<IEnumerable<Brochure>, List<BrochureView>>(brochureFromDB);

            return brochures;
        }

        public BrochureView Get(int id)
        {
            Brochure brochureFromDB = _brochureRepository.Get(id);
          
            var brochure = Mapper.Map<Brochure, BrochureView>(brochureFromDB);
            return brochure;
        }

        public void Remove(int id)
        {
            _brochureRepository.Remove(id);
        }

        public void Update(BrochureViewToUpdate brochureView)
        {
            var brochure = Mapper.Map<BrochureViewToUpdate, Brochure>(brochureView);
            _brochureRepository.Update(brochure);
        }
        public void Create(BrochureView brochureView)
        {
            var brochure = Mapper.Map<BrochureView, Brochure>(brochureView);

            _brochureRepository.Create(brochure);

        }
    }
}
