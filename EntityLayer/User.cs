using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string NickName { get; set; }
        public byte[] ImageUrl { get; set; }
    }
}
