using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.Autorizations
{
    public enum UserActionInGwin
    {
        Empty,
        Create,
        Read,
        Update,
        Delete,
        Export_XML,
        Export_Excel,
        CRUD,
        Manager,
        All
    }
}
