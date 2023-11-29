using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class Unite
{
    public int Id { get; set; }

    public int? IdentifiantTypeUniteId { get; set; }

    public int? IdentifiantBaieId { get; set; }

    public int? IdentifiantReservationId { get; set; }

    public string Numero { get; set; } = null!;

    public bool Status { get; set; }

    public virtual Baie? IdentifiantBaie { get; set; }

    public virtual Reservation? IdentifiantReservation { get; set; }

    public virtual TypeUnite? IdentifiantTypeUnite { get; set; }
}
