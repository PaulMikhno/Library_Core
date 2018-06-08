using AutoMapper;
using Library.DAL;
using Library.DAL.Repositories;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Library.ViewEntities.Models.MagazineView;
using Dapper;
using Library.BLL.MapperProfiles;

namespace Library.BLL.Servises
{
    public class MagazineService
    {
        //private LibraryContext _libraryContext;
        private DapperGenericRepository<Magazine> _magazineRepository;

        public MagazineService(string connectionString="")
        {
           // this._libraryContext = new LibraryContext(connectionString);
            this._magazineRepository = new DapperGenericRepository<Magazine>(connectionString);
           
        }

        public IEnumerable<MagazineView> Get()
        {
            

            IEnumerable<Magazine> magazineFromDB = _magazineRepository.Get();
          
            var magazines = Mapper.Map<IEnumerable<Magazine>, List<MagazineView>>(magazineFromDB);

            return magazines;
        }

        public MagazineView Get(int id)
        {
            Magazine magazineFromDB = _magazineRepository.Get(id);
           
            var magazines = Mapper.Map<Magazine, MagazineView>(magazineFromDB);
            return magazines;
        }

        public void Remove(int id)
        {
            _magazineRepository.Remove(id);
        }

        public void Update(MagazineViewToUpdate magazineView)
        {
           
            var magazine = Mapper.Map<MagazineViewToUpdate, Magazine>(magazineView);
            _magazineRepository.Update(magazine);
        }
        public void Create(MagazineView magazineView)
        {
           
            var magazine = Mapper.Map<MagazineView, Magazine>(magazineView);
            _magazineRepository.Create(magazine);

        }
    }
}
