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

namespace MauiApp1.ViewModels
{
    public partial class QuizVM : ObservableObject, INotifyPropertyChanged
    {
        static int current_index { get; set; } = 0;
        int correct_total { get; set; }
        string current_answer { get; set; }
        
        string correct_answer { get; set; } = "B";

        static QuizModel[] quizData =
        {
            new QuizModel
            {
                question = "Who is goddess of the hunt?",
                answer = "B",
                optionsList = new OptionsList[]
                {
                    new OptionsList
                    {
                        id = 11,
                        option = "Hera",
                        optionId = "A"
                    },
                    new OptionsList
                    {
                        id = 12,
                        option = "Artemis",
                        optionId = "B"
                    },
                    new OptionsList
                    {
                        id = 13,
                        option = "Athena",
                        optionId = "C"
                    },
                    new OptionsList
                    {
                        id = 14,
                        option = "Aphrodite",
                        optionId = "D"
                    }
                }
            },

            new QuizModel
            {
                question = "What is the human form of bovine spongiform encephalopathy commonly known as?",
                answer = "C",
                optionsList = new OptionsList[]
                {
                    new OptionsList
                    {
                        id = 21,
                        option = "Swine flu",
                        optionId = "A"
                    },
                    new OptionsList
                    {
                        id = 22,
                        option = "Norovirus",
                        optionId = "B"
                    },
                    new OptionsList
                    {
                        id = 23,
                        option = "Mad cow disease",
                        optionId = "C"
                    },
                    new OptionsList
                    {
                        id = 24,
                        option = "Bubonic plague",
                        optionId = "D"
                    }
                }
            },

            new QuizModel
            {
                question = "What is the closest star to earth (apart from the sun)?",
                answer = "B",
                optionsList = new OptionsList[]
                {
                    new OptionsList
                    {
                        id = 31,
                        option = "Alpha Centauri",
                        optionId = "A"
                    },
                    new OptionsList
                    {
                        id = 32,
                        option = "Proxima Centauri",
                        optionId = "B"
                    },
                    new OptionsList
                    {
                        id = 33,
                        option = "Barnard's star",
                        optionId = "C"
                    },
                    new OptionsList
                    {
                        id = 34,
                        option = "Alpha Centauri A",
                        optionId = "D"
                    }
                }
            }
        };

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
            CurrentQuestion = $"Question {current_index + 1}/{quizData.Length}";
            Quiz = new Quiz
            {
                currentQuestion = current_index + 1,
                quizModel = quizData[current_index]
            };
            correct_total = 0;
        }

        public async Task ClearData()
        {
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
