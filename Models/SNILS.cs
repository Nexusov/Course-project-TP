//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Course_Project_TP_6.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SNILS
    {
        public int SNILS_Id { get; set; }
        public int User_Id { get; set; }
        public int Number { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
