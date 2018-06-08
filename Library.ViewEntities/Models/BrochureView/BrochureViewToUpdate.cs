using ViewEntities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library.ViewEntities.Models.BrochureView
{
    [DataContract]
    public class BrochureViewToUpdate
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public TypeOfCoverView TypeOfCover { get; set; }

        [DataMember]
        public int NumberOfPages { get; set; }
    }
}