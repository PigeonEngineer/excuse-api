namespace excuse_api;


public static class ExcuseService
{

    // Just asked chatgpt to generate a list of 100 excuses. 
    // Model: GPT 3.5, prompt: "Come up with a list of 100 excuses that a progammer would use to justify his code failing"
    private static readonly List<Excuse> FileAIGeneratedExcuses = new List<Excuse>();

    static ExcuseService()
    {
        foreach (string excuse in File.ReadLines("Services/AIGeneratedExcuses.txt"))
        {
            FileAIGeneratedExcuses = FileAIGeneratedExcuses.Append(new Excuse { Id = FileAIGeneratedExcuses.Count + 1, Text = excuse }).ToList();
        }
    }

    public static Excuse GetExcuse(int id)
    {
        return FileAIGeneratedExcuses[id - 1];
    }

    public static Excuse GetRandomExcuse()
    {
        Random rnd = new Random();
        return FileAIGeneratedExcuses[rnd.Next(0, FileAIGeneratedExcuses.Count)];
    }




}