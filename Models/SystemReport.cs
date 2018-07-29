using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LHMSAPI.Models
{
    public class SystemReport
    {
        [BsonId]        
        public ObjectId ObjectID {get; set;}
        
        [BsonRequired]
        [BsonElement("ReportID")]
        public string ReportID {get; set;}

        //TODO: Update with logic to use the logged in user's info.
        [BsonElement("Name")]
        public string Name {get; set;}

        [BsonElement("ReportDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        DateTime ReportDate {get; set;}

        [BsonElement("CreatedDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonElement("UpdatedDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        DateTime UpdatedDate { get; set; } = DateTime.Now;

        [BsonRequired]
        [BsonElement("SystemName")]
        SystemName SystemName {get; set;}

        [Required]
        [BsonElement("SystemUpdate")]
        string SystemUpdate {get; set;}

        [Required]
        [BsonElement("PersonnelUpdates")]
        string PersonnelUpdates {get; set;}

        [Required]
        [BsonElement("CreativeIdeasAndEvaluations")]
        string CreativeIdeasAndEvaluations {get; set;}

        [Required]
        [BsonElement("BarriersOrChallenges")]
        string BarriersOrChallenges {get; set;}

        [Required]
        [BsonElement("HowCanIHelpYou")]
        string HowCanIHelpYou {get; set;}

        [Required]
        [BsonElement("PersonalGrowthAndDevelopment")]
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