﻿using System;
using Dev2.Studio.StartupResources;

namespace Dev2.Studio.Views
{
    public partial class MainView
    {
        #region Constructor

        public MainView()
        {
            InitializeComponent();
            this.Loaded += MainView_Loaded;
        }

        void MainView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Dev2SplashScreen.Close(TimeSpan.FromSeconds(0.3));
        }

        public override void EndInit()
        {
            base.EndInit();
        }

        #endregion Constructor
    }
}