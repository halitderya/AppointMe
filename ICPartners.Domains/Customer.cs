using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ICPartners.Domains
{
    public class Customer : INotifyPropertyChanged
    {
        private string _title;
        private string _name;
        private string _surname;
        private string _email;
        private string _phone;
        private string _address;
        private string _postcode;
        private string _city;


        public Customer(String Value)
        {
            this.CustomerName = Value;
        }
        public Customer()
        {

        }
        public int CustomerID { get; set; }

        public string  CustomerTitle
        {
            get { return _title; }

            set
            {
                _title = value;
                OnPropertyChanged("CustomerTitle");
            }
        }
        public string CustomerName {
            get { return _name; }

            set
            {
                _name = value;
                OnPropertyChanged("CustomerName");
            }


        }
        public string  CustomerSurname {
            get { return _surname; }

            set
            {
                _surname = value;
                OnPropertyChanged("CustomerSurname");
            }


        }
        public string CustomerEmail {
            get { return _email; }

            set
            {
                _email = value;
                OnPropertyChanged("CustomerEmail");
            }
        }
        public string CustomerPhone {
            get { return _phone; }

            set
            {
                _phone = value;
                OnPropertyChanged("CustomerPhone");
            }
        }
        public string CustomerAddress {
            get { return _address; }

            set
            {
                _address = value;
                OnPropertyChanged("CustomerAddress");
            }


        }
        public string CustomerPostCode {
            get { return _postcode; }

            set
            {
                _postcode = value;
                OnPropertyChanged("CustomerPostCode");
            }



        }
        public string CustomerCity {
            get { return _city; }

            set
            {
                _city = value;
                OnPropertyChanged("CustomerCity");
            }

        }

        public ICollection<Appointment> Appointments { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
                
            }
        }
    }
}
