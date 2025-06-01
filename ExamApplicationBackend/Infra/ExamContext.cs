using Core;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class ExamContext : DbContext
    {
        public ExamContext(DbContextOptions<ExamContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            foreach (var relationship in mb.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionDB> QuestionDBs { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<ScheduledExam> ScheduledExams { get; set; }
        public DbSet<ScheduledExamResult> ScheduledExamResults { get; set; }
        public DbSet<ScheduledExamSubject> ScheduledExamSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
