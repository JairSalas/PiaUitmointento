using Intenteo6.Models.dbModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MessagePack;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Intenteo6.Models.DTO
{
    public class MarcaDTO
    {
        
        public int IdMarca { get; set; }

        
        public string Marca1 { get; set; } = null!;

        [JsonIgnore]
        [IgnoreMember]
        [IgnoreDataMember]

        public SelectList? Marcas { get; set; }

    }
}

