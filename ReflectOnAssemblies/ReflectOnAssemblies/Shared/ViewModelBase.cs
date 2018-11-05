using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ReflectOnAssemblies.Shared
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChanged

        public virtual void NotifyPropertyChanged([CallerMemberName]string propName = null,
            [CallerMemberName]object sender = null)
        {
            if (sender == null)
                sender = this;
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propName));
        }
    }
}
