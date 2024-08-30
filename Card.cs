using System.Text.Json;


namespace Mojo_The_Summoning_C_;


public class Card{

    public int Id { get; set; }
    public required string Name { get; set; }
    public int Mojo { get; set; }
    public int Stamia { get; set; }
    public required string ImgUrl { get; set; }

    private static readonly JsonSerializerOptions options = new() {
        WriteIndented = true
    };

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, options);
    }
};
