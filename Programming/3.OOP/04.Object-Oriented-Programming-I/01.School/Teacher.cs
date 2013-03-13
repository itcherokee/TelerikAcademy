using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class Teacher : Person, ICommentable
    {
        public List<Discipline> Disciplines { get; set; }
        
        public string Comment { get; set; }

    }
}
