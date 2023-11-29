using System;
using System.Collections.Generic;

namespace WorkTogetherDBLib.Class;

public partial class Baie
{
    public int Id { get; set; }

    public int NbrEmplacement { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();
}
