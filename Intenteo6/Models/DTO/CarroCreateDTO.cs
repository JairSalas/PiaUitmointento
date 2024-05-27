using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;
using MessagePack;

namespace Intenteo6.Models.DTO
{
    public class CarroCreateDTO
    {

        [Column("id_car")]
        public int IdCar { get; set; }

        [Column("name")]
        [StringLength(80)]
        public string Name { get; set; } = null!;

        [Column("año")]
        [StringLength(4)]
        public string Año { get; set; } = null!;

        [Column("idmodelo")]
        public int Idmodelo { get; set; }

        [Column("precio", TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        [Column("marca")]
        public int Marca { get; set; }

        [JsonIgnore]
        [IgnoreMember]
        [IgnoreDataMember]
        public SelectList? Carros { get; set; }

       

    }
}
