using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class Renouvellement
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
