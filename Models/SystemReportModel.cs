public class SystemReport
{
    public int Id { get; set; }

    //TODO: Update with logic to use the logged in user's info from Identity Server 4.
    //TODO: Need to add a status indicatory whether the record is active or not.
    //TODO: Need to add a report status to show where in the lifecycle it is.
    public string Name { get; set; }

    public bool Active { get; set; }
    public System.DateTime ReportDate { get; set; }

    public System.DateTime CreatedDate { get; set; }

    public System.DateTime UpdatedDate { get; set; } = System.DateTime.Now;

    public SystemReportStatus SystemReportStatus { get; set; }

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

public enum SystemReportStatus
{
    Draft,
    SubmittedToSystemDirector,
    SubmittedToAdministrativePastor,
    Canceled
}