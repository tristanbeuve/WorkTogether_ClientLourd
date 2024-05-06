using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class Baie
{
    /// <summary>
    /// id de la baie
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// status d'occupation de la baie
    /// </summary>
    public string Numero { get; set; }

    /// <summary>
    /// nombre d'emplacement que contient la baie
    /// </summary>
    public int NbrEmplacement { get; set; }
    /// <summary>
    /// status d'occupation de la baie
    /// </summary>
    public bool Status { get; set; }
    /// <summary>
    /// liste des unités qui sont contenue dans la baie
    /// </summary>
    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();
}
