﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library.ViewEntities.Models.PublicHouseView
{
    [DataContract]
    public class PublicHouseViewToUpdate
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }

        public PublicHouseViewToUpdate()
        {

        }

    }
}