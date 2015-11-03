using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class demoEf
    {
        DbSet<Empleados> Empleados { get; set; }
    }
}
