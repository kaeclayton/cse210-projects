using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Video video1 = new Video("Around the World", "Ken Adams", 56);
        Video video2 = new Video("My Time at the Tour", "Jonas Pogacar", 135);
        Video video3 = new Video("China's Beauty", "Isaak Harrison", 246);
        Video video4 = new Video("LEGO Eiffel Tower Build", "Kae Clayton", 98);

        video1.AddComment(new Comment("Josh Tolman", "Blew my mind!"));
        video1.AddComment(new Comment("Jer Weir", "So grateful for the information."));
        video1.AddComment(new Comment("Shannon Cosden", "I really felt like I went around the world with you."));
        video2.AddComment(new Comment("Stephanie Darr", "I never knew cycling could be so sweet."));
        video2.AddComment(new Comment("David Jackson", "I know it's not great but I loved the crashes!"));
        video2.AddComment(new Comment("Allison Treybig", "The descents were my favorite to watch, WOW!"));
        video3.AddComment(new Comment("Alecia Gordon", "I had no idea China was so beautiful."));
        video3.AddComment(new Comment("Alicia Leonard", "Will you be going back soon? Can I come?"));
        video3.AddComment(new Comment("Jeesh Shumway", "I've never considered going to China, now I will."));
        video4.AddComment(new Comment("Sally Saperstein", "That was so much fun to watch!"));
        video4.AddComment(new Comment("Bernard Josephson", "I didn't know watching LEGO building could be so satisfying."));
        video4.AddComment(new Comment("Regina Philangie", "Those were such small pieces."));
        video4.AddComment(new Comment("Abby Normal", "Impressive how tall that got."));

        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}