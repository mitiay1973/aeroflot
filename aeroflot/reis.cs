//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aeroflot
{
    using System;
    using System.Collections.Generic;
    
    public partial class reis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reis()
        {
            this.pokupki = new HashSet<pokupki>();
        }
    
        public int id { get; set; }
        public string reis1 { get; set; }
        public int id_city_otpr { get; set; }
        public int id_city_prib { get; set; }
        public int id_plane { get; set; }
        public System.DateTime date { get; set; }
        public string dlitelnost { get; set; }
        public int zena { get; set; }
    
        public virtual citys citys { get; set; }
        public virtual citys citys1 { get; set; }
        public virtual planes planes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pokupki> pokupki { get; set; }
    }
}
