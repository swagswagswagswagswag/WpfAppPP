//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppPP
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginTab
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public int Password { get; set; }
    
        public virtual UserTable UserTable { get; set; }
    }
}