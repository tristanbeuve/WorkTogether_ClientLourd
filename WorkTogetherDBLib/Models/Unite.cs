using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class Unite
{
    /// <summary>
    /// id de l'unité
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// identifiant du type d'unité
    /// </summary>
    public int? IdentifiantTypeUniteId { get; set; }
    /// <summary>
    /// identifiant de la baie dans laquelle se trouve cette unité
    /// </summary>
    public int? IdentifiantBaieId { get; set; }
    /// <summary>
    /// identifiant de la réservation dans laquelle se trouve cette unité
    /// </summary>
    public int? IdentifiantReservationId { get; set; }
    /// <summary>
    /// numéro d'identifiant unique de l'unité (basé sur le numéro de la baie)
    /// </summary>
    public string Numero { get; set; } = null!;
    /// <summary>
    /// Status de reservation de l'unité
    /// </summary>
    public bool Status { get; set; }
    /// <summary>
    /// baie dans laquelle se trouve l'unité
    /// </summary>
    public virtual Baie? IdentifiantBaie { get; set; }
    /// <summary>
    /// réservation dans laquelle se trouve l'unité
    /// </summary>
    public virtual Reservation? IdentifiantReservation { get; set; }
    /// <summary>
    /// type d'unité qui définie l'unité
    /// </summary>
    public virtual TypeUnite? IdentifiantTypeUnite { get; set; }
}
