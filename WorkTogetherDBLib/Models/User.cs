using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class User
{
    /// <summary>
    /// id de l'utilisateur
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// E-mail de l'utilisateur
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// (DC2Type:json) rôle de l'utilisateur
    /// </summary>
    public string Roles { get; set; } = null!;
    /// <summary>
    /// mot de passe de l'utilisateur
    /// </summary>
    public string Password { get; set; } = null!;
    /// <summary>
    /// nom de l'utilisateur
    /// </summary>
    public string Nom { get; set; } = null!;
    /// <summary>
    /// prénom de l'utilisateur
    /// </summary>
    public string Prenom { get; set; } = null!;
    /// <summary>
    /// liste des réservations de cet utilisateur
    /// </summary>
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

}
