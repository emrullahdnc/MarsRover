using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.App.Extensions
{
    public static class CommonExtensions
    {
        public static Exception GetInnerException(Exception ex)
        {

            var innerException = ex;
            while (innerException != null && innerException.InnerException != null)
            {
                innerException = innerException.InnerException;
            }

            return innerException;


        }
    }
}
