using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intenteo6.Models.dbModels;

[Table("Genero")]
public partial class Genero
{
    [Key]
    [Column("id_genero")]
    public int IdGenero { get; set; }

    [Column("Genero")]
    [StringLength(50)]
    public string Genero1 { get; set; } = null!;

    [InverseProperty("GenderNavigation")]
    public virtual ICollection<AplicationUser> Users { get; set; } = new List<AplicationUser>();
}
