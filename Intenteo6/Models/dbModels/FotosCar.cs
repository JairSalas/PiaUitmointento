using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Intenteo6.Models.dbModels;

[Table("fotosCar")]
public partial class FotosCar
{
    [Key]
    [Column("idFoto")]
    public int IdFoto { get; set; }

    [Column("id_car")]
    public int IdCar { get; set; }

    [Column("imagen")]
    public string Imagen { get; set; } = null!;

    [ForeignKey("IdFoto")]
    [InverseProperty("FotosCar")]
    public virtual Carro IdFotoNavigation { get; set; } = null!;
}
