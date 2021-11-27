using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CoachPay
    {
        [Key]
        [Display(Name = "کد پرداخت حقوق")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PayID { get; set; }

        [Display(Name = "کد مربی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CoachID { get; set; }

        [Display(Name = "حقوق ماهیانه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Pay { get; set; }

        //Navigation Property
        public virtual List<Coach> Coaches { get; set; }
        public CoachPay()
        {

        }
    }
}
