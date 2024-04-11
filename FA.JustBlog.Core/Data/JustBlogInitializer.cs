using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Utility;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Data
{
    public static class JustBlogInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Lifestyle",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("Lifestyle"),
                        Description = "Articles related to lifestyle."
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Technology",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("Technology"),
                        Description = "Articles related to technology."
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Entertainment",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("Entertainment"),
                        Description = "Articles related to entertainment."
                    }
                );

            modelBuilder.Entity<Tag>()
                .HasData(
                    new Tag
                    {
                        Id = 1,
                        Name = "Food",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("Food"),
                        Description = "Articles related to food.",
                        Count = 10
                    },
                    new Tag
                    {
                        Id = 2,
                        Name = "AI",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("AI"),
                        Description = "Articles related to AI.",
                        Count = 6
                    },
                    new Tag
                    {
                        Id = 3,
                        Name = "Game",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("Game"),
                        Description = "Articles related to game.",
                        Count = 8
                    },
                    new Tag
                    {
                        Id = 4,
                        Name = "Anime",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("Anime"),
                        Description = "Articles related to anime.",
                        Count = 5
                    }
                );

            modelBuilder.Entity<Post>()
                .HasData(
                    new Post
                    {
                        Id = 1,
                        Title = "It’s Time for Honey Ham",
                        ShortDescription = "Not for you? There’s always carrot maqluba, or a no-recipe recipe for kielbasa with pierogies.",
                        PostContent = "<figure class=\"image\">\r\n    <img style=\"aspect-ratio:1024/646;\" src=\"https://static01.nyt.com/images/2022/04/13/dining/08korex-ham-copy/08korex-ham-jumbo.jpg?quality=75&amp;auto=webp\" alt=\"ham\" width=\"1024\" height=\"646\">\r\n    <figcaption>\r\n        <span style=\"background-color:rgb(255,255,255);color:rgb(114,114,114);\">Bobbi Lin for The New York Times. Food Stylist: Monica Pierini.</span>\r\n    </figcaption>\r\n</figure>\r\n<p style=\"margin-left:0px;\">\r\n    Good morning. What I smelled during a 10-minute bicycle ride today: wood smoke, diesel exhaust, grass, frying bacon, rotting wood, bleach, balloon rubber, dollar pizza, a tendril of burning weed, the sharpness of electrical ozone, cart coffee and, last, the strong, sweet scent of lilies — Easter in the air. Good Friday!\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    There’ll be <a href=\"https://cooking.nytimes.com/guides/17-how-to-cook-ham\">ham</a> this weekend, at least for some: <a href=\"https://cooking.nytimes.com/recipes/1023093-honey-baked-ham\">honey</a> (above) or layered into <a href=\"https://cooking.nytimes.com/recipes/1024622-ham-and-cheese-sliders\">sliders</a> with Swiss cheese and a buttery glaze. If you’re amenable to the cut but didn’t manage to order one for the holiday, you can make what’s called <a href=\"https://cooking.nytimes.com/recipes/1016257-fresh-ham-with-maple-balsamic-glaze\">a fresh ham</a>: a pork butt scored and roasted beneath a lacquer of maple syrup and balsamic vinegar, with pecans and candied ginger. How about some <a href=\"https://cooking.nytimes.com/recipes/1018412-sweeney-potatoes\">Sweeney potatoes</a> to go with it? Some <a href=\"https://cooking.nytimes.com/recipes/1015825-creamy-macaroni-and-cheese\">creamy macaroni and cheese</a>?\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    Some may prefer a paschal lamb, maybe <a href=\"https://cooking.nytimes.com/recipes/1018469-butterflied-leg-of-lamb-with-lemon-salsa-verde\">butterflied with lemon salsa verde</a> or <a href=\"https://cooking.nytimes.com/recipes/1014115-braised-leg-of-lamb-with-celery-root-puree\">braised with celery root</a> purée. (I love this kind of <a href=\"https://cooking.nytimes.com/recipes/1015959-myra-waldos-swedish-lamb\">Swedish version</a> Craig Claiborne hustled up in the 1950s, with coffee and a sprinkling of sugar.)\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    Others will make a <a href=\"https://cooking.nytimes.com/recipes/1021983-carrot-maqluba\">carrot maqluba</a> or the creamy spiced eggplant known in India as <a href=\"https://cooking.nytimes.com/recipes/1025040-bagara-baingan-creamy-spiced-eggplant\">bagara baingan</a> to break the Ramadan fast.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    Me, I’ll freestyle, cooking without recipes as has become my weekend passion, working off prompts that I give myself. For example: kielbasa with pierogies, applesauce and sautéed cabbage.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    The kielbasa and pierogies are store-bought (though you can <a href=\"https://cooking.nytimes.com/recipes/1020983-pierogi-ruskie-potato-and-cheese-pierogi\">make your own pierogies</a> easily enough), but the applesauce and cabbage are mine. Peel and chunk some Honeycrisps or Pink Ladies, then cook them soft in a pot with lemon juice, a cinnamon stick and perhaps a pod of star anise. These will mash together beautifully. (Remove the aromatics!) Then rub the sausage with a little bacon fat and roast it in a hot oven. Slice some red cabbage and a small onion or a couple of shallots, and cook all that in melted butter until just soft. Boil the pierogies briefly before sautéing them with butter so they go crisp on one side. Put a dollop of applesauce, a hunk of kielbasa and a serving of pierogies on each plate. Then hit the cabbage with a few tablespoons of prepared horseradish, ideally the sort cut with beets, and add the mixture to each plate. Serve with sour cream and mustard. That’s a terrific meal.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    There are many more actual recipes waiting for you on <a href=\"http://www.nytcooking.com/\">New York Times Cooking</a>. You do, yes, need a subscription to read them. Subscriptions support our work and allow it to continue. Please, if you haven’t done so already, would you consider <a href=\"https://www.nytimes.com/subscription/cooking.html\">subscribing today</a>? Thank you.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    If you find yourself at odds with our technology, please write for help. We’re staffing the inbox at <a href=\"mailto:cookingcare@nytimes.com\">cookingcare@nytimes.com</a>, and someone will get back to you. Or you can write to me if you’d like to bark or simply say hello. I’m at <a href=\"mailto:foodeditor@nytimes.com\">foodeditor@nytimes.com</a>. I can’t respond to every letter. But I read every one I get.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    Now, it has nothing whatsoever to do with cloves or cocktail onions, but it’s neat to see how Guy Ritchie transformed his terrible 2019 movie “The Gentlemen” into an entertaining series on Netflix, also called “<a href=\"https://www.netflix.com/watch/81646429?source=35\">The Gentlemen</a>.” Vinnie Jones as a gamekeeper? He’s still a gangster, and that’s the joy of it.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    Stephen King’s first published novel, “<a href=\"https://stephenking.com/works/novel/carrie.html\">Carrie</a>,” turns 50 this year, and Margaret Atwood wrote the introduction to the anniversary edition, which will be out next month. <a href=\"https://www.nytimes.com/2024/03/25/books/review/stephen-king-carrie-50-anniversary.html\">It’s excerpted</a> in The New York Times Book Review this week, alongside a terrific guide to “<a href=\"https://www.nytimes.com/article/stephen-king-books.html\">The Essential Stephen King</a>” by my colleague Gilbert Cruz, editor of the Review.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    Have you been watching “<a href=\"https://www.hulu.com/series/5422a5f9-e4f1-475e-9217-65e8249388d0\">Shogun</a>” on Hulu? I’m broken to the fist but still don’t know exactly what’s going on. The Times’s <a href=\"https://www.nytimes.com/2024/03/19/arts/television/shogun-episode-5-recap-broken-to-the-fist.html\">recaps</a> of the episodes are helping.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    <span style=\"background-color:rgb(255,255,255);color:rgb(54,54,54);\">Finally, here’s Olivia Rodrigo with “</span><a href=\"https://youtu.be/W-PGNyhmSKA\">So American</a><span style=\"background-color:rgb(255,255,255);color:rgb(54,54,54);\">.” Play that loud while you’re cooking. I’ll </span><a href=\"https://www.penguinrandomhouse.com/books/209906/see-you-on-sunday-by-sam-sifton/\">see you on Sunday</a><span style=\"background-color:rgb(255,255,255);color:rgb(54,54,54);\">!</span>\r\n</p>",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("It’s Time for Honey Ham"),
                        Published = true,
                        PostedOn = new DateTime(2024, 3, 29),
                        Modified = new DateTime(2024, 4, 4),
                        CategoryId = 1,
                        ViewCount = 100,
                        RateCount = 45,
                        TotalRate = 194
                    },
                    new Post
                    {
                        Id = 2,
                        Title = "Engineering household robots to have a little common sense",
                        ShortDescription = "With help from a large language model, MIT engineers enabled robots to self-correct after missteps and carry on with their chores.",
                        PostContent = "<figure class=\"image\">\r\n    <img style=\"aspect-ratio:900/600;\" src=\"https://news.mit.edu/sites/default/files/styles/news_article__image_gallery/public/images/202403/CommonSense-01-press_0.jpg?itok=iRJjlCVv\" alt=\"robot\" width=\"900\" height=\"600\">\r\n</figure>\r\n<p style=\"margin-left:0px;\">\r\n    From wiping up spills to serving up food, robots are being taught to carry out increasingly complicated household tasks. Many such home-bot trainees are learning through imitation; they are programmed to copy the motions that a human physically guides them through.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    It turns out that robots are excellent mimics. But unless engineers also program them to adjust to every possible bump and nudge, robots don’t necessarily know how to handle these situations, short of starting their task from the top.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    Now MIT engineers are aiming to give robots a bit of common sense when faced with situations that push them off their trained path. They’ve developed a method that connects robot motion data with the “common sense knowledge” of large language models, or LLMs.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    Their approach enables a robot to logically parse many given household task into subtasks, and to physically adjust to disruptions within a subtask so that the robot can move on without having to go back and start a task from scratch — and without engineers having to explicitly program fixes for every possible failure along the way.\r\n</p>\r\n<figure class=\"image\">\r\n    <img style=\"aspect-ratio:314/210;\" src=\"https://news.mit.edu/sites/default/files/images/inline/ComonsenseBots-ani_1.gif\" alt=\"AI-arm\" width=\"314\" height=\"210\">\r\n    <figcaption>\r\n        <span style=\"color:rgb(5,5,5);\">Image courtesy of the researchers.</span>\r\n    </figcaption>\r\n</figure>\r\n<p style=\"margin-left:0px;\">\r\n    “Imitation learning is a mainstream approach enabling household robots. But if a robot is blindly mimicking a human’s motion trajectories, tiny errors can accumulate and eventually derail the rest of the execution,” says Yanwei Wang, a graduate student in MIT’s Department of Electrical Engineering and Computer Science (EECS). “With our method, a robot can self-correct execution errors and improve overall task success.”\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    Wang and his colleagues detail their new approach in a <a href=\"https://openreview.net/forum?id=qoHeuRAcSl\">study</a> they will present at the International Conference on Learning Representations (ICLR) in May. The study’s co-authors include EECS graduate students Tsun-Hsuan Wang and Jiayuan Mao, Michael Hagenow, a postdoc in MIT’s Department of Aeronautics and Astronautics (AeroAstro), and Julie Shah, the H.N. Slater Professor in Aeronautics and Astronautics at MIT.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    <strong>Language task</strong>\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    The researchers illustrate their new approach with a simple chore: scooping marbles from one bowl and pouring them into another. To accomplish this task, engineers would typically move a robot through the motions of scooping and pouring — all in one fluid trajectory. They might do this multiple times, to give the robot a number of human demonstrations to mimic.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    “But the human demonstration is one long, continuous trajectory,” Wang says.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    The team realized that, while a human might demonstrate a single task in one go, that task depends on a sequence of subtasks, or trajectories. For instance, the robot has to first reach into a bowl before it can scoop, and it must scoop up marbles before moving to the empty bowl, and so forth. If a robot is pushed or nudged to make a mistake during any of these subtasks, its only recourse is to stop and start from the beginning, unless engineers were to explicitly label each subtask and program or collect new demonstrations for the robot to recover from the said failure, to enable a robot to self-correct in the moment.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    “That level of planning is very tedious,” Wang says.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    Instead, he and his colleagues found some of this work could be done automatically by LLMs. These deep learning models process immense libraries of text, which they use to establish connections between words, sentences, and paragraphs. Through these connections, an LLM can then generate new sentences based on what it has learned about the kind of word that is likely to follow the last.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    For their part, the researchers found that in addition to sentences and paragraphs, an LLM can be prompted to produce a logical list of subtasks that would be involved in a given task. For instance, if queried to list the actions involved in scooping marbles from one bowl into another, an LLM might produce a sequence of verbs such as “reach,” “scoop,” “transport,” and “pour.”\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    “LLMs have a way to tell you how to do each step of a task, in natural language. A human’s continuous demonstration is the embodiment of those steps, in physical space,” Wang says. “And we wanted to connect the two, so that a robot would automatically know what stage it is in a task, and be able to replan and recover on its own.”\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    <strong>Mapping marbles</strong>\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    For their new approach, the team developed an algorithm to automatically connect an LLM’s natural language label for a particular subtask with a robot’s position in physical space or an image that encodes the robot state. Mapping a robot’s physical coordinates, or an image of the robot state, to a natural language label is known as “grounding.” The team’s new algorithm is designed to learn a grounding “classifier,” meaning that it learns to automatically identify what semantic subtask a robot is in — for example, “reach” versus “scoop” — given its physical coordinates or an image view.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    “The grounding classifier facilitates this dialogue between what the robot is doing in the physical space and what the LLM knows about the subtasks, and the constraints you have to pay attention to within each subtask,” Wang explains.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    The team demonstrated the approach in experiments with a robotic arm that they trained on a marble-scooping task. Experimenters trained the robot by physically guiding it through the task of first reaching into a bowl, scooping up marbles, transporting them over an empty bowl, and pouring them in. After a few demonstrations, the team then used a pretrained LLM and asked the model to list the steps involved in scooping marbles from one bowl to another. The researchers then used their new algorithm to connect the LLM’s defined subtasks with the robot’s motion trajectory data. The algorithm automatically learned to map the robot’s physical coordinates in the trajectories and the corresponding image view to a given subtask.\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    The team then let the robot carry out the scooping task on its own, using the newly learned grounding classifiers. As the robot moved through the steps of the task, the experimenters pushed and nudged the bot off its path, and knocked marbles off its spoon at various points. Rather than stop and start from the beginning again, or continue blindly with no marbles on its spoon, the bot was able to self-correct, and completed each subtask before moving on to the next. (For instance, it would make sure that it successfully scooped marbles before transporting them to the empty bowl.)\r\n</p>\r\n<p style=\"margin-left:0px;\">\r\n    “With our method, when the robot is making mistakes, we don’t need to ask humans to program or give extra demonstrations of how to recover from failures,” Wang says. “That’s super exciting because there’s a huge effort now toward training household robots with data collected on teleoperation systems. Our algorithm can now convert that training data into robust robot behavior that can do complex tasks, despite external perturbations.”\r\n</p>",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("Engineering household robots to have a little common sense"),
                        Published = true,
                        PostedOn = new DateTime(2024, 3, 25),
                        Modified = new DateTime(2024, 3, 25),
                        CategoryId = 2,
                        ViewCount = 98,
                        RateCount = 34,
                        TotalRate = 140
                    },
                    new Post
                    {
                        Id = 3,
                        Title = "This Is What Pasta Sounds Like, According to a Scientist and the Composer of 'The White Lotus' Theme Song",
                        ShortDescription = "That's one sweet sounding pasta.",
                        PostContent = "<figure class=\"image\">\r\n    <img style=\"aspect-ratio:960/640;\" src=\"https://s.yimg.com/ny/api/res/1.2/zJk.KFC0CgGFpadwtRXjxw--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTY0MDtjZj13ZWJw/https://media.zenfs.com/en/food_wine_804/1cedc3fb61b7f724d41a93d16a689eb5\" alt=\"pasta\" width=\"960\" height=\"640\">\r\n    <figcaption>\r\n        <a href=\"https://www.gettyimages.com/search/photographer?photographer=Jarana%20Creatives\">Jarana Creatives</a><span style=\"background-color:rgb(255,255,255);color:rgb(110,119,128);\"> / Getty Images</span>\r\n    </figcaption>\r\n</figure>\r\n<p>\r\n    You likely know precisely what a heaping bowl of pasta smells and tastes like, but have you ever considered what it sounds like? Barilla partnered with one seriously cool scientist and one unbelievably accomplished composer to find out.\r\n</p>\r\n<p>\r\n    On Wednesday, the pasta company released its Al Bronzo Soundtrack, a bespoke musical score designed specifically to amplify your pasta-eating experience with the brand’s <a href=\"https://www.barilla.com/en-au/al-bronzo\">Al Bronzo pasta</a> using what’s known as “sonic seasoning.” It’s a term used by Oxford experimental psychologist <a href=\"https://loop.frontiersin.org/people/1194/overview\">Charles Spence</a>, M.A., Ph.D., who has long studied how sound affects our taste buds. (And who <a href=\"https://www.foodandwine.com/how-to-make-airplane-food-taste-better-7563468\">we previously spoke with about the effects of sonic seasoning on flights</a>, and just which headphones to wear to enhance your dining experience at 30,000 feet.)\r\n</p>\r\n<p>\r\n    “It's really nice to work with Barilla to bring the research to life,” Spence shared with Food &amp; Wine. He explained that through his research, he was able to match different pasta types and sauces to “sonic qualities,” including matching high-pitched and fast tempos, distorted noise, and “bright and loud” sounds, which he handed over to his composer. And that composer happens to be three-time Emmy Award winner Cristobal Tapia de Veer, whose work you may recognize from the earworm that is The White Lotus theme songs from seasons one and two.\r\n</p>\r\n<p>\r\n    Tapia de Veer then took all that raw data and translated the work into six tracks, all available at <a href=\"https://albronzosoundtrack.com/comingsoon\">AlBronzoSoundtrack.com</a> and on <a href=\"https://open.spotify.com/playlist/55maOOKGYP3yXtR5x6bZ6t?si=c5f0bfe570d14f1c&amp;pt_success=1&amp;nd=1&amp;dlsi=2deb826cb73749dc\">Spotify</a> so you can listen and taste for yourself. The audio tracks are tailored to each Al Bronzo pasta cut — <a href=\"https://open.spotify.com/track/2xN5JSsNEpBZ2naUByTZ7e?si=a3f56a4808c549f7&amp;nd=1&amp;dlsi=ef217c967ba14e79\">Bucatini</a>, <a href=\"https://open.spotify.com/track/7qni1N4QCfCMsUulOLpJy0?si=573d98baabc444da&amp;nd=1&amp;dlsi=b0d8595c11a9494f\">Mezzi Rigatoni</a>, <a href=\"https://open.spotify.com/track/6VXYxIi3ur1mnfKFLxVCo1?si=6b0524fe4609473a&amp;nd=1&amp;dlsi=72f39e72f93e4fb9\">Spaghetti</a>, <a href=\"https://open.spotify.com/track/1Ulb1lRbfqrIOK2dnEgqrU?si=2f346b6dd8444949\">Penne Rigate</a><span style=\"background-color:rgb(255,255,255);color:rgb(29,34,40);\">, </span><a href=\"https://open.spotify.com/track/2o2d9QUhpG8Mare8EjbbMa\">Fusilli</a><span style=\"background-color:rgb(255,255,255);color:rgb(29,34,40);\">, and </span><a href=\"https://open.spotify.com/track/7wIyxIc6CAQ3KISvA491dY?si=b551b14c966a4e88\">Linguine</a>. As Barilla shared in a press release, each track is meant to “elicit a distinct visceral reaction with every Al Bronzo bite.” “The Al Bronzo Soundtrack is the first time I’ve been asked to musicalize the sensory impressions one experiences when consuming food, and it’s been a delightful experiment,” de Veer added. Spence was equally delighted, telling F&amp;W, “Obviously, I'm not a musician, nor am I a chef, but we were able to work with Cristobal, who can take the scientific findings about sonic seasoning and turn them into tracks. That's the kind where the magic happens.” He added that the research “... deserves a musical mastermind capable of a wide range of auditory composition to achieve the full potential of this incredible sensory pairing.” To celebrate this new release, Barilla is also giving a lucky group of fans the chance to win a limited-edition vinyl record version of the Al Bronzo Soundtrack. The prize also includes recipe cards and tasting instructions. Fans can enter now through 11:59 p.m. EST on April 10 at <a href=\"https://www.albronzosoundtrack.com/\">AlBronzoSoundtrack.com</a>.\r\n</p>",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("This Is What Pasta Sounds Like"),
                        Published = true,
                        PostedOn = new DateTime(2024, 4, 3),
                        Modified = new DateTime(2024, 4, 3),
                        CategoryId = 1,
                        ViewCount = 120,
                        RateCount = 69,
                        TotalRate = 332
                    },
                    new Post
                    {
                        Id = 4,
                        Title = "Stellar Blade Director Says No Microtransactions Outside of Potential Crossover Collaborations",
                        ShortDescription = "Initial run of Eve costumes and New Game Plus will be free, director says.",
                        PostContent = "<p>\r\n    In a recent interview with Ruliweb <a href=\"https://x.com/Genki_JPN/status/1775846533701005643\"><u>translated by Genji and confirmed by IGN</u></a>, director Kim Hyeong-tae talked about what players can expect on launch day. One feature Stellar Blade fans shouldn't expect is microtransactions... at least not initially.\r\n</p>\r\n<p>\r\n    \"We want to make it clear at this point that Stellar Blade will not require any additional expenses that gamers are not aware of beyond what they paid for the package,\" Kim told Ruliweb.\r\n</p>\r\n<figure class=\"image image_resized\" style=\"height:auto;width:100%;\">\r\n    <a href=\"https://assets-prd.ignimgs.com/2024/01/30/19-1706648093884.jpg\"><img style=\"aspect-ratio:3840/2160;\" src=\"https://assets-prd.ignimgs.com/2024/01/30/19-1706648093884.jpg\" alt=\"stellar-blade\" width=\"3840\" height=\"2160\"></a>\r\n    <figcaption>\r\n        STELLAR BLADE WILL BE RECEIVING FREE DLC AFTER LAUNCH, INCLUDING NEW COSTUMES AND A NEW GAME PLUS.\r\n    </figcaption>\r\n</figure>\r\n<p>\r\n    Although Kim assured fans that Stellar Blade won't have any microtransactions, Shift Up hasn't entirely ruled out selling them in the future.\r\n</p>\r\n<p>\r\n    \"The only exception is if we create collaboration costumes with another company's IP, those may be sold for a fee,\" Kim said. \"Also, there is no New Game+ in the launch version, so please look forward to it being updated very soon.\"\r\n</p>\r\n<p>\r\n    While Shift Up has no plans for premium DLC at the outset, Kim did tease players with free updates post-launch, chief among them being additional costumes for its protagonist, Eve. Regardless, come release day, Stellar Blade's base game won't have any microtransactions.\r\n</p>\r\n<p>\r\n    <a href=\"https://www.ign.com/videos/stellar-blade-exclusive-gameplay-video\"><u>Stellar Blade is a Playstation 5 exclusive action-adventure game</u></a> by the developers of the popular mobile game, Goddess of Victory: Nikke. It follows a girl named Eve as she combats mysterious invaders known as NA:tives, to reclaim a post-apocalyptic Earth.\r\n</p>\r\n<p>\r\n    In <a href=\"https://www.ign.com/articles/stellar-blade-preview-sekiro-meets-nier-automata\"><u>our preview</u></a>, we likened Stellar Blade's combat to Sekiro meets Nier: Automata, saying, \"While the depth of its exploration remains to be seen, Stellar Blade’s action alone was more than enough to get me excited for its April 26 release on PlayStation 5.\"\r\n</p>",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("Stellar Blade Director Says No Microtransactions"),
                        Published = true,
                        PostedOn = new DateTime(2024, 4, 5),
                        Modified = new DateTime(2024, 4, 5),
                        CategoryId = 3,
                        ViewCount = 69,
                        RateCount = 25,
                        TotalRate = 107
                    },
                    new Post
                    {
                        Id = 5,
                        Title = "Studio Ghibli Releases Child-Size Totoro and Kiki Towels Perfect for Summer",
                        ShortDescription = "Studio Ghibli releases new child-size towels for summertime water fun, taking inspiration from My Neighbor Totoro and Kiki's Delivery Service.",
                        PostContent = "<figure class=\"image\">\r\n    <img style=\"aspect-ratio:700/350;\" src=\"https://static1.cbrimages.com/wordpress/wp-content/uploads/2024/04/totoro-and-kiki-towel.jpg?q=70&amp;fit=contain&amp;w=1140&amp;h=&amp;dpr=2\" alt=\"totoro\" width=\"700\" height=\"350\">\r\n    <figcaption>\r\n        My Neighbor Totoro\r\n    </figcaption>\r\n</figure>\r\n<p>\r\n    Studio Ghibli has released new child-size towels for the summer. Taking inspiration from two hit classics, My Neighbor Totoro and Kiki's Delivery Service, the towels are officially tagged as \"perfect for the pool or the sea★.\"\r\n</p>\r\n<p>\r\n    The official Studio Ghibli store Donguri Sora has released two new child-size towels: the \"<a href=\"https://www.donguri-sora.com/category/NEW/21902638.html\">My Neighbor Totoro - Totoro and Watermelon Junior Bath Towel</a>\" and the \"<a href=\"https://www.donguri-sora.com/category/NEW/21902638.html\">Kiki's Delivery Service Fruit and Jiji Junior Bath Towel</a>.\" They each retail for 1,100 yen and can be bought by overseas fans through proxy shipping services. Both are 100% cotton, measure 40 x 110 cm, come with snap buttons, and are described as being made from \"a natural material with excellent moisture-wicking properties! The outer material is shirred and has a comfortable smooth texture. It feels nice against your skin♪.\" Readers can check out images of the newly released merchandise, featuring summer motifs such as watermelon, strawberries and flowers, below.\r\n</p>\r\n<figure class=\"image\">\r\n    <img style=\"aspect-ratio:415/415;\" src=\"https://static1.cbrimages.com/wordpress/wp-content/uploads/2024/04/kiki-s-delivery-service-fruit-and-jiji-junior-bath-towel-4.jpg?q=70&amp;fit=contain&amp;w=750&amp;h=415&amp;dpr=2\" alt=\"child-size-towels\" width=\"415\" height=\"415\">\r\n</figure>\r\n<p>\r\n    <a href=\"https://www.cbr.com/studio-ghibli-howl-totoro-spirited-away-hot-topic-clothing-collaboration/\">Studio Ghibli previously collaborated with Hot Topic</a> on wardrobe additions that are likewise perfect for the summer. Ponyo, My Neighbor Totoro, Howl's Moving Castle and Spirited Away all featured in a large range of everything from t-shirts, lounge shorts, athletic dresses and sweatshirts to earrings, socks, necklaces, wallets and more. Given that spring in Japan in full bloom, Ghibli's official store also recently rolled out a <a href=\"https://www.cbr.com/studio-ghibli-my-neighbor-totoro-sakura-restock/\">sakura-themed (cherry blossom) Totoro collection</a>, featuring purses, bowls, mugs and plushies.\r\n</p>",
                        UrlSlug = UrlSlugGenerate.GenerateSlug("Studio Ghibli Releases Child-Size Totoro and Kiki Towels"),
                        Published = false,
                        PostedOn = new DateTime(2024, 4, 8),
                        Modified = new DateTime(2024, 4, 8),
                        CategoryId = 3,
                        ViewCount = 50,
                        RateCount = 32,
                        TotalRate = 157
                    }
                );

            modelBuilder.Entity<PostTagMap>()
                .HasData(
                    new PostTagMap { PostId = 1, TagId = 1 },
                    new PostTagMap { PostId = 2, TagId = 2 },
                    new PostTagMap { PostId = 3, TagId = 1 },
                    new PostTagMap { PostId = 4, TagId = 3 }
                );
            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment
                    {
                        Id = 1,
                        Name = "Bill Gates",
                        Email = "bill_gates@yahoo.com",
                        CommentHeader = "Great post",
                        CommentText = "Great post",
                        CommentedTime = new DateTime(2024, 4, 1),
                        PostId = 1
                    },
                    new Comment
                    {
                        Id = 2,
                        Name = "Mark Zuckerberg",
                        Email = "mark123@yahoo.com",
                        CommentHeader = "Nice post",
                        CommentText = "Nice post",
                        CommentedTime = new DateTime(2022, 4, 4),
                        PostId = 3
                    },
                    new Comment
                    {
                        Id = 3,
                        Name = "Elon Musk",
                        Email = "elon_musk@yahoo.com",
                        CommentHeader = "AI",
                        CommentText = "The AI Era has arrived",
                        CommentedTime = new DateTime(2024, 3, 26),
                        PostId = 2
                    }
                );
        }
    }
}
