using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class Abonnement
{
    /// <summary>
    /// id de l'abonnement
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// nom de l'abonnement
    /// </summary>
    public string Nom { get; set; } = null!;
    /// <summary>
    /// prix de l'abonnement
    /// </summary>
    public int Prix { get; set; }
    /// <summary>
    /// nombre d'emplacement qui seront réservé par l'abonnement
    /// </summary>
    public int NbrEmplacement { get; set; }
    /// <summary>
    /// reduction en % de l'abonnement
    /// </summary>
    public int Reduction { get; set; }
    /// <summary>
    /// lien contenant l'accès à l'image correspondant à l'abonnement
    /// </summary>
    public string? ImgPath { get; set; }
    /// <summary>
    /// description de l'abonnement (pour qui cet abonnement est-elle préconisée)
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// liste des reservations d'abonnement
    /// </summary>
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
