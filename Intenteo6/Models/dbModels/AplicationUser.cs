using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace Intenteo6.Models.dbModels
{

    public class AplicationUser: IdentityUser<int>
    {
     

        

        [Column("lastName")]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Column("mLastName")]
        [StringLength(50)]
        public string MLastName { get; set; } = null!;

        [Column("biography")]
        [StringLength(200)]
        public string? Biography { get; set; }

        [Column("gender")]
        public int Gender { get; set; }

       
        [Column("image_profile")]
        public string? ImageProfile { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

        [ForeignKey("Gender")]
        [InverseProperty("Users")]
        public virtual Genero GenderNavigation { get; set; } = null!;

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<MetodoPago> MetodoPagos { get; set; } = new List<MetodoPago>();

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Publicacion> Publicacions { get; set; } = new List<Publicacion>();

    }
}
