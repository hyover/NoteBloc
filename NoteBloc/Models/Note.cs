using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBloc.Models
{
    public class Note
    {
        public string name {  get; set; }
        public string content { get; set; }
        public DateTime lastModified { get; set; }

    }
}
