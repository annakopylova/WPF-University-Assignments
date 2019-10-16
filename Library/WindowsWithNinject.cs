using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ninject;
using Ninject.Modules;
using System.Reflection;
using BLL;

namespace Library
{
    class WindowsWithNinject : Window
    {
        protected IDatabase database;

        public WindowsWithNinject()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            database = kernel.Get<IDatabase>();
        }
    }
}
