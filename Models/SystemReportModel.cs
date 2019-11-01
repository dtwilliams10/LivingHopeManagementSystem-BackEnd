using System;
using System.ComponentModel.DataAnnotations;

namespace LHMSAPI.Models
{
    public class SystemReport
{
    public int Id { get; set; }

    //TODO: Update with logic to use the logged in user's info from Identity Server 4.

    public string Name { get; set; }

    public bool Active { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime ReportDate { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime UpdatedDate { get; set; } = System.DateTime.Now;

    public int SystemReportStatusId { get; set; }
    public SystemStatus SystemReportStatus { get; set; }

    public int SystemNameId { get; set; }
    public SystemName SystemName { get; set; }

    public string SystemUpdate { get; set; }

    public string PersonnelUpdates { get; set; }

    public string CreativeIdeasAndEvaluations { get; set; }

    public string BarriersOrChallenges { get; set; }

    public string HowCanIHelpYou { get; set; }

    public string PersonalGrowthAndDevelopment { get; set; }

    }

}