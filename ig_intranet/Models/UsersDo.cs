using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnumSample.Models
{
    public class UsersDo
    {
        public int Id { get; set; }
        public string User_FIO { get; set; }
        public string User_FIO_Aunt { get; set; }
        public string User_F_IO { get; set; }
        public string User_Name { get; set; }
        public string Domen { get; set; }
        public string User_in_Domen { get; set; }
        public string User_UID { get; set; }
        public int FlagDel { get; set; }
        public string Date_add_user { get; set; }
    }
}