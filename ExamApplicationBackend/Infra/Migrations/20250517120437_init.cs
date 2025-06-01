using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminTable",
                columns: table => new
                {
                    AdminId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTable", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDBTable",
                columns: table => new
                {
                    QuestionDBId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuesionDBName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDBTable", x => x.QuestionDBId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledExamTable",
                columns: table => new
                {
                    ScheduledExamId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeInMinutes = table.Column<int>(type: "int", nullable: false),
                    TotalNumberOfQuestions = table.Column<int>(type: "int", nullable: false),
                    isNegetive = table.Column<bool>(type: "bit", nullable: false),
                    MarksPerQuestion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledExamTable", x => x.ScheduledExamId);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTable",
                columns: table => new
                {
                    SubjectId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTable", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledExamSubjectTable",
                columns: table => new
                {
                    SchedulesExamSubjectId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<long>(type: "bigint", nullable: false),
                    NoOfQuestions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledExamSubjectTable", x => x.SchedulesExamSubjectId);
                    table.ForeignKey(
                        name: "FK_ScheduledExamSubjectTable_SubjectTable_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectTable",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicTable",
                columns: table => new
                {
                    TopicId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicTable", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_TopicTable_SubjectTable_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectTable",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledExamResultTable",
                columns: table => new
                {
                    ScheduledExamResultId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    AppearDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolvedQuestions = table.Column<int>(type: "int", nullable: false),
                    NegetiveMarks = table.Column<int>(type: "int", nullable: false),
                    PositiveMarks = table.Column<int>(type: "int", nullable: false),
                    ObtainedMarks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledExamResultTable", x => x.ScheduledExamResultId);
                    table.ForeignKey(
                        name: "FK_ScheduledExamResultTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTable",
                columns: table => new
                {
                    QuestionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTable", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_QuestionTable_TopicTable_TopicId",
                        column: x => x.TopicId,
                        principalTable: "TopicTable",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptionTable",
                columns: table => new
                {
                    QuestionOptionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptionTable", x => x.QuestionOptionId);
                    table.ForeignKey(
                        name: "FK_QuestionOptionTable_QuestionTable_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionTable",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptionTable_QuestionId",
                table: "QuestionOptionTable",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTable_TopicId",
                table: "QuestionTable",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledExamResultTable_UserId",
                table: "ScheduledExamResultTable",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledExamSubjectTable_SubjectId",
                table: "ScheduledExamSubjectTable",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicTable_SubjectId",
                table: "TopicTable",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminTable");

            migrationBuilder.DropTable(
                name: "QuestionDBTable");

            migrationBuilder.DropTable(
                name: "QuestionOptionTable");

            migrationBuilder.DropTable(
                name: "ScheduledExamResultTable");

            migrationBuilder.DropTable(
                name: "ScheduledExamSubjectTable");

            migrationBuilder.DropTable(
                name: "ScheduledExamTable");

            migrationBuilder.DropTable(
                name: "QuestionTable");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.DropTable(
                name: "TopicTable");

            migrationBuilder.DropTable(
                name: "SubjectTable");
        }
    }
}
