//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcuadeliveryV3._5
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETALLE_FACTURA
    {
        public int DET_ID { get; set; }
        public int FAC_ID { get; set; }
        public int PRO_ID { get; set; }
        public int DET_CANTIDAD { get; set; }
    
        public virtual PRODUCTOS PRODUCTOS { get; set; }
        public virtual FACTURA_CABECERA FACTURA_CABECERA { get; set; }
    }
}