using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarTracker.Models
{
    public static class Factory
    {
        public static BarLogic GetBarLogic()
        {
            return new BarLogic();
        }
        public static UserLogic GetUserLogic()
        {
            return new UserLogic();
        }
    }
}