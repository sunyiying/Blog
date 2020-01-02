using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Common.Engineer
{
    public class GeneralEngineer : IEngineer
    {
        private IServiceProvider _serviceProvider;

        public GeneralEngineer(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public T Resolve<T>() where T : class
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
