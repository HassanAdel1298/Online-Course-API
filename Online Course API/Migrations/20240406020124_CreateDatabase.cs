using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Course_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Grade_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Grade_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Instructor_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AboutMe = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Instructor_ID);
                    table.ForeignKey(
                        name: "FK_Instructors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Parent_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Parent_ID);
                    table.ForeignKey(
                        name: "FK_Parents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Grade_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_ID);
                    table.ForeignKey(
                        name: "FK_Courses_Grades_Grade_ID",
                        column: x => x.Grade_ID,
                        principalTable: "Grades",
                        principalColumn: "Grade_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Parent_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_ID);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Parents_Parent_ID",
                        column: x => x.Parent_ID,
                        principalTable: "Parents",
                        principalColumn: "Parent_ID");
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Group_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Num_Students = table.Column<int>(type: "int", nullable: false),
                    Creation_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    End_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Instructor_ID = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Group_ID);
                    table.ForeignKey(
                        name: "FK_Groups_Courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_Instructors_Instructor_ID",
                        column: x => x.Instructor_ID,
                        principalTable: "Instructors",
                        principalColumn: "Instructor_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructor_Courses",
                columns: table => new
                {
                    Instructor_ID = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor_Courses", x => new { x.Instructor_ID, x.Course_ID });
                    table.ForeignKey(
                        name: "FK_Instructor_Courses_Courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instructor_Courses_Instructors_Instructor_ID",
                        column: x => x.Instructor_ID,
                        principalTable: "Instructors",
                        principalColumn: "Instructor_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Quiz_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quiz_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quiz_Available = table.Column<bool>(type: "bit", nullable: false),
                    Instructor_ID = table.Column<int>(type: "int", nullable: false),
                    Group_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Quiz_ID);
                    table.ForeignKey(
                        name: "FK_Quizzes_Groups_Group_ID",
                        column: x => x.Group_ID,
                        principalTable: "Groups",
                        principalColumn: "Group_ID");
                    table.ForeignKey(
                        name: "FK_Quizzes_Instructors_Instructor_ID",
                        column: x => x.Instructor_ID,
                        principalTable: "Instructors",
                        principalColumn: "Instructor_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Session_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    OnlineVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructor_ID = table.Column<int>(type: "int", nullable: true),
                    Group_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Session_ID);
                    table.ForeignKey(
                        name: "FK_Sessions_Groups_Group_ID",
                        column: x => x.Group_ID,
                        principalTable: "Groups",
                        principalColumn: "Group_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Instructors_Instructor_ID",
                        column: x => x.Instructor_ID,
                        principalTable: "Instructors",
                        principalColumn: "Instructor_ID");
                });

            migrationBuilder.CreateTable(
                name: "Student_Groups",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Group_ID = table.Column<int>(type: "int", nullable: false),
                    Enroll_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Student_ID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Groups", x => new { x.Student_ID, x.Group_ID });
                    table.ForeignKey(
                        name: "FK_Student_Groups_Groups_Group_ID",
                        column: x => x.Group_ID,
                        principalTable: "Groups",
                        principalColumn: "Group_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Groups_Students_Student_ID",
                        column: x => x.Student_ID,
                        principalTable: "Students",
                        principalColumn: "Student_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Groups_Students_Student_ID1",
                        column: x => x.Student_ID1,
                        principalTable: "Students",
                        principalColumn: "Student_ID");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Question_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question_Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Quiz_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Question_ID);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_Quiz_ID",
                        column: x => x.Quiz_ID,
                        principalTable: "Quizzes",
                        principalColumn: "Quiz_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student_Quizzes",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Quiz_ID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    Student_ID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Quizzes", x => new { x.Student_ID, x.Quiz_ID });
                    table.ForeignKey(
                        name: "FK_Student_Quizzes_Quizzes_Quiz_ID",
                        column: x => x.Quiz_ID,
                        principalTable: "Quizzes",
                        principalColumn: "Quiz_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Quizzes_Students_Student_ID",
                        column: x => x.Student_ID,
                        principalTable: "Students",
                        principalColumn: "Student_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Quizzes_Students_Student_ID1",
                        column: x => x.Student_ID1,
                        principalTable: "Students",
                        principalColumn: "Student_ID");
                });

            migrationBuilder.CreateTable(
                name: "Student_Sessions",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Session_ID = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Student_ID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Sessions", x => new { x.Student_ID, x.Session_ID });
                    table.ForeignKey(
                        name: "FK_Student_Sessions_Sessions_Session_ID",
                        column: x => x.Session_ID,
                        principalTable: "Sessions",
                        principalColumn: "Session_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Sessions_Students_Student_ID",
                        column: x => x.Student_ID,
                        principalTable: "Students",
                        principalColumn: "Student_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Sessions_Students_Student_ID1",
                        column: x => x.Student_ID1,
                        principalTable: "Students",
                        principalColumn: "Student_ID");
                });

            migrationBuilder.CreateTable(
                name: "Choises",
                columns: table => new
                {
                    Choise_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    Question_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choises", x => x.Choise_ID);
                    table.ForeignKey(
                        name: "FK_Choises_Questions_Question_ID",
                        column: x => x.Question_ID,
                        principalTable: "Questions",
                        principalColumn: "Question_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student_Questions",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Question_ID = table.Column<int>(type: "int", nullable: false),
                    St_Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_ID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Questions", x => new { x.Student_ID, x.Question_ID });
                    table.ForeignKey(
                        name: "FK_Student_Questions_Questions_Question_ID",
                        column: x => x.Question_ID,
                        principalTable: "Questions",
                        principalColumn: "Question_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Questions_Students_Student_ID",
                        column: x => x.Student_ID,
                        principalTable: "Students",
                        principalColumn: "Student_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Questions_Students_Student_ID1",
                        column: x => x.Student_ID1,
                        principalTable: "Students",
                        principalColumn: "Student_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Choises_Question_ID",
                table: "Choises",
                column: "Question_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Grade_ID",
                table: "Courses",
                column: "Grade_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Course_ID",
                table: "Groups",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Instructor_ID",
                table: "Groups",
                column: "Instructor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_Courses_Course_ID",
                table: "Instructor_Courses",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_UserId",
                table: "Parents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Quiz_ID",
                table: "Questions",
                column: "Quiz_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_Group_ID",
                table: "Quizzes",
                column: "Group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_Instructor_ID",
                table: "Quizzes",
                column: "Instructor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Group_ID",
                table: "Sessions",
                column: "Group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Instructor_ID",
                table: "Sessions",
                column: "Instructor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Groups_Group_ID",
                table: "Student_Groups",
                column: "Group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Groups_Student_ID1",
                table: "Student_Groups",
                column: "Student_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Questions_Question_ID",
                table: "Student_Questions",
                column: "Question_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Questions_Student_ID1",
                table: "Student_Questions",
                column: "Student_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Quizzes_Quiz_ID",
                table: "Student_Quizzes",
                column: "Quiz_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Quizzes_Student_ID1",
                table: "Student_Quizzes",
                column: "Student_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Sessions_Session_ID",
                table: "Student_Sessions",
                column: "Session_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Sessions_Student_ID1",
                table: "Student_Sessions",
                column: "Student_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Parent_ID",
                table: "Students",
                column: "Parent_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Choises");

            migrationBuilder.DropTable(
                name: "Instructor_Courses");

            migrationBuilder.DropTable(
                name: "Student_Groups");

            migrationBuilder.DropTable(
                name: "Student_Questions");

            migrationBuilder.DropTable(
                name: "Student_Quizzes");

            migrationBuilder.DropTable(
                name: "Student_Sessions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
