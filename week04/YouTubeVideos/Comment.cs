public class Comment
{
    private string _name;
    private string _commentText;

    public Comment(string name, string comment)
    {
        _name = name;
        _commentText = comment;
    }

    public string GetComment()
    {
        return $"{_name}: {_commentText}";
    }
}