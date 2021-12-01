using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeKeep.Infrastructure.Migrations
{
    public partial class AddGetInventoriesSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DROP FUNCTION IF EXISTS inventory_get_inventories;
CREATE OR REPLACE FUNCTION inventory_get_inventories()
    RETURNS TABLE (
        Id uuid
    )
AS $$
BEGIN
    RETURN QUERY
        SELECT
            I.""Id""
        FROM homekeep.public.""Inventories"" I;
END;
$$ LANGUAGE 'plpgsql';
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DROP FUNCTION IF EXISTS inventory_get_inventories;
");
        }
    }
}
