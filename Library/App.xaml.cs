using Ninject;
using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Library
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            IocKernel.Initialize(new IocConfiguration());

            IocKernel.Get<IDatabase>().init();

            base.OnStartup(e);
        }
    }
}
