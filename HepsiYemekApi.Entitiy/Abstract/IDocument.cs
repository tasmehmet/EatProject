using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HepsiYemekApi.Entitiy
{
    public interface IDocument
    {
    }
    public interface IDocument<out TKey> : IDocument where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }
        DateTime CreatedAt { get; set; }
    }
}