using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserSalary
    {
        [Key]
        [Display(Name = "کد پرداخت حقوق")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PayID { get; set; }

        [Display(Name = "کد کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserID { get; set; }

        [Display(Name = "شهریه ماهیانه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Pay { get; set; }

        //Navigation Property
        public virtual List<User> Users{ get; set; }
        public UserSalary()
        {

        }
    }
}
