using CrankyJanes.Core;
using CrankyJanes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrankyJanes.WebUI
{
    public static class ControllerExtensions
    {
        public static UserProfile GetUser(this Controller controller)
        {
            using (var context = CoreData.Context)
            {
                return context.UserProfiles.SingleOrDefault(u => u.UserName == controller.User.Identity.Name);
            }
        }

        public static UserProfile GetUser(this Controller controller, EntityDataContext context)
        {
            return context.UserProfiles.SingleOrDefault(u => u.UserName == controller.User.Identity.Name);
        }
    }
}