using Library.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Entities.Models;
using Library.ViewEntities.Models.PublicHouseView;
using AutoMapper;
using Library.DAL.Repositories;

namespace Library.BLL.Servises
{
    public class PublicationHouseService
    {
      //  private DbContext _libraryContext;
        private DapperGenericRepository<PublicHouse> _publicHouseRepository;

        public PublicationHouseService(string connectionString="")
        {
            //_libraryContext = new LibraryContext(connectionString);
            _publicHouseRepository = new DapperGenericRepository<PublicHouse>(connectionString);
        }

        public PublicHouseViewGetAll Get()
        {
            IEnumerable<PublicHouse> publicHouseDB = _publicHouseRepository.Get();
            var publicHouses = Mapper.Map<IEnumerable<PublicHouse>, List<PublicHouseView>>(publicHouseDB);
            PublicHouseViewGetAll publicHouseViewGet = new PublicHouseViewGetAll();

            publicHouseViewGet.publicHouseList = publicHouses;
            return publicHouseViewGet;

        }

        public PublicHouseView Get(int id)
        {
            PublicHouse publicHouseDB = _publicHouseRepository.Get(id);
           
            var publicHouse = Mapper.Map<PublicHouse, PublicHouseView>(publicHouseDB);
            return publicHouse;
        }

        public void Remove(int id)
        {
            _publicHouseRepository.Remove(id);
        }

        public void Update(PublicHouseViewToUpdate publicHouseView)
        {

            var publicHouse = Mapper.Map<PublicHouseViewToUpdate, PublicHouse>(publicHouseView);

            _publicHouseRepository.Update(publicHouse);
        }
        public void Create(PublicHouseView publicHousesView)
        {

            var publicHouses = Mapper.Map<PublicHouseView, PublicHouse>(publicHousesView);
           
            _publicHouseRepository.Create(publicHouses);

        }

    }
}
