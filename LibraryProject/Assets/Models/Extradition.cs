//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryProject.Assets.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Extradition
    {
        public string IdReaderBillet { get; set; }
        public string IdBook { get; set; }
        public System.DateTime DateOfIssue { get; set; }
        public System.DateTime ReturnDate { get; set; }
        public int IdReader { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
