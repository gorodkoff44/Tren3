//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tren3
{
    using System;
    using System.Collections.Generic;
    
    public partial class StroyMaterial
    {
        public int NumMateriala { get; set; }
        public string Name { get; set; }
        public string EdIzm { get; set; }
        public Nullable<int> Ostatok { get; set; }
        public Nullable<int> IDSklad { get; set; }
    
        public virtual Sklad Sklad { get; set; }
    }
}