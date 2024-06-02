using Intenteo6.Models.dbModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MessagePack;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Intenteo6.Models
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

        [InverseProperty("IdCarNavigation")]
        public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

        [InverseProperty("IdFotoNavigation")]
        public virtual FotosCar? FotosCar { get; set; }

        [JsonIgnore]
        [IgnoreMember]
        [IgnoreDataMember]
        
        public SelectList? Carros { get; set; }



    }
}
