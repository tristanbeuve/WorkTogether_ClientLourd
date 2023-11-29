using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class Abonnement
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int Prix { get; set; }

    public int NbrEmplacement { get; set; }

    public int Reduction { get; set; }

    public string? ImgPath { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
