using System.Collections.ObjectModel;

namespace Music.Core.Model
{
    public class Artist
    {
        public Artist()
        {
            Musics = new Collection<Track>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Musics { get; set; }
    }
}