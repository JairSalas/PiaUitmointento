using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intenteo6.Models.dbModels;

[Table("MetodoPago")]
public partial class MetodoPago
{
    [Key]
    [Column("id_metodPago")]
    public int IdMetodPago { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("num_targeta")]
    [StringLength(20)]
    public string NumTargeta { get; set; } = null!;

    [Column("direccion")]
    [StringLength(100)]
    public string Direccion { get; set; } = null!;

    [Column("nombre_titular")]
    [StringLength(50)]
    public string NombreTitular { get; set; } = null!;

    [Column("fecha_nacimiento")]
    public DateOnly? FechaNacimiento { get; set; }

    [Column("codigo_seguridad")]
    [StringLength(50)]
    public string CodigoSeguridad { get; set; } = null!;

    [Column("banco_emisor")]
    [StringLength(50)]
    public string? BancoEmisor { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("MetodoPagos")]
    public virtual AplicationUser IdUsuarioNavigation { get; set; } = null!;
}
