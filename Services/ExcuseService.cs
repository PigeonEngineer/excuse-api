namespace excuse_api;


public static class ExcuseService
{

    // Just asked chatgpt to generate a list of 100 excuses. 
    // Model: GPT 3.5, prompt: "Come up with a list of 100 excuses that a progammer would use to justify his code failing"
    private static readonly List<Excuse> FileAIGeneratedExcuses = new List<Excuse>();


    static ExcuseService()
    {
        // Static "constructor" gets called only once, on first use of the class. 
        // So we are loading the excuses from only once, not on every request :)
        
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

    // Get excuses that have searchString in their text
    // Ex. "machine" matches "it worked on my machine" and "there are bugs in the machine"
    public static List<Excuse> GetExcusesByQuery(string searchString) {
        List<Excuse> matches = FileAIGeneratedExcuses.Where(excuse => excuse.Text.Contains(searchString)).ToList();
        return matches;
    }

    




}