using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // --- COMMENT CLASS ---
    public class Comment
    {
        // Member variables (Encapsulated using private backing fields and properties)
        private string _commenterName;
        private string _commentText;

        // Constructor to initialize a comment
        public Comment(string commenterName, string commentText)
        {
            _commenterName = commenterName;
            _commentText = commentText;
        }

        // Methods to retrieve information
        public string GetCommenterName()
        {
            return _commenterName;
        }

        public string GetCommentText()
        {
            return _commentText;
        }

        // Method to display a formatted comment line
        public void DisplayComment()
        {
            Console.WriteLine($"- {_commenterName}: \"{_commentText}\"");
        }
    }

    // --- VIDEO CLASS ---
    public class Video
    {
        // Member variables
        private string _title;
        private string _author;
        private int _lengthInSeconds;
        private List<Comment> _comments;

        // Constructor to initialize video properties and create the empty comment list
        public Video(string title, string author, int lengthInSeconds)
        {
            _title = title;
            _author = author;
            _lengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        // Method to add a comment to this specific video
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        // Method to return the total count of comments (Core Abstraction Requirement)
        public int GetCommentCount()
        {
            return _comments.Count;
        }

        // Method to display all video data along with its sub-list of comments
        public void DisplayVideoInfo()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"Title:  {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_lengthInSeconds} seconds");
            Console.WriteLine($"Total Comments: {GetCommentCount()}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Comments:");
            
            foreach (Comment comment in _comments)
            {
                comment.DisplayComment();
            }
            Console.WriteLine("==================================================\n");
        }
    }

    // --- MAIN PROGRAM CLASS ---
    class Program
    {
        static void Main(string[] args)
        {
            // Create a main list to hold all video objects
            List<Video> videoList = new List<Video>();

            // ------------------------------------------------------------
            // VIDEO 1: Tech Review
            // ------------------------------------------------------------
            Video video1 = new Video("C# Abstraction Explained in 10 Minutes", "CodeCraft", 600);
            video1.AddComment(new Comment("Alice Smith", "This cleared up so much confusion about OOP!"));
            video1.AddComment(new Comment("Bob Jones", "Great pacing, thanks for the clear diagrams."));
            video1.AddComment(new Comment("Charlie Brown", "Can you make a video on Encapsulation next?"));
            videoList.Add(video1);

            // ------------------------------------------------------------
            // VIDEO 2: Travel Vlog
            // ------------------------------------------------------------
            Video video2 = new Video("Exploring the Hidden Streets of Tokyo", "Wanderlust Chronicles", 1245);
            video2.AddComment(new Comment("David Miller", "The cinematography in this vlog is absolutely gorgeous."));
            video2.AddComment(new Comment("Eva Green", "Adding these exact locations to my bucket list right now!"));
            video2.AddComment(new Comment("Frank Castle", "What type of camera lens did you use for the night scenes?"));
            videoList.Add(video2);

            // ------------------------------------------------------------
            // VIDEO 3: Cooking Tutorial
            // ------------------------------------------------------------
            Video video3 = new Video("The Ultimate One-Pot Sourdough Pasta", "Chef Gourmet", 480);
            video3.AddComment(new Comment("Grace Hopper", "Tried this recipe tonight and my entire family loved it."));
            video3.AddComment(new Comment("Hank Pym", "Is there a good gluten-free substitute for this specific pasta?"));
            video3.AddComment(new Comment("Ivy Pepper", "Simple, fast, and minimal cleanup. Perfect weeknight meal."));
            videoList.Add(video3);

            // ------------------------------------------------------------
            // VIDEO 4: Gaming / Entertainment
            // ------------------------------------------------------------
            Video video4 = new Video("Speedrunning My Favorite Retro Game Blindfolded", "PixelPerfect", 1820);
            video4.AddComment(new Comment("Jack Ryan", "Unbelievable skill! That final boss fight was pure tension."));
            video4.AddComment(new Comment("Karen Page", "How many hours did it take you to memorize the map layout?"));
            video4.AddComment(new Comment("Leo Fitz", "The audio cues execution here is absolutely mind-blowing."));
            videoList.Add(video4);

            // ------------------------------------------------------------
            // ITERATE AND DISPLAY ALL INFORMATION
            // ------------------------------------------------------------
            Console.WriteLine("YOUTUBE VIDEO TRACKING SYSTEM REPORT\n");
            
            foreach (Video video in videoList)
            {
                video.DisplayVideoInfo();
            }
        }
    }
}
