namespace excuse_api;

public class Excuse
{
    public int Id { get; set; }
    public string Text { get; set; }

    // Adding a parametrized constructor means the default is not generated. Add explicitly.
    public Excuse()
    {
        Text = "";
    }

    public Excuse(int id, string text)
    {
        Id = id;
        Text = text;
    }
    // TODO: type of excuse?    

}