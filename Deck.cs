using System.Text.Json;
namespace Mojo_The_Summoning_C_;

class Deck{

    
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Xp { get; set; }


    private static readonly JsonSerializerOptions options = new() {
        WriteIndented = true
    };

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, options);
    }
    

};