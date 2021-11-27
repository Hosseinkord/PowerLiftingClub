using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Employee
    {
        [Key]
        [Display(Name = "کد کارمند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int EmployeeID { get; set; }

        [Display(Name = "نام کارمند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی کارمند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string  Familly { get; set; }

        [Display(Name = "آدرس کارمند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string Address { get; set; }

        [Display(Name = "شماره تماس کارمند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Phone { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(500)]
        public string Preambles { get; set; }

        [Display(Name = "شرایط پزشکی")]
        [MaxLength(500)]
        public string Terms { get; set; }

        [Display(Name = "سن کارمند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Age { get; set; }

        [Display(Name = "سمت")]
        [MaxLength(300)]
        public string Grade { get; set; }

        [Display(Name = "تصویر کارمند")]
        public string ImageName { get; set; }

        [Display(Name = "جنسیت کارمند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool Type { get; set; }

        //Navigation Property
        public virtual List<EmployeePay> EmployeePays { get; set; }
        public Employee()
        {

        }
    }
}
