using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using DAL;
using BLL;

namespace Library
{
    class Bindings: NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabase>().To<SQLDatabase>();
        }
    }
}
