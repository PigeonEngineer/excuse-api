namespace excuse_api;


public static class ExcuseService {

    // Just asked chatgpt to generate a list of 100 excuses. 
    // Model: GPT 3.5, prompt: "Come up with a list of 100 excuses that a progammer would use to justify his code failing"
    // private static readonly Excuse[] FileAIGeneratedExcuses =  { new Excuse{Id = 1, Text = "I'm too tired"}, new Excuse{Id = 2, Text = "I'm too busy"}, new Excuse{Id = 3, Text = "I'm too hungry"}};
    private static readonly List<Excuse> FileAIGeneratedExcuses = new List<Excuse>();

    static ExcuseService() {
        // read AIGeneratedExcuses.txt and populate FileAIGeneratedExcuses
        foreach (string excuse in File.ReadLines("Services/AIGeneratedExcuses.txt")) {
            FileAIGeneratedExcuses = FileAIGeneratedExcuses.Append(new Excuse{Id = FileAIGeneratedExcuses.Count+ 1, Text = excuse}).ToList();
        }
    }
    
    public static Excuse GetExcuse(int id) {
        return FileAIGeneratedExcuses[id-1];
    }
    

}