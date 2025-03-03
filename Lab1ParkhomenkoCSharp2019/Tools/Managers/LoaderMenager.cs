﻿using System.Windows;

namespace Lab1ParkhomenkoCSharp2019.Tools.Managers
{
    internal class LoaderManager
    {
        private static readonly object Locker = new object();
        private static LoaderManager _instance;

        internal static LoaderManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                 lock (Locker)
                 {
                     return _instance ?? (_instance = new LoaderManager());
                 }
            }
        }

        private ILoaderOwner _loaderOwner;

        private LoaderManager()
        {
            
        }

        internal void Initialize(ILoaderOwner loaderOwner)
        {
            _loaderOwner = loaderOwner;
        }

        internal void ShowLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Visible;
            _loaderOwner.IsControlEnabled = false;
        }
        internal void HideLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Hidden;
            _loaderOwner.IsControlEnabled = true;
        }
    }
}
