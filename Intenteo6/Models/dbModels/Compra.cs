using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intenteo6.Models.dbModels;

[Table("Compra")]
public partial class Compra
{
    [Key]
    [Column("idCompra")]
    public int IdCompra { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column("idUsuario")]
    public int IdUsuario { get; set; }

    [Column("idCar")]
    public int IdCar { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    [ForeignKey("IdCar")]
    [InverseProperty("Compras")]
    public virtual Carro IdCarNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Compras")]
    public virtual AplicationUser IdUsuarioNavigation { get; set; } = null!;
}
