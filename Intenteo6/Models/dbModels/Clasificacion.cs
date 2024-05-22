using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intenteo6.Models.dbModels;

[Table("Clasificacion")]
public partial class Clasificacion
{
    [Key]
    [Column("id_clasificacion")]
    public int IdClasificacion { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("ClasificacionNavigation")]
    public virtual ICollection<Publicacion> Publicacions { get; set; } = new List<Publicacion>();
}
