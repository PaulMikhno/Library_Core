using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Library.ViewEntities.Models.PublicHouseView;

namespace Library.ViewEntities.Models.BookView
{
    [DataContract]
    public class BookView
    { 
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string YearOfPublishing { get; set; }

        public  List<PublicHouseView.PublicHouseView> PublicHouses { get; set; }

        public BookView()
        {
            PublicHouses = new List<PublicHouseView.PublicHouseView>();
        }

    }
}