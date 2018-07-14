using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LHMSAPI.Models
{
    public class SystemReport
    {
        
        public ObjectId ObjectID {get; set;}
        
        [BsonElement("ReportID")]
        public int ReportID {get; set;}

        [BsonElement("Name")]
        public string Name {get; set;}

        [DataType(DataType.Date)]
        DateTime ReportDate {get; set;}

        [Required]
        SystemName SystemName {get; set;}

        [Required]
        string SystemUpdate {get; set;}

        [Required]
        string PersonnelUpdates {get; set;}

        [Required]
        string CreativeIdeasAndEvaluations {get; set;}

        [Required]
        string BarriersOrChallenges {get; set;}

        [Required]
        string HowCanIHelpYou {get; set;}

        [Required]
        string PersonalGrowthAndDevelopment {get; set;}
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