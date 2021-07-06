using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Data.Migrations
{
    public partial class AddMembershipTypesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (0, 0, 0, 0)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 30, 1, 10)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 90, 3, 15)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 300, 12, 15)");        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
