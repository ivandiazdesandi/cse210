public class Video
{
    public string _title;
    public string _author;
    public int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public int TotalComments()
    {
        return _comments.Count;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void Display()
    {
        Console.WriteLine("Title: " + _title);
        Console.WriteLine("Author: " + _author);
        Console.WriteLine("Length: " + _length + " seconds");
        Console.WriteLine("Comments (" + TotalComments() + "):");

        foreach (Comment c in _comments)
        {
            Console.WriteLine(c.Display());
        }
    }
}