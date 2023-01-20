using System;
using System.Collections.Generic;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hangman_Exercise
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<BitmapImage> images10;
        List<BitmapImage> images8;
        MediaPlayer player;

        public Manager manager;
        int possibleMistakes;

        public MainPage()
        {
            this.InitializeComponent();
            manager = new Manager();
            images10 = new List<BitmapImage>();
            images8 = new List<BitmapImage>();
            LoadImages();
            player = new MediaPlayer();
        }

        private async void WinSound()
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("win.mp3");
            player.AutoPlay = true;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
        }
        private async void GameOverSound()
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("gameover.mp3");
            player.AutoPlay = true;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
        }
        private void LoadImages()
        {
            for (int i = 0; i < 11; i++)
            {
                var image10 = new BitmapImage(new Uri(@"ms-appx:/Images/10mistakes/wrong" + i.ToString() + ".png"));
                images10.Add(image10);
            }

            for (int i = 0; i < 9; i++)
            {
                var image8 = new BitmapImage(new Uri(@"ms-appx:/Images/8mistakes/wrong" + i.ToString() + ".png"));
                images8.Add(image8);
            }
        }
        private async void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            if (comboDiff.SelectedIndex != 0 && comboDiff.SelectedIndex != 1)
            {
                await new MessageDialog("You didn't choose a difficulty level").ShowAsync();
                return;
            }
            manager.NewGame();
            imageMiss.Source = images10[0];
            manager.CountMistakes = 0;
            manager.CorrectGuesses = 0;

            resultChart1.Text = "?"; resultChart2.Text = "?"; resultChart3.Text = "?";

            if (comboDiff.SelectedIndex == 0)
            {
                manager.IsEasy = true;
                possibleMistakes = manager.PossibleMistakes10;
                txtMistakesDone.Text = $"0/{manager.PossibleMistakes10}";
            }
            else if (comboDiff.SelectedIndex == 1)
            {
                manager.IsHard = true;
                possibleMistakes = manager.PossibleMistakes8;
                txtMistakesDone.Text = $"0/{manager.PossibleMistakes8}";
            }
            //Uncomment if you wish to know the random word
            //randomWord.Text = $"{manager.Word}";
        }
        private async void btnA_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'a') { resultChart1.Text = "A"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'a') { resultChart2.Text = "A"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'a') { resultChart3.Text = "A"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnB_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'b') { resultChart1.Text = "B"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'b') { resultChart2.Text = "B"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'b') { resultChart3.Text = "B"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnC_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'c') { resultChart1.Text = "C"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'c') { resultChart2.Text = "C"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'c') { resultChart3.Text = "C"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnD_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'd') { resultChart1.Text = "D"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'd') { resultChart2.Text = "D"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'd') { resultChart3.Text = "D"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnE_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'e') { resultChart1.Text = "E"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'e') { resultChart2.Text = "E"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'e') { resultChart3.Text = "E"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnF_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'f') { resultChart1.Text = "F"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'f') { resultChart2.Text = "F"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'f') { resultChart3.Text = "F"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnG_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'g') { resultChart1.Text = "G"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'g') { resultChart2.Text = "G"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'g') { resultChart3.Text = "G"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnH_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'h') { resultChart1.Text = "H"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'h') { resultChart2.Text = "H"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'h') { resultChart3.Text = "H"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnI_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'i') { resultChart1.Text = "I"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'i') { resultChart2.Text = "I"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'i') { resultChart3.Text = "I"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnJ_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'j') { resultChart1.Text = "J"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'j') { resultChart2.Text = "J"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'j') { resultChart3.Text = "J"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnK_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'k') { resultChart1.Text = "K"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'k') { resultChart2.Text = "K"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'k') { resultChart3.Text = "K"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnL_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'l') { resultChart1.Text = "L"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'l') { resultChart2.Text = "L"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'l') { resultChart3.Text = "L"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnM_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'm') { resultChart1.Text = "M"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'm') { resultChart2.Text = "M"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'm') { resultChart3.Text = "M"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnN_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'n') { resultChart1.Text = "N"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'n') { resultChart2.Text = "N"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'n') { resultChart3.Text = "N"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnO_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'o') { resultChart1.Text = "O"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'o') { resultChart2.Text = "O"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'o') { resultChart3.Text = "O"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnP_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'p') { resultChart1.Text = "P"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'p') { resultChart2.Text = "P"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'p') { resultChart3.Text = "P"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnQ_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'q') { resultChart1.Text = "Q"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'q') { resultChart2.Text = "Q"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'q') { resultChart3.Text = "Q"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnR_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'r') { resultChart1.Text = "R"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'r') { resultChart2.Text = "R"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'r') { resultChart3.Text = "R"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnS_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 's') { resultChart1.Text = "S"; manager.CorrectGuesses++; }
            else if (manager.C2 == 's') { resultChart2.Text = "S"; manager.CorrectGuesses++; }
            else if (manager.C3 == 's') { resultChart3.Text = "S"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnT_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 't') { resultChart1.Text = "T"; manager.CorrectGuesses++; }
            else if (manager.C2 == 't') { resultChart2.Text = "T"; manager.CorrectGuesses++; }
            else if (manager.C3 == 't') { resultChart3.Text = "T"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnU_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'u') { resultChart1.Text = "U"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'u') { resultChart2.Text = "U"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'u') { resultChart3.Text = "U"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnV_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'v') { resultChart1.Text = "V"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'v') { resultChart2.Text = "V"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'v') { resultChart3.Text = "V"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnW_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'w') { resultChart1.Text = "W"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'w') { resultChart2.Text = "W"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'w') { resultChart3.Text = "W"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnX_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'x') { resultChart1.Text = "X"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'x') { resultChart2.Text = "X"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'x') { resultChart3.Text = "X"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnY_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'y') { resultChart1.Text = "Y"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'y') { resultChart2.Text = "Y"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'y') { resultChart3.Text = "Y"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
        private async void btnZ_Click(object sender, RoutedEventArgs e)
        {
            if (manager.C1 == 'z') { resultChart1.Text = "Z"; manager.CorrectGuesses++; }
            else if (manager.C2 == 'z') { resultChart2.Text = "Z"; manager.CorrectGuesses++; }
            else if (manager.C3 == 'z') { resultChart3.Text = "Z"; manager.CorrectGuesses++; }
            else
            {
                manager.CountMistakes++;
                txtMistakesDone.Text = $"{manager.CountMistakes}/{possibleMistakes}";
                if (manager.IsEasy == true)
                    imageMiss.Source = images10[manager.CountMistakes];
                if (manager.IsHard == true)
                    imageMiss.Source = images8[manager.CountMistakes];
            }
            if (manager.GameOver())
            {
                GameOverSound();
                await new MessageDialog($"You Lost! The word was {manager.Word}").ShowAsync();
            }
            if (manager.isWinner())
            {
                WinSound();
                await new MessageDialog($"You Won! The word was {manager.Word}").ShowAsync();
            }
        }
    }
}
