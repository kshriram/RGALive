using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ShippingController_V1._0_.Views
{
    public class ReasonSelectionsPopup : INotifyPropertyChanged
    {
        private String _PopupValue;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        protected void OnPropertyChanged(String PropertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(PropertyName));
        }

        public String UpdatePopupValue
        {
            get { return _PopupValue; }
            set
            {
                if (value != _PopupValue)
                {
                    _PopupValue = value;
                    OnPropertyChanged("UpdatePopupValue");
                }
            }
        }

    }
}