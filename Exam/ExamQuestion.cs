namespace WebApplication5.Exam
{
    public class QuestionResultItem
    {
        public ExamQuestion Question { get; set; } = null!;
        public bool? UserAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class ExamQuestion
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public bool CorrectAnswer { get; set; }
    }

    public static class ExamStore
    {
        private static int _nextId = 1;
        public static List<ExamQuestion> Questions { get; } = new List<ExamQuestion>();

        public static ExamQuestion? GetById(int id) => Questions.FirstOrDefault(q => q.Id == id);

        public static void Add(ExamQuestion q)
        {
            q.Id = _nextId++;
            Questions.Add(q);
        }

        public static bool Delete(int id)
        {
            var q = GetById(id);
            if (q == null) return false;
            Questions.Remove(q);
            return true;
        }
    }
}
