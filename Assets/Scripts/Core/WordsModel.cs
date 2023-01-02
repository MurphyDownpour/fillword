using System.Collections.Generic;

namespace DefaultNamespace
{
    public class WordsModel
    {
        private List<string> _words;
        
        public List<string> Words => _words;

        public WordsModel(List<string> words)
        {
            _words = words;
        }

        public void RemoveWord(string word)
        {
            _words.Remove(word);
        }

        public bool WordExists(string word)
        {
            return _words.Exists(x => x == word);
        }
    }
}