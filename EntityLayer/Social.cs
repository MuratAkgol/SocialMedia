using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Social
    {
        [Key]
        public int Id { get; set; }
        public int AtanKulId { get; set; }
        public string Icerik { get; set; }
    }
}
