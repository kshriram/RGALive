using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShippingController_V1._0_.Views
{
    public class PopupValue: INotifyPropertyChanged
    {
        private string ResonValue;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public string ReasnValue
        {
            get { return ResonValue; }
            set
            {
                if (value != ResonValue)
                {
                    ResonValue = value;
                    OnPropertyChanged("ReasnValue");
                }
            }
        }


    }
}