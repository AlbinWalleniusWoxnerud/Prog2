// using System;
// using System.Threading;
// using ProgramLibrary;
// using Battles;
// using Text;

// namespace Rooms
// {
//     class Room_2
//     {
//         public static void Dialog1()
//         {
//             TextRender.Render("You explore the path and end up in another dark room, this time with a marking.");
//             TextRender.Render("");
//             TextRender.Render("Room 2", color: Text.Color.White);
//             TextRender.Render("");
//             TextRender.Render("You hear some noises coming from a corner and decide to check it out.");
//             TextRender.Render("...", delay: 200);
//             TextRender.Render("...", delay: 200);
//             TextRender.Render("...", delay: 200);
//             TextRender.Render("When the ", sameLine: true);
//             TextRender.Render("light", sameLine: true, color: Text.Color.Yellow);
//             TextRender.Render(" of the torch reaches the noise you see an ugly little creature, a ", sameLine: true);
//             TextRender.Render("Goblin", sameLine: true, color: Text.Color.Green);
//             TextRender.Render(".");
//         }
//         public static void Dialog2()
//         {
//             TextRender.Render("After killing the ", sameLine: true);
//             TextRender.Render("Goblin", sameLine: true, color: Text.Color.Green);
//             TextRender.Render(" you explore the rest of the room and find: ", sameLine: true);
//             TextRender.Render("2 paths", sameLine: true, color: Text.Color.White);
//             TextRender.Render(" and a ", sameLine: true);
//             TextRender.Render("note", sameLine: true, color: Text.Color.White);
//             TextRender.Render(".");
//             TextRender.Render("The note reads: 'Key very hidden is.'");
//             TextRender.Render("...", delay: 200);
//             TextRender.Render("...", delay: 200);
//             TextRender.Render("...", delay: 200);
//             TextRender.Render("(ﾉಥ益ಥ)ﾉ");
//             TextRender.Render("You decide to check the paths out.");
//         }

//         //Room 2 with all of its interactions
//         public static void Room(Player player)
//         {
//             if (!StaticRoom.room2.clear1)
//             {
//                 //Usual dialog with skip
//                 Dialog1();

//                 int playerChoice1 = TextRender.Table(header: "Do you: ", alternatives: "Fight it.. Retreat to the starting room".Split(". "));

//                 //If player choose so return to starting room
//                 if (playerChoice1 == 2)
//                 {
//                     TextRender.Render("");
//                     TextRender.Render("You choose to retreat.");
//                     CurrentRun.currentRoom = 1;
//                     return;
//                 }

//                 Goblin goblin = new Goblin(20, 10, 5, 0.95, 5);

//                 //If battle returns true player won, if it returns false player lost and it is game over
//                 if (!Battles.CBattle.Battle(player, goblin))
//                 {
//                     return;
//                 }

//                 Dialog2();


//                 StaticRoom.room2.clear1 = true;
//             }

//             if (StaticRoom.room2.specialInteraction)
//             {
//                 TextRender.Render("");
//                 TextRender.Render("You return to the room marked: ", sameLine: true);
//                 TextRender.Render("Room 2", color: Text.Color.White);
//             }
//             int playerChoice2 = TextRender.Table(header: "Do you: ", alternatives: "Go to the path straight forward.. Go to the path to the left forward.. Return to the starting room.".Split(". "));

//             switch (playerChoice2)
//             {
//                 case 1:
//                     TextRender.Render("");
//                     TextRender.Render("You choose to go to the path straight forward.");
//                     StaticRoom.room2.specialInteraction = true;
//                     CurrentRun.currentRoom = 7;
//                     return;
//                 case 2:
//                     TextRender.Render("You choose to go to the path to the left forward.");
//                     CurrentRun.currentRoom = 3;
//                     StaticRoom.room2.specialInteraction = true;
//                     return;
//                 case 3:
//                     TextRender.Render("You choose to return to the starting room.");
//                     CurrentRun.currentRoom = 1;
//                     StaticRoom.room2.specialInteraction = true;
//                     return;
//             }
//         }
//     }
// }