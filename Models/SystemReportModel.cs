public class SystemReport
    {
        public int Id { get; set; }

        //TODO: Update with logic to use the logged in user's info from Identity Server 4.
        public string Name { get; set; }

        public System.DateTime ReportDate { get; set; }

        public System.DateTime CreatedDate { get; set; }

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