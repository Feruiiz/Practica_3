using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appBank
{
    public class Solicitud
    {
        public String nombre_cliente;
        public int id_solicitud;
        public String descripcion;
        public String monto;

        public Solicitud(String n, int id, String d, String m)
        {
            this.nombre_cliente = n;
            this.id_solicitud = id;
            this.descripcion = d;
            this.monto = m;
        }
    }
}