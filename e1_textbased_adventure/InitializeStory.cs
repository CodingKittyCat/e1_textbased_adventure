using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace e1_textbased_adventure
{
    internal class InitializeStory
    {
        string commands = "\n\ntype 'save-game' to save the game.\ntype 'help' for instructions.";
        public Dictionary<float, Scene> StoryInitialize()
        {

            Dictionary<float, Scene> story = new Dictionary<float, Scene>();
            // Story Template
            //story.Add(float, new Scene("Story",

            //   new List<Choice>
            //   {
            //        new Choice("Choice 1", float),
            //        new Choice("CHoice 2", float),
            //   },
            //
            // "Instructions"
            //   ));

            story.Add(1.0f, new Scene(
                $"You find yourself wandering in a vibrant, lush forest at night. Gigantic trees of green tower out above you. Spread inbetween these trees are big, blue, glowing mushrooms with strands hanging down on them. As a sorcerer, you know that these mushrooms can be highly poisonous for certain individuals, including yourself.\nWhat do you do?{commands}",

            new List<Choice>
            {
                new Choice("I harvest a sample of the mushroom.", 1.1f),
                new Choice("I leave the mushroom and continue on my way.", 1.2f)
            },

            "The mushroom might be poisonous to you, but from the books you've read you remember that it does not instantly kill you. If you are indeed affected by it, under the condition that you're quick enough, you might be able to store it before dying from it."));

            // 1.1 Story
            story.Add(1.1f, new Scene($"You take the risk, not knowing if you're poisonous to it or not. As you start harvesting a sample from the glowing mushroom, you notice your knees begin to feel weak. Your eyes turn blurry, the world around you starts spinning, and your brain feels hazy. You manage to put it in your pouch, and you begin to start feeling better, albeit still feeling weak.\nWhat do you do?{commands}",

            new List<Choice>
            {
                new Choice("I use my magic to make camp, and take a breather. The mushroom really did a number on me and it is wise to rest up.", 1.11f),
                new Choice("I push on, feeling weak but determined to carry out my plans to assassinate the king.", 1.2f)
            },
            
            "There is a danger to making camp, and especially to using magic in this realm. However, if you push on, you may find yourself too weak to continue going. But I wouldn't know, I'm just a narrator after all."));

            story.Add(1.11f, new Scene($"You begin to gather sticks and stones to make a campfire. Whilst setting it up, you hear rustling in the bushes nearby.\nWhat do you do?{commands}",

               new List<Choice>
               {
                    new Choice("I use magic to attack the bush.", 1.12f),
                    new Choice("I carefully assess the situation, and make sure I find out what it is before taking any actions.", 1.13f),
               },

               "You will be severely judged if you use magic to attack this bush."
               ));

            story.Add(1.12f, new Scene($"You form a blue fireball in your hand and throw it towards the bush. It turned out to be an innocent bunny. Good job. You're now a bunny killer.\nWhat's next? Kicking a squirrel against a tree?{commands}",
                
                new List<Choice>
                { 
                    new Choice("I give the bunny a proper burial. I feel remorse, and I regret my decisions.", 1.14f),
                    new Choice ("I return to the camp. I don't want to think about the horrible deeds I just committed.", 1.15f),
                },

                "If you give the bunny a proper burial, I may forgive you for your sins."
                ));

            story.Add(1.13f, new Scene($"You carefully assess the situation, and hear a little squeak coming from the bush. A bunny appears and runs out into the wild.{commands}",

                new List<Choice>
                {

                    new Choice("I return to camp and resume making it ready.", 1.14f),
                },
                "There's only one choice."
                ));

            // 1.2 Story
            story.Add(1.2f, new Scene($"As you continue on your way, you stumble upon a little village, around half your size. Little pixies fly around you.\nWhat do you do?{commands}",

               new List<Choice>
               {
                    new Choice("I talk to them, curious as to what they're up to.", 1.21f),
                    new Choice("I keep pushing, ignoring them.", 1.3f),
               },
               "The pixies may offer valuable information."
               ));

            story.Add(1.21f, new Scene($"They noticed you've stopped to talk to them. 'Oh! A new sapling to play with!' one echoes around you. 'Yes yes, this sapling likes mischief!' echoes another. 'This one's brimming with magic!' the third one goes.\nWhat do you do?{commands}",

                new List<Choice>
                {
                    new Choice("I stick around to play with them. They seem quite nice!", 1.22f),
                    new Choice("I tell them to keep it down. Someone might hear us!", 1.23f),
                    new Choice("After hearing what they said, I quickly move on, making for the village in the mountains.", 2.0f)
                },
                "Sticking around and playing with them may endanger your identity and the time you have to assassinate the king. But since the pixies are magical beings, they are being hunted by the king's guard. They may just decide to choose your side if you stick around."
                ));

            story.Add(1.22f, new Scene($"You mentioned you'd love to play a game with them. You tell them you wanna play hide and seek! They happily oblige 'Ohh, this sapling is fun!' they say. They go to hide. 'Count to 100!' One yells.\nWhat do you do?{commands}",

                new List<Choice>
                {
                            new Choice("I count to 100, fair and square, and go to find them.", 1.24f),
                            new Choice("I cast a locator spell on them all, making them easy to find.", 1.25f),
                },
                "They might not like it if you cheat. It's best to play fair and square on this one."
                ));

            story.Add(1.24f, new Scene($"After counting to 100, you begin to seek them. You manage to find two out of three of pixies! As a reward, they offer you the chance for them to join your side or to get nothing at all, depending on who you pick. Guess away!{commands}",

                new List<Choice>
                {
                    new Choice("Pick pixie one.", 1.28f),
                    new Choice("Pick pixie two.", 1.29f),
                },

                "This is a guessing game. No instructions for this one!"
                ));

            story.Add(1.28f, new Scene($"Unfortunately, it's tough luck. The pixies disappear in a whiff, leaving you with nothing but a sour taste of hide and seek in your mouth.{commands}",
                new List<Choice>
                {
                    new Choice("Continue on your way.", 1.3f)
                },

                "Wrong guess buddy... better luck next time!"
                ));

            story.Add(1.29f, new Scene($"You picked the right pixie! 'Sapling, call for us and we'll be there to help you when you're in need of it!' they all echo together, before disappearing.{commands}",
                new List<Choice>
                {
                    new Choice("Continue on your way.", 1.3f)
                },

                "Guessed it right! Good job. On your way!"
                ));

            story.Add(1.25f, new Scene($"You cast a locator spell on them, which they immediately notice. They yell 'Aw.... the sapling cheats!' they disappear.{commands}",

                new List<Choice>
                {
                    new Choice("Continue on your way.", 1.3f)
                },

                "Quite... unfortunate. Shouldn't have cheated."
                ));

            story.Add(1.23f, new Scene($"'Oh.... this sapling wants us to keep it down!'. One echoes. 'Guards! A magic user is here!' says the other with a mischievous smile.' Guards show up, and capture you. You've lost the game!{commands}",

                new List<Choice>
                {
                    new Choice("End the demo.", 2.0f)
                },

                "Unfortunate... They don't like it when you tell them to keep it down. They're mischievous little creatures."
                ));

            // 1.3 Story
            story.Add(1.3f, new Scene($"As you continue through the woods, you notice a little cabin. In front of it, you see a mysterious hooded figure sitting on a log. What do you do?{commands}",

                new List<Choice>
                {
                    new Choice("I attack the stranger. No witnesses!", 1.31f),
                    new Choice("I carefully approach the stranger.", 1.32f)
                },

                "It might not be the brightest idea to attack someone you don't know..."
                ));

            story.Add(1.31f, new Scene($"Before you can attack the stranger, they immediately know what you're about to do. They throw a fireball at you, scorching your body. Unfortunate...{commands}",


                new List<Choice>
                {
                    new Choice("End Demo.", 2.0f)
                },

                "End of Demo."

                ));

            story.Add(1.32f, new Scene($"You carefully approach the stranger, and he looks up. A smile can be seen on his face. 'So, you finally made it eh? About time, my young student. Come come, sit.' You recognise the voice in an instant. It is your former mentor. The one you presumed to be dead.{commands}",

                new List<Choice>
                {
                    new Choice("I sit down, and start catching up with my old mentor.", 1.33f),
                    new Choice("I shake my head and make for the mountains.", 2.0f)
                },
                 "If you leave now, you may never see him again. Seeing as he's your former mentor, he might be able to teach you a trick or two."
                ));

            story.Add(1.33f, new Scene($"You sit down, and he pulls off his hood. You can tell that his age is showing. His grey, long beard looks poorly taken care of, and there's a scorch mark on the right side of his face. 'I can teach you a power fire spell, to help you in your assassination of the king.' he says. {commands}",

                new List<Choice>
                {
                    new Choice("I accept the lesson gracefully, always having appreciated my master's teachings, and continue on my way.", 2.0f),
                    new Choice("I finish up, and reject the lesson. I have enough of my own work to assasssinate the king. I continue on my way to the mountains.", 2.0f)
                },
                "It would be foolish to reject your master's teachings. The more knowledge, the merrier."
                ));

                
            // 2.0: End of Demo
            story.Add(2.0f, new Scene("Thank you for playing the demo!",

                new List<Choice>
                {
                    new Choice("Return to the main menu. and save your game.", 2.1f)
                }
                ,
                "No Instructions."
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
