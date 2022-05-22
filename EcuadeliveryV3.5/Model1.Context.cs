﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BD_EcuaDeliveryEntities : DbContext
    {
        public BD_EcuaDeliveryEntities()
            : base("name=BD_EcuaDeliveryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<CIUDAD> CIUDAD { get; set; }
        public virtual DbSet<DETALLE_FACTURA> DETALLE_FACTURA { get; set; }
        public virtual DbSet<DIRECCION> DIRECCION { get; set; }
        public virtual DbSet<FACTURA_CABECERA> FACTURA_CABECERA { get; set; }
        public virtual DbSet<PRODUCTOS> PRODUCTOS { get; set; }
        public virtual DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        
        public virtual int CrearFactura(Nullable<int> iUSU_ID)
        {
            var iUSU_IDParameter = iUSU_ID.HasValue ?
                new ObjectParameter("iUSU_ID", iUSU_ID) :
                new ObjectParameter("iUSU_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CrearFactura", iUSU_IDParameter);
        }
    
        public virtual int LlenarDetalle(Nullable<int> iPRO_ID, Nullable<int> iDET_CANTIDAD)
        {
            var iPRO_IDParameter = iPRO_ID.HasValue ?
                new ObjectParameter("iPRO_ID", iPRO_ID) :
                new ObjectParameter("iPRO_ID", typeof(int));
    
            var iDET_CANTIDADParameter = iDET_CANTIDAD.HasValue ?
                new ObjectParameter("iDET_CANTIDAD", iDET_CANTIDAD) :
                new ObjectParameter("iDET_CANTIDAD", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LlenarDetalle", iPRO_IDParameter, iDET_CANTIDADParameter);
        }

    }
}
