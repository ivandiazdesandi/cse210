using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Amazing Cats", "Alice", 120);
        video1.AddComment(new Comment("Bob", "So cute!"));
        video1.AddComment(new Comment("Carol", "I love cats!"));
        video1.AddComment(new Comment("Dave", "Best video ever."));
        videos.Add(video1);

        Video video2 = new Video("Travel Vlog", "Eve", 300);
        video2.AddComment(new Comment("Frank", "Great tips!"));
        video2.AddComment(new Comment("Grace", "Can't wait to visit."));
        video2.AddComment(new Comment("Heidi", "Loved the scenery."));
        videos.Add(video2);

        Video video3 = new Video("Cooking 101", "Ivan", 180);
        video3.AddComment(new Comment("Judy", "Yummy recipe!"));
        video3.AddComment(new Comment("Mallory", "Tried it yesterday."));
        video3.AddComment(new Comment("Oscar", "Delicious!"));
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.Display();
            Console.WriteLine();
        }
    }
}