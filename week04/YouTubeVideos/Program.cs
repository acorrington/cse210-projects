using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create some video instances and add comments
        Video video = new Video("C# Programming", "John Doe", 300);
        video.AddComment(new Comment("Alice", "Great video!"));
        video.AddComment(new Comment("Bob", "Very informative."));
        video.AddComment(new Comment("Charlie", "Thanks for sharing!"));
        videos.Add(video);
        
        // Add another video with comments
        Video video2 = new Video("Learning C#", "Jane Smith", 450);
        video2.AddComment(new Comment("Dave", "Excellent content!"));
        video2.AddComment(new Comment("Eve", "I learned a lot."));
        video2.AddComment(new Comment("Frank", "Keep up the good work!"));
        videos.Add(video2);

        // Add a third video with comments
        Video video3 = new Video("Advanced C# Techniques", "Alice Johnson", 600);
        video3.AddComment(new Comment("Grace", "This is exactly what I needed."));
        video3.AddComment(new Comment("Hank", "Very helpful, thanks!"));
        video3.AddComment(new Comment("Ivy", "Great explanations."));
        videos.Add(video3);

        // Display all videos and their comments
        foreach (var v in videos)
        {
            Console.WriteLine(v.Display());
            Console.WriteLine();
        }
    }
}