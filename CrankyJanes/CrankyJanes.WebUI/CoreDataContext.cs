using CrankyJanes.Core;
using CrankyJanes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrankyJanes.WebUI
{
    public static class CoreData
    {
        public static EntityDataContext Context
        {
            get
            {
                return new EntityDataContext();
            }
        }
    }
}