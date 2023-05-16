namespace duel;

class Game
{
    private Card[] pack;
    private static Random rnd = new Random();
    private Player player1;
    private Player player2;
    private string duelResult;

    public Game()
    {
        this.createPack();
        this.shuffle();

        this.player1 = new Player();
        this.player2 = new Player();
        this.HandOutCards();
    }

    private void createPack()
    {
        this.pack = new Card[16];
        StreamReader s = new StreamReader("/Users/n3wsk1y/Desktop/cards.txt");
        string[] data;
        for (int i = 0; i < this.pack.Length; i++)
        {
            data = s.ReadLine().Split(',');
            this.pack[i] = new Card(
                data[1],
                (CardType)int.Parse(data[0]),
                int.Parse(data[2]),
                int.Parse(data[3]),
                int.Parse(data[4])
            );
        }
    }

    private void shuffle()
    {
        Card temp;
        int j;
        for (int i = 0; i < this.pack.Length; i++)
        {
            j = rnd.Next(0, i + 1);
            temp = this.pack[j];
            pack[j] = pack[i];
            pack[i] = temp;
        }
    }

    private void HandOutCards()
    {
        int cardIndex = 0;
        while (this.player1.CardsNumber < 6 || this.player2.CardsNumber < 6)
        {
            if (
                (this.pack[cardIndex].Type != CardType.Mob || !this.player1.HasCharacter)
                && this.player1.CardsNumber < 6
            )
                this.player1.addCard(this.pack[cardIndex]);
            cardIndex++;
            if (
                (this.pack[cardIndex].Type != CardType.Mob || !this.player2.HasCharacter)
                && this.player2.CardsNumber < 6
            )
                this.player2.addCard(this.pack[cardIndex]);
            cardIndex++;
        }
    }

    public void createSoldiers(int[] cardIndexes1, int[] cardIndexes2)
    {
        try
        {
            this.player1.createSoldier(cardIndexes1);
            this.player2.createSoldier(cardIndexes2);
        }
        catch
        {
            throw new Exception("Неверные номера карт");
        }
    }

    public void duel()
    {
        int result;
        int attacker = rnd.Next(2);
        string res = "";
        res += $"Атакует {attacker + 1} игрок\n";
        if (attacker == 0)
            result = Player.fight(this.player1, this.player2);
        else
            result = Player.fight(this.player2, this.player1);

        if (result == 0)
            res += "Ничья";
        else if (result == 1 && attacker == 0 || result == 2 && attacker == 1)
            res += "Победил 1 игрок";
        else
            res += "Победил 2 игрок";
        this.duelResult = res;
    }

    public string Pack1
    {
        get { return this.player1.Pack; }
    }
    public string Pack2
    {
        get { return this.player2.Pack; }
    }
    public string Soldier1
    {
        get { return this.player1.soldier.Output; }
    }
    public string Soldier2
    {
        get { return this.player2.soldier.Output; }
    }
    public string Result
    {
        get { return this.duelResult; }
    }
}
