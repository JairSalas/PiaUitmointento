using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intenteo6.Models.dbModels;

[Table("modelo")]
public partial class Modelo
{
    [Key]
    [Column("idModelo")]
    public int IdModelo { get; set; }

    [Column("descripcion")]
    [StringLength(50)]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("IdmodeloNavigation")]
    public virtual ICollection<Carro> Carros { get; set; } = new List<Carro>();
}
