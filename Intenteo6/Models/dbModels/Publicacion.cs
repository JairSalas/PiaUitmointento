using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intenteo6.Models.dbModels;

[Table("publicacion")]
public partial class Publicacion
{
    [Key]
    [Column("idPublicacion")]
    public int IdPublicacion { get; set; }

    [Column("fecha")]
    public DateOnly Fecha { get; set; }

    [Column("titulo")]
    [StringLength(100)]
    public string Titulo { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(300)]
    public string Descripcion { get; set; } = null!;

    [Column("clasificacion")]
    public int? Clasificacion { get; set; }

    [Column("id_Usuario")]
    public int IdUsuario { get; set; }

    [Column("imagen")]
    public string? Imagen { get; set; }

    [ForeignKey("Clasificacion")]
    [InverseProperty("Publicacions")]
    public virtual Clasificacion? ClasificacionNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Publicacions")]
    public virtual AplicationUser IdUsuarioNavigation { get; set; } = null!;
}
