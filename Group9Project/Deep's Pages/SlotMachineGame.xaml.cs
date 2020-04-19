﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Group9Project.Deep_s_Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SlotMachineGame : Page
    {
        private SlotGame _game = new SlotGame();
        public SlotMachineGame()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_game.IsSlotOver())
            {
                MessageDialog message = new MessageDialog("Your Game is over");
                message.ShowAsync();
                PlaySlots.IsEnabled = false;
                
                return; //starts the code again so your game restarts
            }

            List<int> numbers = _game.Roll();

            //todo: 2. If a jackpot, show a message
            if (_game.IsJackpot)
            {
                MessageDialog message = new MessageDialog("Your Got a Jackpot");
                message.ShowAsync();
            }

            //todo: 3. Assign the random image to ImageControl
            FirstPicture.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Deep's Pictures/{numbers[0]}.png", UriKind.RelativeOrAbsolute));
            SecondPicture.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Deep's Pictures/{numbers[1]}.png", UriKind.RelativeOrAbsolute));
            ThirdPicture.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Deep's Pictures/{numbers[2]}.png", UriKind.RelativeOrAbsolute));
            CurrentBalanceLabel.Text = $"Money: {_game.Money}, Bonus: {_game.Bonus}";
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SlotHistoryListView));
        }
    }
}