//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deuda
    {
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Valor { get; set; }
        public byte Pagado { get; set; }
        public int TiempoActivo { get; set; }
        public string OperadorRut { get; set; }
        public int EgresoId { get; set; }
    
        public virtual Egreso Egreso { get; set; }
        public virtual Operador Operador { get; set; }
    }
}
