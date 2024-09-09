using System;
using System.Collections.Generic;

namespace e1_textbased_adventure
{
    internal class InitializeStory
    {
        public Dictionary<float, Scene> StoryInitialize()
        {

             
            Dictionary<float, Scene> story = new Dictionary<float, Scene>();
            // Story Template
            //story.Add(int, new Scene("Story",

            //   new List<Choice>
            //   {
            //        new Choice("Choice 1", float),
            //        new Choice("CHoice 2", float),
            //   }
            //   ));
            story.Add(1.0f, new Scene(
                "You find yourself wandering in a vibrant, lush forest at night. Gigantic trees of green tower out above you. Spread inbetween these trees are big, blue, glowing mushrooms with strands hanging down on them. As a sorcerer, you know that these mushrooms can be highly poisonous for certain individuals, including yourself.\nWhat do you do?"
                ,

            new List<Choice>
            {
                new Choice("I harvest a sample of the mushroom.", 1.1f),
                new Choice("I leave the mushroom and continue on my way.", 1.2f)
            },

            "Test Instructions"));

            // 1.1 Story
            story.Add(1.1f, new Scene("You take the risk, not knowing if you're poisonous to it or not. As you start harvesting a sample from the glowing mushroom, you notice your knees begin to feel weak. Your eyes turn blurry, the world around you starts spinning, and your brain feels hazy. You manage to put it in your pouch, and you begin to start feeling better, albeit still feeling weak. What do you do?",

            new List<Choice>
            {
                new Choice("I use my magic to make camp, and take a breather. The mushroom really did a number on me and it is wise to rest up.", 1.11f),
                new Choice("I push on, feeling weak but determined to carry out my plans to assassinate the king.", 1.12f)
            },
            
            "Test Instructions no.2"));

            story.Add(1.11f, new Scene("You begin to gather sticks and stones to make a campfire. ",

               new List<Choice>
               {
                    new Choice("Choice 1", 1.13f),
                    new Choice("CHoice 2", 1.14f),
               },

               "Test Instructions no.3"
               ));

            story.Add(1.2f, new Scene("Story",

               new List<Choice>
               {
                    new Choice("Choice 1", 1.5f),
                    new Choice("CHoice 2", 1.6f),
               },
               "test Instruct"
               ));
            return story;
        }
    }

    class Scene
    {
        public string Text { get; }
        public List<Choice> Choices { get; }
        public string Instructions { get; }

        public Scene(string text, List<Choice> choices, string instructions)
        {
            Text = text;
            Choices = choices;
            Instructions = instructions;
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
}
