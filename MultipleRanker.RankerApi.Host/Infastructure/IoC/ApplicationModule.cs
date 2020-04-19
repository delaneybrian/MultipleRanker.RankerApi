using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace MultipleRanker.RankerApi.Host.Infastructure.IoC
{
    internal class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
