﻿using System.Windows;

namespace MyLaunch.Views.Helpers
{
    public class BindingProxy : Freezable
    {
        public static readonly DependencyProperty DataProperty = DependencyPropertyExtensions.Register();

        public object Data
        {
            get => (object)this.GetValue(DataProperty);
            set => this.SetValue(DataProperty, value);
        }

        protected override Freezable CreateInstanceCore()
            => new BindingProxy();
    }
}