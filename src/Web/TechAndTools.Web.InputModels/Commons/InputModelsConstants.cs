using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TechAndTools.Web.InputModels.Commons
{
    public static class InputModelsConstants
    {
        //error messages
        public const string RequiredMessage = @"Полето ""{0}"" е задължително.";

        public const string RangeMessage = @"{0} може да бъде число между {1} и {2}.";

        public const string StringLengthMessage = @"""{0}"" може да бъде между {2} и {1} символа.";
    }
}
