using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Online_Course_API.Model;

namespace Online_Course_API.Data
{
    public class OnlineCourseDBContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineCourseDBContext()
        {

        }

        public OnlineCourseDBContext(DbContextOptions<OnlineCourseDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Choise> Choises { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Instructor> Instructors { get; set; }

        public virtual DbSet<Instructor_Course> Instructor_Courses { get; set; }

        public virtual DbSet<Parent> Parents { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Quiz> Quizzes { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Student_Group> Student_Groups { get; set; }

        public virtual DbSet<Student_Question> Student_Questions { get; set; }

        public virtual DbSet<Student_Quiz> Student_Quizzes { get; set; }

        public virtual DbSet<Student_Session> Student_Sessions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            


            modelBuilder.Entity<Quiz>()
                        .HasOne(q => q.Group)
                        .WithMany(g => g.Quizzes)
                        .HasForeignKey(q => q.Group_ID)
                        .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Group>()
                        .HasMany(g => g.Quizzes)
                        .WithOne(q => q.Group)
                        .HasForeignKey(q => q.Group_ID)
                        .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Student_Group>()
                        .HasOne(sg => sg.Student)
                        .WithMany()
                        .HasForeignKey(sg => sg.Student_ID)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Student_Quiz>()
                       .HasOne(sq => sq.Student)
                       .WithMany()
                       .HasForeignKey(sq => sq.Student_ID)
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student_Session>()
                        .HasOne(ss => ss.Student)
                        .WithMany()
                        .HasForeignKey(ss => ss.Student_ID)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Student_Question>()
                        .HasOne(sq => sq.Student)
                        .WithMany()
                        .HasForeignKey(sq => sq.Student_ID)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instructor>()
                        .HasKey(i => i.Instructor_ID);

            modelBuilder.Entity<Instructor>()
                        .HasOne<ApplicationUser>()
                        .WithOne()
                        .HasForeignKey<Instructor>(i => i.UserId)
                        .IsRequired();

            modelBuilder.Entity<Student>()
                        .HasKey(s => s.Student_ID);

            modelBuilder.Entity<Student>()
                        .HasOne<ApplicationUser>()
                        .WithOne()
                        .HasForeignKey<Student>(s => s.UserId)
                        .IsRequired();

            modelBuilder.Entity<Student_Question>()
                        .HasOne(sq => sq.Student)
                        .WithMany()
                        .HasForeignKey(sq => sq.Student_ID)
                        .OnDelete(DeleteBehavior.Restrict);

            


            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.ApplicationUser)
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.ApplicationUser)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);






            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<Instructor_Course>()
                .HasKey(m => new { m.Instructor_ID, m.Course_ID });

            

            modelBuilder.Entity<Student_Group>()
                .HasKey(m => new { m.Student_ID, m.Group_ID });

            modelBuilder.Entity<Student_Question>()
                .HasKey(m => new { m.Student_ID, m.Question_ID });

            modelBuilder.Entity<Student_Quiz>()
                .HasKey(m => new { m.Student_ID, m.Quiz_ID });

            modelBuilder.Entity<Student_Session>()
                .HasKey(m => new { m.Student_ID, m.Session_ID });





        }
    }
}
