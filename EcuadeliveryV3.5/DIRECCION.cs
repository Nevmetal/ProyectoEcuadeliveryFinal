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
    
    public partial class DIRECCION
    {
        public int DIR_ID { get; set; }
        public int USU_ID { get; set; }
        public int CIU_ID { get; set; }
        public string DIR_CALLE_P { get; set; }
        public string DIR_CALLE_S { get; set; }
        public string DIR_NUM_C { get; set; }
        public string DIR_DETALLE { get; set; }
    
        public virtual CIUDAD CIUDAD { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
