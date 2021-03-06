﻿using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TProyecto
    {
        public TProyecto()
        {
            TUsuarioproyecto = new HashSet<TUsuarioproyecto>();
        }

        public Guid ProyId { get; set; }
        public string ProyNom { get; set; }
        public string ProyDesc { get; set; }
        public DateTime? ProyFecha { get; set; }
        public string ProyUrl { get; set; }
        public byte[] RowVersion { get; set; } //Es para usar concurrencia optimista, byte es tipo hora, minutos, segundos. 
        public ICollection<TUsuarioproyecto> TUsuarioproyecto { get; set; }
    }
}
