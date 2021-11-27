using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User
    {
        [Key]
        [Display(Name = "کد کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserID { get; set; }

        [Display(Name = "نام کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Familly { get; set; }

        [Display(Name = "آدرس کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string Address { get; set; }

        [Display(Name = "شماره تماس کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Phone { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(500)]
        public string Preambles { get; set; }

        [Display(Name = "شرایط پزشکی")]
        [MaxLength(500)]
        public string Terms { get; set; }

        [Display(Name = "سن کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Age { get; set; }

        [Display(Name = "تصویر کاربر")]
        public string ImageName { get; set; }

        [Display(Name = "جنسیت کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool Type { get; set; }

        //Navigation Property
        public virtual List<UserSalary> UserSalaries { get; set; }
        public virtual List<Coach> Coaches { get; set; }

        public User()
        {

        }
    }
}
