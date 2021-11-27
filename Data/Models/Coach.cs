using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Coach
    {
        [Key]
        [Display(Name = "کد مربی")]
        public int CoachID { get; set; }

        [Display(Name = "نام مربی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی مربی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Familly { get; set; }

        [Display(Name = "آدرس مربی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string Address { get; set; }

        [Display(Name = "شماره تماس مربی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Phone { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(500)]
        public string Preambles { get; set; }

        [Display(Name = "شرایط پزشکی")]
        [MaxLength(500)]
        public string Terms { get; set; }

        [Display(Name = "سن مربی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Age { get; set; }

        [Display(Name = "سمت")]
        [MaxLength(300)]
        public string Grade { get; set; }

        [Display(Name = "تصویر مربی")]
        public string ImageName { get; set; }

        [Display(Name = "جنسیت مربی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool Type { get; set; }

        //Navigation Property
        public virtual List<CoachPay> CoachPays { get; set; }
        public virtual List<User> Users{ get; set; }

        public Coach()
        {

        }
    }
}
