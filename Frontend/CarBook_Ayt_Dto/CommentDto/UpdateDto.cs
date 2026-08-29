using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Dto.CommentDto
{
    public class UpdateDto
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int BlogID { get; set; }
     
    }
}

