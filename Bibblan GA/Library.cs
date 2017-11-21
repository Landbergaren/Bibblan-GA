﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibblan_GA
{
    class Library
    {

        public static List<Book> BuildLibrary()
        {
            List<Book> Books = new List<Book>();
            Books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250, false, "The Great Gatsby, F. Scott Fitzgerald's third book, stands as the supreme achievement of his career. This exemplary novel of the Jazz Age has been acclaimed by generations of readers. The story of the fabulously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan, of lavish parties on Long Island at a time when The New York Times noted gin was the national drink and sex the national obsession. it is an exquisitely crafted tale of America in the 1920s." ));
            Books.Add(new Book("Nineteen Eighty-Four", "George Orwell", "Fiction", 4, 160, true, "Written in 1948, 1984 was George Orwell’s chilling prophecy about the future. And while 1984 has come and gone, his dystopian vision of a government that will do anything to control the narrative is timelier than ever..."));
            Books.Add(new Book("Origin", "Dan Brown", "Fiction", 3, 356, false, "Robert Langdon, Harvard professor of symbology and religious iconology, arrives at the ultramodern Guggenheim Museum Bilbao to attend a major announcement—the unveiling of a discovery that “will change the face of science forever.” The evening’s host is Edmond Kirsch, a forty-year-old billionaire and futurist whose dazzling high-tech inventions and audacious predictions have made him a renowned "));
            Books.Add(new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", 5, 250, true, "Harper Lee's Pulitzer prize-winning masterwork of honor and injustice in the deep south—and the heroism of one man in the face of blind and violent hatred. One of the best - loved stories of all time, To Kill a Mockingbird has been translated into more than forty languages, sold more than forty million copies worldwide, served as the basis for an enormously popular motion picture, and was voted one of the best novels of the twentieth century by librarians across the country.A gripping, heart - wrenching, and wholly remarkable tale of coming - of - age in a South poisoned by virulent prejudice, it views a world of great beauty and savage inequities through the eyes of a young girl, as her father—a crusading local lawyer—risks everything to defend a black man unjustly accused of a terrible crime."));


            Books.Add(new Book("Harry Potter and the Philosophers Stone", "J.K Rowling", "Fantasy", 1, 225, false, "Harry Potter has no idea how famous he is. That's because he's being raised by his miserable aunt and uncle who are terrified Harry will learn that he's really a wizard, just as his parents were. But everything changes when Harry is summoned to attend an infamous school for wizards, and he begins to discover some clues about his illustrious birthright. From the surprising way he is greeted by a lovable giant, to the unique curriculum and colorful faculty at his unusual school, Harry finds himself drawn deep inside a mystical world he never knew existed and closer to his own noble destiny."));
            Books.Add(new Book("Game of Thrones, A song of ice and fire", "George R.R Martin", "Fantasy", 2, 231, true, "From a master of contemporary fantasy comes the first novel of a landmark series unlike any you’ve ever read before. With A Game of Thrones, George R. R. Martin has launched a genuine masterpiece, bringing together the best the genre has to offer. Mystery, intrigue, romance, and adventure fill the pages of this magnificent saga, the first volume in an epic series sure to delight fantasy fans everywhere."));
            Books.Add(new Book("The Hobbit", "J.R.R Tolkien", "Fantasy", 3, 405, false, "Bilbo Baggins is a hobbit who enjoys a comfortable, unambitious life, rarely traveling any farther than his pantry or cellar. But his contentment is disturbed when the wizard Gandalf and a company of dwarves arrive on his doorstep one day to whisk him away on an adventure. They have launched a plot to raid the treasure hoard guarded by Smaug the Magnificent, a large and very dangerous dragon. Bilbo reluctantly joins their quest, unaware that on his journey to the Lonely Mountain he will encounter both a magic ring and a frightening creature known as Gollum."));
            Books.Add(new Book("Sword of Shannara", "Terry Brooks", "Fantasy", 2, 210, true, "Living in peaceful Shady Vale, Shea Ohmsford knew little of the troubles that plagued the rest of the world. Then the giant, forbidding Allanon revaled that the supposedly dead Warlock Lord was plotting to destory the world. The sole weapon against this Power of Darkness was the Sword of Shannara, which could only be used by a true heir of Shannara--Shea being the last of the bloodline, upon whom all hope rested. Soon a Skull Bearer, dread minion of Evil, flew into the Vale, seeking to destroy Shea. To save the Vale, Shea fled, drawing the Skull Bearer after him...."));

            Books.Add(new Book("Pride and Prejudice", "Jane Austen", "Romance", 3, 250, false, "Few have failed to be charmed by the witty and independent spirit of Elizabeth Bennet in Austen’s beloved classic Pride and Prejudice. When Elizabeth Bennet first meets eligible bachelor Fitzwilliam Darcy, she thinks him arrogant and conceited; he is indifferent to her good looks and lively mind. When she later discovers that Darcy has involved himself in the troubled relationship between his friend Bingley and her beloved sister Jane, she is determined to dislike him more than ever. In the sparkling comedy of manners that follows, Jane Austen shows us the folly of judging by first impressions and superbly evokes the friendships, gossip and snobberies of provincial middle-class life."));
            Books.Add(new Book("Fifty Shades of Grey", "E.L James", "Romance", 3, 250, true, "When literature student Anastasia Steele goes to interview young entrepreneur Christian Grey, she encounters a man who is beautiful, brilliant, and intimidating. The unworldly, innocent Ana is startled to realize she wants this man and, despite his enigmatic reserve, finds she is desperate to get close to him. Unable to resist Ana’s quiet beauty, wit, and independent spirit, Grey admits he wants her, too—but on his own terms."));
            Books.Add(new Book("Wallbanger", "Alice Clayton", "Romance", 3, 250, false, "The first night after Caroline moves into her fantastic new San Francisco apartment, she realizes she's gaining an--um--intimate knowledge of her new neighbor's nocturnal adventures. Thanks to paper-thin walls and the guy's athletic prowess, she can hear not just his bed banging against the wall but the ecstatic response of what seems (as loud night after loud night goes by) like an endless parade of women. And since Caroline is currently on a self-imposed dating hiatus, and her neighbor is clearly lethally attractive to women, she finds her fantasies keep her awake even longer than the noise. So when the wallbanging threatens to literally bounce her out of bed, Caroline, clad in sexual frustration and a pink baby-doll nightie, confronts Simon Parker, her heard-but-never-seen neighbor. The tension between them is as thick as the walls are thin, and the results just as mixed. Suddenly, Caroline is finding she may have discovered a whole new definition of neighborly..."));
            Books.Add(new Book("Twilight", "Stephenie Meyer", "Fiction", 3, 250, true, "Isabella Swan's move to Forks, a small, perpetually rainy town in Washington, could have been the most boring move she ever made. But once she meets the mysterious and alluring Edward Cullen, Isabella's life takes a thrilling and terrifying turn. Up until now, Edward has managed to keep his vampire identity a secret in the small community he lives in, but now nobody is safe, especially Isabella, the person Edward holds most dear. The lovers find themselves balanced precariously on the point of a knife-between desire and danger.Deeply romantic and extraordinarily suspenseful, Twilight captures the struggle between defying our instincts and satisfying our desires. This is a love story with bite."));

            Books.Add(new Book("Steve Jobs", "Walter Isaacson", "Biography", 3, 250, false, "Based on more than forty interviews with Steve Jobs conducted over two years—as well as interviews with more than 100 family members, friends, adversaries, competitors, and colleagues—Walter Isaacson has written a riveting story of the roller-coaster life and searingly intense personality of a creative entrepreneur whose passion for perfection and ferocious drive revolutionized six industries: personal computers, animated movies, music, phones, tablet computing, and digital publishing. Isaacson’s portrait touched millions of readers."));
            Books.Add(new Book("The Diary of Anne Frank", "Anne Frank", "Biography", 3, 250, true, "In 1942, with the Nazis occupying Holland, a thirteen-year-old Jewish girl and her family fled their home in Amsterdam and went into hiding. For the next two years, until their whereabouts were betrayed to the Gestapo, the Franks and another family lived cloistered in the “Secret Annexe” of an old office building. Cut off from the outside world, they faced hunger, boredom, the constant cruelties of living in confined quarters, and the ever-present threat of discovery and death. In her diary Anne Frank recorded vivid impressions of her experiences during this period. By turns thoughtful, moving, and surprisingly humorous, her account offers a fascinating commentary on human courage and frailty and a compelling self-portrait of a sensitive and spirited young woman whose promise was tragically cut short."));
            Books.Add(new Book("Dreams from My Father", "Barack Obama", "Biography", 3, 250, false, "In this lyrical, unsentimental, and compelling memoir, the son of a black African father and a white American mother searches for a workable meaning to his life as a black American. It begins in New York, where Barack Obama learns that his father—a figure he knows more as a myth than as a man—has been killed in a car accident. This sudden death inspires an emotional odyssey—first to a small town in Kansas, from which he retraces the migration of his mother’s family to Hawaii, and then to Kenya, where he meets the African side of his family, confronts the bitter truth of his father’s life, and at last reconciles his divided inheritance. "));
            Books.Add(new Book("Finding My Virginity", "Richard Branson", "Biography", 3, 250, true, "Richard Branson’s Losing My Virginity shared the outrageous tale of how he built Virgin from a student magazine into one of the greatest brands in history. No challenge was too daunting, no opportunity too outlandish to pursue. And each new adventure started with five simple words: “Screw it, let’s do it.”"));

            return Books;
        }

        public static List<Account> BuildMemberList()
        {
            List<Account> Members = new List<Account>();
            Members.Add(new Adult("Steve Jobs", "666-666", 50, true, "Apple", "Apple"));
            Members.Add(new Adult("Steve Jobs", "666-666", 50, true, "Banana", "Banana"));
            Members.Add(new Adult("Steve Jobs", "666-666", 50, true, "Peach", "Peach"));
            Members.Add(new Minor("Steve Jobs", "666-666", 5, "true", "Broccoli", "Broccoli"));
            Members.Add(new Minor("Steve Jobs", "666-666", 12, "true", "Potato", "Potato"));
            Members.Add(new Minor("Steve Jobs", "666-666", 10, "true", "Onion", "Onion"));

            return Members;
        }

        public void Rent ( Book selectedBook )
        {
            // SelectedBookInListview -> search for element in library -> Select Element in library and insert in Rent parameter

            selectedBook.TotalBooks--;
            if (selectedBook.TotalBooks == 0)
                selectedBook.Availability = false;
        }
    }
}
