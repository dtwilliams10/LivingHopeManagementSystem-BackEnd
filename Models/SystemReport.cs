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
        
        [BsonElement("ReportID")]
        public string ReportID {get; set;}

        [BsonElement("Name")]
        public string Name {get; set;}

        [BsonElement("ReportDate")]
        [DataType(DataType.Date)]
        DateTime ReportDate {get; set;}

        [BsonElement("CreatedDate")]
        [DataType(DataType.Date)]
        DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonElement("UpdatedDate")]
        [DataType(DataType.Date)]
        DateTime UpdatedDate { get; set; } = DateTime.Now;

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