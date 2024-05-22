using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intenteo6.Models.dbModels;

[Table("Carro")]
public partial class Carro
{
    [Key]
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

    [ForeignKey("Idmodelo")]
    [InverseProperty("Carros")]
    public virtual Modelo IdmodeloNavigation { get; set; } = null!;

    [ForeignKey("Marca")]
    [InverseProperty("Carros")]
    public virtual Marca MarcaNavigation { get; set; } = null!;
}
