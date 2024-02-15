namespace VideoSharingTryIT
{
    public class Video
    {
        private int videoId;
        private int likes;
        private int dislikes;
        private int views;

        public int VideoId { get => videoId; set => videoId = value; }
        public int Likes { get => likes; set => likes = value; }
        public int Dislikes { get => dislikes; set => dislikes = value; }
        public int Views { get => views; set => views = value; }

        public Video(int id)
        {
            VideoId = id;
            Likes = 0;
            Dislikes = 0;
            Views = 0;
        }
    }
}