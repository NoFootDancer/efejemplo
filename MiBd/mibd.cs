using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1;

namespace WpfApplication1
{
   public class mibd : DbContext

    {
       public DbSet <Empleados> Empleados { get; set;}
       public DbSet <Departamento> Departamentos { get; set;}
    }
}
