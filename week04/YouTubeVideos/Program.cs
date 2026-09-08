using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Amazing Technology Review",
            "Tech World",
            620
        );

        video1.AddComment(new Comment(
            "John",
            "This was a very helpful review!"
        ));

        video1.AddComment(new Comment(
            "Mary",
            "I really enjoyed watching this video."
        ));

        video1.AddComment(new Comment(
            "David",
            "The explanation was easy to understand."
        ));

        video1.AddComment(new Comment(
            "Sarah",
            "I would like to see more videos like this."
        ));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "Best Travel Destinations",
            "Travel Adventures",
            845
        );

        video2.AddComment(new Comment(
            "Mike",
            "These places look amazing!"
        ));

        video2.AddComment(new Comment(
            "Anna",
            "I want to visit these places someday."
        ));

        video2.AddComment(new Comment(
            "James",
            "Thanks for sharing these travel ideas."
        ));

        video2.AddComment(new Comment(
            "Lisa",
            "The scenery was beautiful."
        ));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "Easy Cooking Tutorial",
            "Food With Friends",
            510
        );

        video3.AddComment(new Comment(
            "Tom",
            "I tried this recipe and it worked great!"
        ));

        video3.AddComment(new Comment(
            "Emily",
            "This recipe looks delicious."
        ));

        video3.AddComment(new Comment(
            "Chris",
            "The instructions were very clear."
        ));

        video3.AddComment(new Comment(
            "Jessica",
            "I will definitely try this recipe."
        ));

        videos.Add(video3);

        // Video 4
        Video video4 = new Video(
            "Learn Programming Basics",
            "Code Academy",
            735
        );

        video4.AddComment(new Comment(
            "Daniel",
            "This helped me understand programming."
        ));

        video4.AddComment(new Comment(
            "Rachel",
            "Great explanation!"
        ));

        video4.AddComment(new Comment(
            "Kevin",
            "I learned something new today."
        ));

        video4.AddComment(new Comment(
            "Sophie",
            "Please make more tutorials like this."
        ));

        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"  {comment.GetName()}: {comment.GetText()}"
                );
            }

            Console.WriteLine();
        }
    }
}