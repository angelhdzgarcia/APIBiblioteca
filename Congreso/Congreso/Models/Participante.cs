using System;
using System.Collections.Generic;

namespace Congreso.Models;

public partial class Participante
{
    public int IdParticipantes { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Twitter { get; set; } = null!;

    public int Avatar { get; set; }

    public virtual ICollection<Conferencia> Conferencia { get; set; } = new List<Conferencia>();
}
