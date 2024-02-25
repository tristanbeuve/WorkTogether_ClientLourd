using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class Reservation
{
    /// <summary>
    /// id d'une réservation
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// identifiant de l'abonnement de cette réservation
    /// </summary>
    public int? IdentifiantAbonnementId { get; set; }
    /// <summary>
    /// date de début de la réservation
    /// </summary>
    public DateTime DateDeb { get; set; }
    /// <summary>
    /// date de fin de la réservation
    /// </summary>
    public DateTime DateEnd { get; set; }
    /// <summary>
    /// état d'activation du renouvellement automatique (0=désactivé, 1=activé)
    /// </summary>
    public bool RenAuto { get; set; }
    /// <summary>
    /// quantité d'abonnement de la reservation
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// identifiant du renouvellement
    /// </summary>
    public int? RenouvellementId { get; set; }
    /// <summary>
    /// identfifant du client de cette réservation
    /// </summary>
    public int? CustomerId { get; set; }
    /// <summary>
    /// numéro d'identifiant de la réservation
    /// </summary>
    public string Numero { get; set; } = null!;
    /// <summary>
    /// état du delaie avant la fin de la résiliation de la réservation
    /// </summary>
    public bool Delaie { get; set; }
    /// <summary>
    /// Client de la reservation
    /// </summary>
    public virtual User? Customer { get; set; }
    /// <summary>
    /// abonnement de la réservation 
    /// </summary>
    public virtual Abonnement? IdentifiantAbonnement { get; set; }
    /// <summary>
    /// renouvellement de la réservation
    /// </summary>
    public virtual Renouvellement? Renouvellement { get; set; }
    /// <summary>
    /// liste des unités réservés par cette réservation
    /// </summary>
    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();
}
