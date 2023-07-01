﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticaRedSocial.Models
{
    public class SocialNetwork
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<User> Users { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
