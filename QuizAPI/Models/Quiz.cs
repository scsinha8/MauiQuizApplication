namespace QuizAPI.Models
{
    public class Quiz
    {
        public int currentQuestion { get; set; }
        public bool quizComplete { get; set; }
        public bool pass { get; set; }
        public QuizModel quizModel { get; set; }
    }

    public class QuizModel
    {
        public string question { get; set; }
        public string answer { get; set; }
        public OptionsList[] optionsList { get; set; }
    }

    public class OptionsList
    {
        public int id { get; set; }
        public string optionId { get; set; }
        public string option { get; set; }
        public bool isSelected = false;
        public bool isMatched = false;
    }
}
