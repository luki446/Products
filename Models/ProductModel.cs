using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.Models
{
    public class ProductModel
    {
        [BsonId]
        [BsonElement("id")]
        [BsonRepresentation(BsonType.String)]
        public Guid Id {set; get;}

        [BsonElement("name")]
        [BsonRequired]
        public string Name {set; get;}
        
        [BsonElement("price")]
        [BsonRequired]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price {set; get;}
    }
}