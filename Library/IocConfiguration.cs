using BLL;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabase>().To<MongoDatabase>().InSingletonScope(); // Чтобы не пересоздавалась каждый раз
        }
    }
}
