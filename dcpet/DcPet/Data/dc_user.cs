//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DcPet.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class dc_user
    {
        public System.Guid token { get; set; }
        public string uuid { get; set; }
        public string device { get; set; }
        public string platform { get; set; }
        public string firstip { get; set; }
        public string lastip { get; set; }
        public System.DateTime firsttime { get; set; }
        public Nullable<System.DateTime> lasttime { get; set; }
        public bool disable { get; set; }
    }
}