using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.GwinApplication.DAL
{
    public class GwinBaseDAO<T> : IGwinBaseDAO where T : BaseEntity
    {

    }
}
