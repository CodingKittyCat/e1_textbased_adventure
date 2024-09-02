using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace e1_textbased_adventure
{
    internal class InitializeStory
    {
        public Dictionary<float, Scene> StoryInitialize()
        {
            Dictionary<float, Scene> story = new Dictionary<float, Scene>();
            story.Add(1.0f, new Scene("Story 1",

            new List<Choice>
            {
                new Choice("Choice 1", 1.1f),
                new Choice("Choice 2", 1.2f)
            }));

            return story;
        }

    }
    class Scene
    {
        public string Text { get; }
        public List<Choice> Choices { get; }

        public Scene(string text, List<Choice> choices)
        {
            Text = text;
            Choices = choices;
        }
    }

    class Choice
    {
        public string Option { get; }
        public float NextScene { get; }

        public Choice(string option, float nextScene) 
        {
            Option = option;
            NextScene = nextScene;  
        }
}
