namespace Prototype;

#region Prototypes

// Prototype
public abstract class Tile {
    public string Color { get; protected set; }
    abstract public Tile Clone();
}

// Concrete prototype 1
public class RoadTile : Tile {
    public RoadTile() {
        Color = "gray";
    }

    private RoadTile(RoadTile tile) {
        Color = tile.Color;
    }

    public override Tile Clone()
    {
        return new RoadTile(this);
    }

    public override string ToString() {
        return "Road";
    }
}

// Concrete prototype 2
public class GrassTile : Tile {
    public int GrassHeight { get; set; }
    
    public GrassTile() {
        Color = "green";
        GrassHeight = 1;
    }

    private GrassTile(GrassTile tile) {
        Color = tile.Color;
        GrassHeight = tile.GrassHeight;
    }

    public override Tile Clone()
    {
        return new GrassTile(this);
    }

    public override string ToString() {
        return $"Grass({GrassHeight})";
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
        Tile prototype;

        var tiles = new List<Tile>();

        prototype = new RoadTile();
        tiles.Add(prototype.Clone());
        tiles.Add(prototype.Clone());

        prototype = new GrassTile();
        tiles.Add(prototype.Clone());

        foreach (var tile in tiles)
            Console.WriteLine(tile);
    }
}
