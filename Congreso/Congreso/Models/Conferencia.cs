using System;
using System.Collections.Generic;

namespace Congreso.Models;

public partial class Conferencia
{
    public int IdConf { get; set; }

    public DateTime Horario { get; set; }

    public string NombreConf { get; set; } = null!;

    public string Conferencista { get; set; } = null!;

    public int Participantes { get; set; }

    public int FkParticipantes { get; set; }

    public virtual Participante FkParticipantesNavigation { get; set; } = null!;
}
