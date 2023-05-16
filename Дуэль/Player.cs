namespace duel;

class Player
{
    private Card[] pack;
    public Soldier soldier;
    private bool hasCharacter;

    public Player()
    {
        this.pack = new Card[1];
        this.pack[0] = new Card();
        this.hasCharacter = false;
    }

    public void addCard(Card card)
    {
        if (card.Type == CardType.Mob)
            this.hasCharacter = true;
        Card[] newPack = new Card[this.pack.Length + 1];
        for (int i = 0; i < this.pack.Length; i++)
            newPack[i] = this.pack[i];
        newPack[this.pack.Length] = card;
        this.pack = newPack;
    }

    public void deleteCard(int cardIndex)
    {
        Card[] newPack = new Card[this.pack.Length - 1];
        for (int i = 0; i < cardIndex; i++)
            newPack[i] = this.pack[i];
        for (int i = cardIndex + 1; i < this.pack.Length; i++)
            newPack[i - 1] = this.pack[i];
        this.pack = newPack;
    }

    public void createSoldier(int[] cardIndexes)
    {
        Card character = pack[0];
        Card[] amunition;
        int amunitionLength = 3;
        foreach (int xm in cardIndexes)
            if (this.pack[xm].Type == CardType.Mob)
            {
                character = this.pack[xm];
                amunitionLength = 2;
                break;
            }
        amunition = new Card[amunitionLength];
        int amunitionIndex = 0;
        for (int i = 0; i < cardIndexes.Length; i++)
            if (this.pack[cardIndexes[i]].Type == CardType.Item)
            {
                amunition[amunitionIndex] = this.pack[cardIndexes[i]];
                amunitionIndex++;
            }
        this.soldier = new Soldier(character, amunition);
    }

    public static int fight(Player attacker, Player defender)
    {
        if (attacker.soldier.Attack > attacker.soldier.Life + attacker.soldier.Protection)
            return 1;
        else if (attacker.soldier.Attack < attacker.soldier.Life + attacker.soldier.Protection)
            return 2;
        else
            return 0;
    }

    public bool HasCharacter
    {
        get { return this.hasCharacter; }
    }
    public int CardsNumber
    {
        get { return this.pack.Length; }
    }
    public string Pack
    {
        get
        {
            string res = "";
            for (int i = 1; i < this.pack.Length; i++) // Задохлик не в счёт
                res +=
                    $"{i}) {this.pack[i].Type} {this.pack[i].Name} жизнь = {this.pack[i].Life} защита = {this.pack[i].Protection} атака = {this.pack[i].Attack}\n";
            return res;
        }
    }
}
