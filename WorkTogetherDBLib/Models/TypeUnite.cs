using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class TypeUnite
{
    /// <summary>
    /// id du type d'unité
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// nom du type d'unité
    /// </summary>
    public string Nom { get; set; } = null!;
    /// <summary>
    /// liste des unités définie par ce type d'unité
    /// </summary>
    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();
}
