using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intenteo6.Models.dbModels;

[Table("Marca")]
public partial class Marca
{
    [Key]
    [Column("id_marca")]
    public int IdMarca { get; set; }

    [Column("Marca")]
    [StringLength(50)]
    public string Marca1 { get; set; } = null!;

    [InverseProperty("MarcaNavigation")]
    public virtual ICollection<Carro> Carros { get; set; } = new List<Carro>();
}
