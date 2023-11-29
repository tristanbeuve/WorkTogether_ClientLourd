using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class TypeUnite
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();
}
