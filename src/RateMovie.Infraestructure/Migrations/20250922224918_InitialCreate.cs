using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RateMovie.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stars = table.Column<sbyte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.CheckConstraint("CK_Movies_Stars", "Stars BETWEEN 1 AND 5");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Comment", "Name", "Stars" },
                values: new object[,]
                {
                    { 1, "A masterful blend of thriller, dark comedy, and social commentary. Bong Joon-ho's film is a razor-sharp look at class inequality, told through the story of two families from different ends of the economic spectrum. The plot is full of unpredictable twists and turns that keep you on the edge of your seat, culminating in a shocking and thought-provoking climax. The performances are outstanding, and the direction is impeccable, making every scene a study in tension and satire. It’s a compelling, multi-layered film that resonates long after the credits roll, cementing its place as a modern cinematic classic.", "Parasite", (sbyte)5 },
                    { 2, "A relentless, high-octane action spectacle. George Miller's return to the wasteland is a visual masterpiece, with stunning practical effects and jaw-dropping stunts that feel truly tangible. The film is a two-hour chase sequence, but it never gets old, thanks to its breathtaking choreography and a surprisingly deep mythology. Charlize Theron's Furiosa is a powerful, compelling hero, and Tom Hardy's Max is a perfect silent force of nature. It's a pure shot of adrenaline from start to finish, redefining the modern action genre and proving that great storytelling can be told through pure motion and visceral energy. An exhilarating and unforgettable ride.", "Mad Max: Fury Road", (sbyte)5 },
                    { 3, "A visually majestic and immersive science fiction epic. Denis Villeneuve successfully brings the first half of Frank Herbert's complex novel to the big screen with a grand sense of scale and atmosphere. The film's world-building is meticulous, drawing you into the harsh, beautiful desert planet of Arrakis. The sound design and cinematography are breathtaking, creating a truly cinematic experience. While it serves as a slow-burning setup for the sequel, it's a patient and thoughtful adaptation that focuses on mood, political intrigue, and the weight of prophecy. A triumph of world-building and a must-see for fans of large-scale sci-fi.", "Dune (2021)", (sbyte)4 },
                    { 4, "A monumental, sprawling biographical thriller. Christopher Nolan delves into the complex life of J. Robert Oppenheimer, the 'father of the atomic bomb,' with a non-linear narrative that jumps between different time periods. The film is a dense and intense character study, exploring themes of ambition, responsibility, and the moral consequences of scientific innovation. Cillian Murphy delivers a mesmerizing performance, capturing Oppenheimer's intellectual brilliance and internal turmoil. The use of practical effects and a powerful score makes the story feel incredibly visceral and immediate. It’s a gripping and thought-provoking historical epic that's as much about a man as it is about the birth of a new, terrifying age.", "Oppenheimer", (sbyte)5 },
                    { 5, "A wildly inventive, heartfelt, and chaotic journey through the multiverse. This film is a brilliant blend of high-concept sci-fi action and a deeply emotional family drama. It’s a whirlwind of a movie, filled with creative fight sequences and mind-bending concepts, all while being anchored by a beautiful story about a mother and daughter trying to understand each other. Michelle Yeoh gives a career-defining performance that is both hilarious and genuinely moving. It's a movie that celebrates kindness and empathy amidst absolute absurdity, proving that even the most ridiculous ideas can be used to tell a profound and touching story about love, existence, and acceptance.", "Everything Everywhere All at Once", (sbyte)5 },
                    { 6, "Considered one of the worst movies ever made, this cult classic is unintentionally hilarious from start to finish. The direction, acting, and script are all famously nonsensical, creating a truly unique cinematic experience. Tommy Wiseau's bizarre performance and the film’s disjointed subplots have earned it a devoted following. It's so utterly bad that it becomes a source of endless entertainment, with fans often quoting its most memorable lines. A perfect example of a film that fails so spectacularly that it achieves a different kind of success, becoming a cultural phenomenon for all the wrong reasons. A must-watch for anyone who enjoys cinematic train wrecks.", "The Room", (sbyte)1 },
                    { 7, "An uncanny, visually baffling, and deeply bizarre adaptation of the popular stage musical. The film's CGI 'digital fur technology' created a jarring and unsettling aesthetic that made the human actors look like monstrous, humanoid felines. The plot is nonsensical, and the musical numbers, while well-sung by the talented cast, are often overshadowed by the perplexing visuals. It’s a movie that seems to have no clear vision, making for a truly painful and unforgettable viewing experience. It's a textbook example of a big-budget movie going spectacularly wrong, earning its place as one of the most ridiculed films of its time.", "Cats (2019)", (sbyte)1 },
                    { 8, "A universally hated live-action adaptation that completely disrespects its source material. This film strays so far from the iconic anime and manga that it becomes unrecognizable, alienating fans with its weak plot, poor acting, and terrible special effects. The characters bear little resemblance to their original counterparts, and the film fails to capture the energy, humor, or scale that made Dragon Ball so beloved. It's a prime example of a failed adaptation, serving as a cautionary tale for how not to bring an anime to the big screen. A film that is truly a stain on the franchise's legacy.", "Dragonball Evolution", (sbyte)1 },
                    { 9, "A landmark in independent filmmaking and a masterclass in non-linear storytelling. Quentin Tarantino's crime film is a stylish and endlessly quotable mosaic of interwoven stories featuring a cast of unforgettable characters. The dialogue is sharp, witty, and full of cultural references, and the film's unconventional structure adds a sense of constant surprise. It's a cinematic experience that is both cool and profound, blending dark humor with sudden moments of violence and genuine humanity. The film’s influence on pop culture and filmmaking is undeniable, and it remains as fresh and captivating today as it was upon its release.", "Pulp Fiction", (sbyte)5 },
                    { 10, "A breathtaking and immersive war film that feels like a single, continuous shot. Sam Mendes' direction is a stunning technical achievement, putting you directly in the shoes of two young British soldiers on a perilous mission. The sense of urgency and danger is palpable throughout the entire film. The cinematography is masterful, with sweeping, fluid camera movements that highlight the desolate and dangerous landscapes of the Western Front. It's a visceral, emotional, and harrowing portrayal of the senselessness of war, focusing on the human cost rather than grand strategy. A technical tour de force that is as impressive as it is moving.", "1917", (sbyte)4 },
                    { 11, "A dark and disturbing character study that re-imagines one of pop culture's most iconic villains. Joaquin Phoenix gives a tour-de-force performance, transforming himself into Arthur Fleck and creating a portrait of a man's descent into madness. The film is a gritty and realistic look at mental illness and societal neglect, with a tone that is far more a psychological thriller than a traditional superhero movie. It's an uncomfortable but compelling watch, with a powerful central performance and a raw, unflinching perspective. The film is a testament to the power of a strong lead actor and a focused, singular vision.", "Joker", (sbyte)5 },
                    { 12, "This sequel suffers from an overcrowded plot with too many villains and competing storylines. While Andrew Garfield and Emma Stone have great chemistry and the visual effects are decent, the film's narrative feels disjointed and rushed. It introduces multiple villains without giving any of them enough time to be fully developed, leading to a muddled and unsatisfying experience. It's a prime example of a studio trying to build a shared universe too quickly without focusing on a single, compelling story. A wasted opportunity for a promising reboot.", "The Amazing Spider-Man 2", (sbyte)2 },
                    { 13, "A notoriously campy and ridiculed superhero film that completely misunderstands its source material. Joel Schumacher's direction takes a neon-soaked, over-the-top approach, resulting in a movie filled with cheesy one-liners, bizarre costume designs (like the infamous bat-nipples), and a nonsensical plot. While some now view it as a 'so bad it's good' spectacle, it was a critical and commercial failure that nearly killed the Batman film franchise for years. A truly absurd and baffling cinematic misstep that stands out for all the wrong reasons.", "Batman & Robin", (sbyte)1 },
                    { 14, "A groundbreaking horror film that is as terrifying as it is brilliant. Jordan Peele's debut is a masterclass in building tension and subverting genre tropes, using the framework of a horror movie to deliver a sharp and incisive critique of modern racism. The film's atmosphere is unsettling from the very beginning, building a sense of dread that culminates in a truly chilling and unforgettable climax. Daniel Kaluuya gives a phenomenal performance, and the film is filled with clever details and symbolism that reward a close look. It’s a smart, socially relevant horror film that has forever changed the genre.", "Get Out", (sbyte)5 },
                    { 15, "A beautifully crafted and bittersweet musical. Damien Chazelle's film is a modern take on the classic Hollywood musical, filled with vibrant colors, stunning choreography, and memorable songs. It tells a heartfelt and melancholic story about two artists chasing their dreams in Los Angeles and the difficult choices they have to make for love and career. Ryan Gosling and Emma Stone have incredible chemistry, and their performances are both charming and deeply moving. The film is a love letter to dreamers and to the city of L.A., with a poignant, unforgettable ending that captures the bittersweet reality of life and ambition.", "La La Land", (sbyte)4 },
                    { 16, "Decent action, but uneven tone. Carried by Tom Hardy.", "Venom", (sbyte)3 },
                    { 17, "Some good visuals, but overcrowded plot and wasted villains.", "The Amazing Spider-Man 2", (sbyte)3 },
                    { 18, "Charming moments, but franchise fatigue shows.", "Pirates of the Caribbean: On Stranger Tides", (sbyte)3 },
                    { 19, "A chaotic and tonally inconsistent superhero film that struggles to find its identity. While it features a fun, charismatic cast, particularly Margot Robbie as Harley Quinn, the movie is let down by a weak villain and a disjointed narrative. The reshoots and studio interference are evident, resulting in a confusing story that jumps from scene to scene without a clear flow. The promise of an edgy, R-rated anti-hero film was replaced with a generic, sanitized action movie. It has some flashy moments and a great soundtrack, but ultimately feels like a wasted opportunity to explore a darker side of the DC universe.", "Suicide Squad", (sbyte)2 },
                    { 20, "A prime example of a film plagued by production issues. This version of the DC superhero team-up is a messy, disjointed narrative with a rushed plot and inconsistent tone. The reshoots and change in directors created a patchwork movie that feels like two different films stitched together. The CGI is famously poor, especially with the villain, Steppenwolf, and the visual effects on Henry Cavill's face. While there are some enjoyable character interactions, the film is a huge disappointment, failing to deliver the epic scale and emotional weight it promised. A truly forgettable and unsatisfying blockbuster.", "Justice League (2017)", (sbyte)2 },
                    { 21, "A visually bombastic but narratively empty fantasy film. Despite its grand scale and impressive special effects, the movie is weighed down by a clichéd story, wooden dialogue, and baffling casting choices. The characters are one-dimensional, and the plot, revolving around a mortal thief and a banished god, is predictable from the start. The film is a spectacle without substance, prioritizing CGI-heavy action sequences over compelling storytelling or character development. It’s a mindless and often goofy action movie that fails to capture the grandeur of its ancient Egyptian setting, making it a forgettable and disappointing watch.", "Gods of Egypt", (sbyte)2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
