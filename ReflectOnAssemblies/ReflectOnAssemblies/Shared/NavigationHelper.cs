using ReflectOnAssemblies.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReflectOnAssemblies.Shared
{
    public static class NavigationHelper
    {
        public static void NavigateToSearchImplemantations()
        {
            var grid = App.Current.MainWindow?.Content as Grid;
            var userControl = new SearchImplementionsView();
            Grid.SetRow(userControl, 1);
            grid.Children.Add(userControl);
        }
    }
}
