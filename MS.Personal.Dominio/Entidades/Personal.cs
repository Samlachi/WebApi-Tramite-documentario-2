using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace MS.Personal.Dominio.Entidades
{
    [CollectionProperty("Personal")]
    [BsonIgnoreExtraElements]
    public class Personal : EntityToLower<ObjectId>
    {
        public int id { get; set; }

        public string Nombres { get; set; }

        public string DNI{ get; set; }

        public string Apellidos { get; set; }

        public DateTime Fecha_registro { get; set; }



    }
}
