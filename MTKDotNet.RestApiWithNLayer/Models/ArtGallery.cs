namespace MTKDotNet.RestApiWithNLayer.Models
{
    public class ArtGalleryModel
    {

        public class Rootobject
        {
            public Tbl_Gallery[] Tbl_Gallery { get; set; }
            public Tbl_Art[] Tbl_Art { get; set; }
            public Tbl_Artist[] Tbl_Artist { get; set; }
        }

        public class Tbl_Gallery
        {
            public int GalleryId { get; set; }
            public int ArtistId { get; set; }
            public int ArtId { get; set; }
        }

        public class Tbl_Art
        {
            public int ArtId { get; set; }
            public string ArtName { get; set; }
            public string ArtDescription { get; set; }
        }

        public class Tbl_Artist
        {
            public int ArtistId { get; set; }
            public string ArtistName { get; set; }
            public Social[] Social { get; set; }
        }

        public class Social
        {
            public string Name { get; set; }
            public string Link { get; set; }
        }

    }
}
