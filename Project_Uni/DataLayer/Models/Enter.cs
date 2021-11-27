using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Enter
    {
        [Key]
        public int EnterId { get; set; }

        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = " از ساعت")]
        public int startTime{ get; set; }
        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "تا ساعت ")]
        public int EndTime { get; set; }
        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "کدوم ترم")]
        public int NumTerm { get; set; }
        [Required(ErrorMessage = "لطفا این قسمت را به طور کامل پر کنید")]
        [Display(Name = "تعداد کلاس")]
        public int NumClass { get; set; }

    }
}
