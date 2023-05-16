namespace duel;

struct Soldier
{
    private Card character;
    private Card[] amunition;
    private int life;
    private int protection;
    private int attack;

    public Soldier(Card character, Card[] amunition)
    {
        this.character = character;
        this.amunition = amunition;

        this.life = character.Life;
        this.protection = character.Protection;
        this.attack = character.Attack;

        foreach (Card item in amunition)
        {
            this.life += item.Life;
            this.protection += item.Protection;
            this.attack += item.Attack;
        }
    }

    public string Output
    {
        get
        {
            string res;
            if (this.amunition.Length == 2)
                res =
                    $"{this.Name} имеет {this.amunition[0].Name}, {this.amunition[1].Name}: жизнь = {this.Life} защита = {this.Protection} атака = {this.Attack}\n";
            else
                res =
                    $"{this.Name} имеет {this.amunition[0].Name}, {this.amunition[1].Name}, {this.amunition[2].Name}: жизнь = {this.Life} защита = {this.Protection} атака = {this.Attack}\n";
            return res;
        }
    }

    public string Name
    {
        get { return this.character.Name; }
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
