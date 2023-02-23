using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBookSolution_.DataAccess.Migrations
{
    public partial class addstoreprocedureCoverType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE GetCoverTypes
                                   AS
                                   SELECT * FROM CoverTypes");

            migrationBuilder.Sql(@"CREATE PROCEDURE GetCoverType
                                   @Id int
                                   AS
                                   SELECT * FROM CoverTypes where Id=@Id");

            migrationBuilder.Sql(@"CREATE PROCEDURE CreateCoverType
                                   @Name varchar(50)
                                   AS
                                   INSERT CoverTypes values (@Name)");

            migrationBuilder.Sql(@"CREATE PROCEDURE UpdateCoverType
                                   @Id int,
                                   @Name Varchar(50)
                                   AS
                                   UPDATE CoverTypes set Name=@Name WHERE Id=@Id");

            migrationBuilder.Sql(@"CREATE PROCEDURE DeleteCoverType
                                   @Id int
                                   AS
                                   DELETE CoverTypes WHERE Id=@Id
                                    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
