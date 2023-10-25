using System;

namespace NoteBloc.Models
{
    public class Note
    {
        public string Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime LastModified { get; set; }
    }

}
