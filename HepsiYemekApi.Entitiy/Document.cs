using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HepsiYemekApi.Entitiy
{
    public class Document:IDocument<string>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        [BsonElement(Order = 0)]
        public string Id { get; set; } 

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 101)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        
        protected Document()
        {
        }
        
        protected Document(string id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                id = ObjectId.GenerateNewId().ToString();
            }

            Id = id;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(Document other) => Id.Equals(other.Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Document) obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Id.GetHashCode();

        /// <summary>
        /// 
        /// </summary>
        public void SetCreatedAt()
        {
            CreatedAt = DateTime.Now;
        }
    }
    
}