//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryProjestLibraryTests.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            this.Extradition = new HashSet<Extradition>();
        }
    
        public string ISBN { get; set; }
        public int Author { get; set; }
        public string Title { get; set; }
        public string BBK { get; set; }
        public int HousePublication { get; set; }
        public int IdCity { get; set; }
        public int YearOfPublication { get; set; }
        public int PageCounts { get; set; }
        public int BooksCount { get; set; }
    
        public virtual Author Author1 { get; set; }
        public virtual BBK BBK1 { get; set; }
        public virtual City City { get; set; }
        public virtual HousePublication HousePublication1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Extradition> Extradition { get; set; }
    }
}
