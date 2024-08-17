namespace Facade;

// TODO? make more complex

public class Room {
    public bool LightsOn { get; set; } = false;
}

// Facade
public class House {
    public List<Room> _rooms = [];

    public void ToggleLights(bool lightsOn) {
        foreach (var room in _rooms)
            room.LightsOn = lightsOn;
    }
}


public class Program {

    public static void Main(string[] args) {
        var house = new House();

        // turn on the lights
        house.ToggleLights(true);
    }
}
