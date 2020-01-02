using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Blog.Common.Engineer
{
    public class EngineerContext
    {
        public static IEngineer _engineer;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngineer Initialize(IEngineer engineer)
        {
            if (_engineer == null)
                _engineer = engineer;
            return _engineer;
        }


        public static IEngineer Current
        {
            get { return _engineer; }
        }

    }
}
