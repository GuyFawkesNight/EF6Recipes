using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2_5
{
    //书中没有这一句，示例会把数据保存到dbo.PictureCategory表里，
    //而不是Chapter2.PictureCategory里，以致不少朋友认为没有保存成功，加上这一句就不会有问题了
    [Table("PictureCategory", Schema = "Chapter2")]
    public class PictureCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; private set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; private set; }

        [ForeignKey("ParentCategoryId")]
        public virtual PictureCategory ParentCategory { get; set; }   //书中没有virtual关键字，这会导致导航属性不能加载，后面的输出就只有根目录！！

        public virtual  List<PictureCategory> SubCategories { get; set; }

        public PictureCategory()
        {
            SubCategories = new List<PictureCategory>();
        }
    }
}
