using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Likes
    {
        public int Social { get; set; }
        [Key]
        public int Id { get; set; }
        public int LikeCount { get; set; }
        public int LikeAtanId { get; set; }
    }
}
