using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class Reservation
{
    public int Id { get; set; }

    public int? IdentifiantAbonnementId { get; set; }

    public DateTime DateDeb { get; set; }

    public DateTime DateEnd { get; set; }

    public bool RenAuto { get; set; }

    public int Quantity { get; set; }

    public int? RenouvellementId { get; set; }

    public int? CustomerId { get; set; }

    public string Numero { get; set; } = null!;

    public bool Delaie { get; set; }

    public virtual User? Customer { get; set; }

    public virtual Abonnement? IdentifiantAbonnement { get; set; }

    public virtual Renouvellement? Renouvellement { get; set; }

    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();
}
