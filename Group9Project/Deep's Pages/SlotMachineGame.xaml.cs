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
using Group9Project.Dylan_s_Pages;

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

        private void IsGameOver()
        {
            if (_game.IsSlotOver())
            {
                MessageDialog message = new MessageDialog("You have no more money, your game is over!");
                message.ShowAsync();
                PlaySlots.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<int> numbers = _game.Roll();
            if (_game.IsJackpot)
            {
                MessageDialog message = new MessageDialog("Your Got a Jackpot");
                message.ShowAsync();
            }

            
            FirstPicture.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Deep's Pictures/{numbers[0]}.png", UriKind.RelativeOrAbsolute));
            SecondPicture.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Deep's Pictures/{numbers[1]}.png", UriKind.RelativeOrAbsolute));
            ThirdPicture.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Deep's Pictures/{numbers[2]}.png", UriKind.RelativeOrAbsolute));
            CurrentBalanceLabel.Text = $"Money: {User.Money}, Bonus: {_game.Bonus}";
            IsGameOver();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SlotMainPage));
        }
    }
}
