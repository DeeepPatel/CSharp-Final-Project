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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Group9Project.Deep_s_Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SlotHistoryView : Page
    {
        public SlotHistoryView()
        {
            this.InitializeComponent();
        }

        //Event that when navigated to this page, the double tapped item will show all the appropriate information.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SlotTemplate item = e.Parameter as SlotTemplate; //assigns a variable to the list object that is passed by a parameter
            ViewHistory.Items.Add(item);
        }

        //Event that will take the user back to the history timeline view.
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
