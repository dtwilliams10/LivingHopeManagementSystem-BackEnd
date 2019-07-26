using System;

namespace LHMSAPI.Models
{
    public class SystemReport
    {
        public int ObjectID {get; set;}

        public string ReportID {get; set;}

        //TODO: Update with logic to use the logged in user's info.
        public string Name {get; set;}

        public DateTime ReportDate {get; set;}

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public SystemName SystemName {get; set;}

        public string SystemUpdate {get; set;}

        public string PersonnelUpdates {get; set;}

        public string CreativeIdeasAndEvaluations {get; set;}

        public string BarriersOrChallenges {get; set;}

        public string HowCanIHelpYou {get; set;}

        public string PersonalGrowthAndDevelopment {get; set;}
    }

    public enum SystemName {
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