using System.Collections.Generic;

namespace Commander.Interfaces
{
    public class CommandResult
    {
        private List<string> results = new List<string>();
        public List<string> Results { get { return results; } }
        
        public void AddResult(string text)
        {
            results.Add(text);
        }
    }
}
