using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TechAndTools.Web.Commons
{
    public static class GlobalConstants
    {
        //Roles
        public const string AdminRole = "Admin";
        public const string UserRole = "User";

        //Shopping Cart
        public const string SessionShoppingCartKey = "shoppingCart";

        public const string AuthCookieName = "AuthCookie";

        public const int DefaultProductQuantity = 1;
    }
}
