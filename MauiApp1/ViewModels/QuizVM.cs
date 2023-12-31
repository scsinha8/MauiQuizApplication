using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using MauiApp1.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Views;
using System.Globalization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MauiApp1.ViewModels
{
    public partial class QuizVM : ObservableObject, INotifyPropertyChanged
    {
        static int current_index { get; set; } = 0;
        int correct_total { get; set; }
        string current_answer { get; set; }
        
        string correct_answer { get; set; } = "B";

        public static QuizModel[] quizData { get; set; }

        [ObservableProperty]
        string currentQuestion;

        [ObservableProperty]
        Quiz quiz;

        [ObservableProperty]
        double progress;

        [RelayCommand]
        private async void NextButton()
        {
            if (current_answer == correct_answer)
            {
                //await App.Current.MainPage.DisplayAlert("Correct!", "You got it right!", "ok");
                correct_total++;
            }
            else
            {
                //await App.Current.MainPage.DisplayAlert("Incorrect!", "You got it wrong!", "ok");
            }

            current_index++;
            Progress = (double)current_index / (double)quizData.Length;

            if (current_index == quizData.Length)
            {
                string perc = ((double)correct_total / (double)quizData.Length).ToString("P", CultureInfo.InvariantCulture);
                await App.Current.MainPage.DisplayAlert("Result", $"Your result is: {perc}", "Close");
                await Shell.Current.GoToAsync("//MainPage");
                return;
                
            }
            //current_index++;
            CurrentQuestion = $"Question {current_index + 1}/{quizData.Length}";
            //Progress = (double)current_index / (double)quizData.Length;
            Quiz = await CreateGameModel(current_index);
            correct_answer = Quiz.quizModel.answer;

            
            //void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            //{
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //}
        }

        [RelayCommand]
        private async Task ItemClicked(OptionsList options)
        {
            current_answer = options.optionId;
        }
        

        static async Task<Quiz> CreateGameModel(int i)
        {
            return new Quiz { currentQuestion = i,
                quizModel = quizData[i],
                quizComplete = false
            };
        }

        public QuizVM()
        {
        }

        public async Task ClearData()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7054/Quiz/");

            using HttpResponseMessage response = await httpClient.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                var contentStream = await response.Content.ReadAsStringAsync();
                quizData = JsonConvert.DeserializeObject<QuizModel[]>(contentStream);
            }

            current_index = 0;
            Progress = 0;
            CurrentQuestion = $"Question {current_index + 1}/{quizData.Length}";
            Quiz = new Quiz
            {
                currentQuestion = current_index + 1,
                quizModel = quizData[current_index]
            };
            correct_total = 0;
        }
    }
}
