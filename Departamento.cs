﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
   public class Departamento
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }

    }
}
