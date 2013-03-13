using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    public class Student : Person, ICommentable
    {
        public Class Number { get; set; }

        public string Comment { get; set; }
    }
}
