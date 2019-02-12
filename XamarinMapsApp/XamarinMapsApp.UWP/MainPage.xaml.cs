﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace XamarinMapsApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            Xamarin.FormsMaps.Init("2GF3VlGUdsdJAApXXm3U ~ WnaVXsx7Hg1_ZfTdHp-Xzw ~ AieXCxAWkduuqn19HPce_X1ALis5_3I0HduIKxpn0bZlFicTFaiD0fdaM72u-Won");

            LoadApplication(new XamarinMapsApp.App());
        }
    }
}
