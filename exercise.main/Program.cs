using exercise.main.Objects;

Console.WriteLine("Write two names to begin playing Poker");
Pokergame pokergame = new Pokergame(Console.ReadLine(),Console.ReadLine());
Console.Clear();

pokergame.Start();

while (pokergame.gameContinues)
{
    Console.WriteLine(pokergame.player1.Name + "'s hand:");
    pokergame.player1.GetHand().ForEach(x => Console.WriteLine(x.GetCard()));
    Console.WriteLine("");


    Console.WriteLine(pokergame.player2.Name + "'s hand:");
    pokergame.player2.GetHand().ForEach(x => Console.WriteLine(x.GetCard()));
    Console.WriteLine("");


    Console.WriteLine("Table: ");
    pokergame.table.ForEach(x => Console.WriteLine(x.GetCard()));
    Console.WriteLine("");

    pokergame.Checkwin();
    pokergame.DealTable(1);
    Console.ReadLine();
    Console.Clear();

}
