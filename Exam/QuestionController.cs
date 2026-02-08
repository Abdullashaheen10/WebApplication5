using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Exam
{
    public class QuestionController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(ExamStore.Questions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormCollection form)
        {
            var questions = ExamStore.Questions;
            int correct = 0;
            var results = new List<QuestionResultItem>();
            foreach (var q in questions)
            {
                var key = "answer_" + q.Id;
                bool? userAnswer = null;
                if (form.TryGetValue(key, out var val) && !string.IsNullOrEmpty(val))
                    userAnswer = val.ToString().ToLowerInvariant() == "true";
                bool isCorrect = userAnswer == q.CorrectAnswer;
                if (isCorrect) correct++;
                results.Add(new QuestionResultItem { Question = q, UserAnswer = userAnswer, IsCorrect = isCorrect });
            }
            ViewBag.Total = questions.Count;
            ViewBag.Correct = correct;
            ViewBag.Results = results;
            return View("Result");
        }
    }
}
