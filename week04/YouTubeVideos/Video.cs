public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        if (_comments == null)
        {
            _comments = new List<Comment>();
        }
        _comments.Add(comment);
    }

    public int GetCommentsCount()
    {
        return _comments.Count;
    }

    public string Display()
    {
        return $"{_title} by {_author} ({_length} seconds) \n{GetCommentsCount()} Comments:\n{string.Join("\n", _comments.Select(c => c.Display()))}";
    }
}