using System;
using System.Text.RegularExpressions;

class WordCount
{
    private string text = "";

    public string SetValue { set { this.text = value; } }
    public string GetValue { get { return this.text; } }


    private Regex regex = new Regex(@"[a-z\']+");
    
    
    public void Parse_and_output( string text) 
    {
        Dictionary<string,int> dict = new Dictionary<string, int>();
        MatchCollection matches = regex.Matches(text);
        
        for (int i = 0; i < matches.Count; i++)
        {
            var match = matches[i];
            string t = match.Groups[0].Value;
            if (!dict.ContainsKey(t)) 
            {
                dict.Add(t, 1);
            }
            else 
            {
                dict[t]++;
            }
        }
        
        foreach (KeyValuePair<string, int> pair in dict) 
        {
            Console.WriteLine("Ключ: " + pair.Key + ", Значення: " + pair.Value);
        }
    }
}

class MainP 
{
    static void Main(string[] args) 
    {
        WordCount word = new WordCount();

        word.SetValue = "As the sun began its descent behind the rugged mountains, casting hues of orange and pink across the sky, Sarah found herself wandering through the quaint village nestled in the valley below. The cobblestone streets were lined with charming cottages adorned with colorful flower boxes, their scent wafting gently in the warm evening breeze. She paused to admire a group of children playing happily in the town square, their laughter echoing off the ancient stone walls.\r\n\r\nTurning down a narrow alleyway, Sarah stumbled upon a bustling market filled with stalls overflowing with fresh fruits, artisan crafts, and the savory aroma of street food cooking on open grills. The air was alive with the sound of vendors haggling and musicians playing lively tunes, creating a vibrant tapestry of sights and sounds.\r\n\r\nAs she meandered through the lively scene, Sarah couldn't help but feel a sense of wonder and excitement at the beauty and diversity of the world around her. Each new discovery seemed to hold the promise of adventure and possibility, beckoning her to explore further and immerse herself in the rich tapestry of life.";
        word.Parse_and_output(word.GetValue);


    }
}