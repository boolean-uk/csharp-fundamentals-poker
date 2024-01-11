using exercise.main.Objects;

Console.WriteLine("Write two names to begin playing Poker");
Pokergame pokergame = new Pokergame(Console.ReadLine(),Console.ReadLine());

Console.WriteLine("First player: " + pokergame.player1.Name);
Console.WriteLine("Second player: "+pokergame.player2.Name);
bool gameContinues = true;
pokergame.Start();

while (gameContinues)
{
    Console.WriteLine(pokergame.player1.Name + "'s hand:");

    pokergame.player1.GetHand().ForEach(x => Console.WriteLine(x.GetCard()));

    Console.WriteLine(pokergame.player2.Name + "'s hand:");
    pokergame.player2.GetHand().ForEach(x => Console.WriteLine(x.GetCard()));
    Checkwin();
    Console.WriteLine();
    pokergame.Deal();
}


void Checkwin()
{
    if(pokergame.checkWin(pokergame.player1)) { Console.WriteLine(pokergame.player1.Name + " Won "); gameContinues = false; }
    if (pokergame.checkWin(pokergame.player2)) { Console.WriteLine(pokergame.player2.Name + " Won "); gameContinues = false; }


}