using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class Renouvellement
{
    /// <summary>
    /// Id du renouvellement
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// nom du renouvellement
    /// </summary>
    public string Nom { get; set; } = null!;
    /// <summary>
    /// liste des reservations ayant ce type renouvellement
    /// </summary>
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
