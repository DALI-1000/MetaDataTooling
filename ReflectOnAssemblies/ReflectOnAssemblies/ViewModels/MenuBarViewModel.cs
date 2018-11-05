using ReflectOnAssemblies.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectOnAssemblies.ViewModels
{
    public class MenuBarViewModel : ViewModelBase
    {
        public ActionCommand NavigateToSearchImplementationsCommand { get; set; }
            = new ActionCommand(canExecute: (args) => {
                return true;
            }, execute: (args) => {
                NavigationHelper.NavigateToSearchImplemantations();
            });
    }
}
