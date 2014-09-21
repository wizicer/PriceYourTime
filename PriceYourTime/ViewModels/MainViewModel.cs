using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PriceYourTime.Resources;

namespace PriceYourTime.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Result = "change things to continue";
        }

        private string _sampleProperty = "Sample Runtime Property Value";

        private int timeCost;

        private int yearSalary;

        private int minToSwitchWork;

        private string result;


        public int TimeCost
        {
            get
            {
                return this.timeCost;
            }
            set
            {
                if (value != timeCost)
                {
                    this.timeCost = value;
                    this.Calculate();
                    NotifyPropertyChanged("TimeCost");
                }
            }
        }

        public int YearSalary
        {
            get
            {
                return this.yearSalary;
            }
            set
            {
                if (value != yearSalary)
                {
                    this.yearSalary = value;
                    this.Calculate();
                    NotifyPropertyChanged("YearSalary");
                }
            }
        }

        public int MinToSwitchWork
        {
            get
            {
                return this.minToSwitchWork;
            }
            set
            {
                if (value != minToSwitchWork)
                {
                    this.minToSwitchWork = value;
                    this.Calculate();
                    NotifyPropertyChanged("MinToSwitchWork");
                }
            }
        }

        private void Calculate()
        {
            var daysalary = (double)this.yearSalary / 52 / 5;
            var minsalary = daysalary / 8 / 60;

            var cost = minsalary * (this.minToSwitchWork * 2 + this.timeCost);

            this.Result = string.Format("it cost you {0}", cost);
        }

        public string Result
        {
            get
            {
                return this.result;
            }
            set
            {
                if (value != result)
                {
                    this.result = value;
                    NotifyPropertyChanged("Result");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded { get; private set; }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            this.YearSalary = 200000;
            this.MinToSwitchWork = 5;
            this.TimeCost = 10;

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}