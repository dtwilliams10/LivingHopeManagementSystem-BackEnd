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
        public DateTime ReportDate {get; set;}

        [BsonElement("CreatedDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonElement("UpdatedDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [BsonRequired]
        [BsonElement("SystemName")]
        public SystemName SystemName {get; set;}

        [BsonRequired]
        [BsonElement("SystemUpdate")]
        public string SystemUpdate {get; set;}

        [BsonRequired]
        [BsonElement("PersonnelUpdates")]
        public string PersonnelUpdates {get; set;}

        [BsonRequired]
        [BsonElement("CreativeIdeasAndEvaluations")]
        public string CreativeIdeasAndEvaluations {get; set;}

        [BsonRequired]
        [BsonElement("BarriersOrChallenges")]
        public string BarriersOrChallenges {get; set;}

        [BsonRequired]
        [BsonElement("HowCanIHelpYou")]
        public string HowCanIHelpYou {get; set;}

        [BsonRequired]
        [BsonElement("PersonalGrowthAndDevelopment")]
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