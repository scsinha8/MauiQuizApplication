using QuizAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        [HttpGet(Name = "GetQuizData")]
        public QuizModel[] Get()
        {
            QuizModel[] quizData =
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
            return quizData;
        }
    }
}
