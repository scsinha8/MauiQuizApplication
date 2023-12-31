using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public partial class Quiz : ObservableObject
    {
        public int currentQuestion { get; set; }
        public bool quizComplete { get; set; }
        public bool pass { get; set; }
        public QuizModel quizModel { get; set; }
    }
    public partial class QuizModel : ObservableObject
    {
        public string question { get; set; }
        public string answer { get; set; }
        public OptionsList[] optionsList { get; set; }

    }
    public partial class OptionsList : ObservableObject
    {
        public int id { get; set; }
        public string optionId { get; set; }
        public string option { get; set; }
        public bool isSelected = false;
        public bool isMatched = false;
    }

}
