namespace WebApplication5.Lesson
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string CourseLink { get; set; } = "";
        public List<LessonItem> Items { get; set; } = new List<LessonItem>();
    }

    public class LessonItem
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
    }

    public static class LessonStore
    {
        private static int _nextLessonId = 4;
        private static int _nextItemId = 1;
        public static List<Lesson> Lessons { get; } = new List<Lesson>
        {
            new Lesson
            {
                Id = 1,
                Title = "IT Course",
                CourseLink = "https://drive.google.com/drive/folders/it-course-placeholder"
            },
            new Lesson
            {
                Id = 2,
                Title = "Backend .NET",
                CourseLink = "https://drive.google.com/drive/folders/backend-dotnet-placeholder"
            },
            new Lesson
            {
                Id = 3,
                Title = "Career & Interview Skills",
                CourseLink = "https://drive.google.com/drive/folders/career-interview-placeholder"
            }
        };

        public static Lesson? GetById(int id) => Lessons.FirstOrDefault(l => l.Id == id);

        public static void Add(Lesson lesson)
        {
            lesson.Id = _nextLessonId++;
            lesson.Items = new List<LessonItem>();
            Lessons.Add(lesson);
        }

        public static bool Delete(int id)
        {
            var lesson = GetById(id);
            if (lesson == null) return false;
            Lessons.Remove(lesson);
            return true;
        }

        public static void AddItem(int lessonId, LessonItem item)
        {
            var lesson = GetById(lessonId);
            if (lesson == null) return;
            item.Id = _nextItemId++;
            item.LessonId = lessonId;
            lesson.Items.Add(item);
        }

        public static bool DeleteItem(int lessonId, int itemId)
        {
            var lesson = GetById(lessonId);
            var item = lesson?.Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null) return false;
            lesson!.Items.Remove(item);
            return true;
        }
    }
}
