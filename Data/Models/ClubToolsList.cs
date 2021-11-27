using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClubToolsList
    {
        [Key]
        [Display(Name = "کد وسیله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ToolsID { get; set; }


        [Display(Name = "نام وسیله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string ToolsName { get; set; }

        [Display(Name = "تعداد وسیله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CountTools { get; set; }

        [Display(Name = "خراب شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool Spoiled { get; set; }
    }
}
