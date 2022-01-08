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
    using System.ComponentModel.DataAnnotations;

    public partial class DriversLicense
    {
        public int DriversLicense_Id { get; set; }
        public int User_Id { get; set; }
        public int Category_Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DateOfIssue { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyy}", ApplyFormatInEditMode = true)]
        public System.DateTime ExpiringDate { get; set; }
        public string CityOfIssue { get; set; }
        public int Number { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Users Users { get; set; }
    }
}
