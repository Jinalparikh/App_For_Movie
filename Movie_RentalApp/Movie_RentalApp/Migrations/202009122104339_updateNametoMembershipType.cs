namespace Movie_RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNametoMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name = 'Pay as you Go' WHERE ID = 1");
            Sql("update MembershipTypes set Name = 'Monthly' WHERE ID = 2");
        }
        
        public override void Down()
        {
        }
    }
}
