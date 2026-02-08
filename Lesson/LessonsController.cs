using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Lesson
{
    public class LessonsController : Controller
    {
        public IActionResult Index()
        {
            return View(LessonStore.Lessons);
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View(new Lesson());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse(Lesson lesson)
        {
            if (string.IsNullOrWhiteSpace(lesson.Title)) lesson.Title = "Lesson";
            LessonStore.Add(lesson);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCourse(int id)
        {
            LessonStore.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult New(int lessonId)
        {
            var lesson = LessonStore.GetById(lessonId);
            if (lesson == null) return NotFound();
            ViewBag.Lesson = lesson;
            return View(new LessonItem { LessonId = lessonId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(int lessonId, LessonItem item)
        {
            var lesson = LessonStore.GetById(lessonId);
            if (lesson == null) return NotFound();
            item.LessonId = lessonId;
            LessonStore.AddItem(lessonId, item);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int lessonId, int itemId)
        {
            LessonStore.DeleteItem(lessonId, itemId);
            return RedirectToAction(nameof(Index));
        }
    }
}
