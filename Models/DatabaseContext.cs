using Microsoft.EntityFrameworkCore;

namespace LHMSAPI.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){ }
        public DbSet<SystemReport> SystemReports { get; set; }
    }




    public class SystemReport
    {
        public int Id { get; set; }

        //TODO: Update with logic to use the logged in user's info.
        public string Name { get; set; }

        public System.DateTime ReportDate { get; set; }

        public System.DateTime CreatedDate { get; set; } = System.DateTime.Now;

        public System.DateTime UpdatedDate { get; set; } = System.DateTime.Now;

        public SystemName SystemName { get; set; }

        public string SystemUpdate { get; set; }

        public string PersonnelUpdates { get; set; }

        public string CreativeIdeasAndEvaluations { get; set; }

        public string BarriersOrChallenges { get; set; }

        public string HowCanIHelpYou { get; set; }

        public string PersonalGrowthAndDevelopment { get; set; }
    }

    public enum SystemName
    {
        Youth,
        FirstTouch,
        SecondTouch,
        SpecializedMinistries,
        Childrens,
        Administrative,
        CampusPreservation,
        ChristianDevelopment
    }

}