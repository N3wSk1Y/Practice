namespace duel;

class Card
{
    private string name;
    private CardType type;
    private int life;
    private int protection;
    private int attack;

    public Card()
    {
        this.name = "Задохлик";
        this.type = CardType.Mob;
        this.life = 0;
        this.protection = 0;
        this.attack = 0;
    }

    public Card(string name, CardType type, int life, int protection, int attack)
    {
        this.name = name;
        this.type = type;
        this.life = life;
        this.protection = protection;
        this.attack = attack;
    }

    public string Name
    {
        get { return this.name; }
    }
    public CardType Type
    {
        get { return this.type; }
    }
    public int Life
    {
        get { return this.life; }
    }
    public int Protection
    {
        get { return this.protection; }
    }
    public int Attack
    {
        get { return this.attack; }
    }
}
