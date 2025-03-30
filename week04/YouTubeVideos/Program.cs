using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learning C#", "TechTutor", 300);
        video1.AddComment(new Comment("Alice", "This helped so much!"));
        video1.AddComment(new Comment("Bob", "Clear and concise."));
        video1.AddComment(new Comment("Eve", "What version of C# is this?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Cooking Pasta", "ChefLeo", 420);
        video2.AddComment(new Comment("Mia", "So easy to follow!"));
        video2.AddComment(new Comment("Noah", "Yum, made it tonight."));
        video2.AddComment(new Comment("Ava", "Do gnocchi next please."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Hiking in Utah", "TrailBlazer", 600);
        video3.AddComment(new Comment("Sam", "Gorgeous views."));
        video3.AddComment(new Comment("Lily", "Can’t wait to go."));
        video3.AddComment(new Comment("Leo", "What trail is this?"));
        videos.Add(video3);

        // Display each video and its comments
        foreach (Video vid in videos)
        {
            Console.WriteLine("\n======================");
            Console.WriteLine($"Title: {vid.Title}");
            Console.WriteLine($"Author: {vid.Author}");
            Console.WriteLine($"Length: {vid.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {vid.GetNumberOfComments()}");

            foreach (Comment comment in vid.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
        }
    }
}