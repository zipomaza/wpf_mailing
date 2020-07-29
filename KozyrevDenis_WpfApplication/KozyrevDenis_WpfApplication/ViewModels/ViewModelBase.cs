﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KozyrevDenis_WpfApplication.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void UpdateValue<TValue>(TValue value, ref TValue storage, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TValue>.Default.Equals(value, storage))
            {
                return;
            }

            storage = value;
            this.RaisePropertyChanged(propertyName);
        }
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
