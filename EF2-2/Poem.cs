//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF2_2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Poem
    {
        public int PoemId { get; set; }
        public int PoetId { get; set; }
        public string Title { get; set; }
        public int MeterId { get; set; }
    
        public virtual Meter Meter { get; set; }
        public virtual Poet Poet { get; set; }
    }
}
