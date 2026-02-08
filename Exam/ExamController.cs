using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Exam
{
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            return View(ExamStore.Questions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ExamQuestion());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ExamQuestion question)
        {
            if (string.IsNullOrWhiteSpace(question.Text)) question.Text = "Question";
            ExamStore.Add(question);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            ExamStore.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
