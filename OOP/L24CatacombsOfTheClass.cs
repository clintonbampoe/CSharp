class L24CatacombsOfTheClass 
{
    public static void Run () 
    {
        
        foreach(CardColor color in Enum.GetValues(typeof(CardColor)))
        {
            foreach(CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                Card newCard = new(color, rank);
                Console.WriteLine($"The {color} {rank}");
            }
        }
    } 
}


// class1: POINT
class Point {
    public int XCoordinate { get; private set; }
    public int YCoordinate { get; private set; }


    // Constructors
    public Point(int xCoordinate, int yCoordinate) {
        XCoordinate = xCoordinate;
        YCoordinate = yCoordinate;
    }

    public Point() {
        XCoordinate = 0;
        YCoordinate = 0;
    }
}



// class2: COLOR
class Color {

    // PROPERTIES
    public int R { get; private set; }
    public int G { get; private set; }
    public int B { get; private set; }


    // CONSTRUCTOR
    public Color(int red, int green, int blue) {
        R = red;
        G = green;
        B = blue;
    }

    // FACTORY COLORS
    public static Color White() {
        return new Color(255, 255, 255);
    }

    public static Color Black() {
        return new Color(0, 0, 0);
    }

    public static Color Red() {
        return new Color(255, 0, 0);
    }

    public static Color Orange() {
        return new Color(255, 165, 0);
    }

    public static Color Yellow() {
        return new Color(255, 255, 0);
    }

    public static Color Green() {
        return new Color(0, 128, 0);
    }

    public static Color Blue() {
        return new Color(0, 0, 255);
    }

    public static Color Purple() {
        return new Color(128, 0, 128);
    }
}


// class3: THE CARD
class Card 
{

    public CardColor Color { get; }
    public CardRank Rank { get; }

    // checks if card is a number or symbol card
    public bool IsNumberCard => Rank >= CardRank.One && Rank <= CardRank.Ten;
    public bool IsSymbolCard => !IsNumberCard;


    // Constructor
    public Card(CardColor cardColor, CardRank cardRank) 
    {
        Color = cardColor;
        Rank = cardRank;
    }

}

    public enum CardColor { Red, Green, Blue, Yellow }
    public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand }
    public enum CardType { Number, Symbol }
