using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FL_TUR.ViewModel
{
    public class ResultadoSorteioViewModel : INotifyPropertyChanged
    {


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
        #endregion
    
    }
}
