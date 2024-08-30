using System.Text.Json;
namespace Mojo_The_Summoning_C_;

class User {


    public int Id { get; set; }
    public required string Username { get; set; }


    private static readonly JsonSerializerOptions options = new() {
        WriteIndented = true
    };

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, options);
    }
    
}