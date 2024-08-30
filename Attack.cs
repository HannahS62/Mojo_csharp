using System.Text.Json;
namespace Mojo_The_Summoning_C_;

class Attack{
    
    public int Id { get; set; }
    public required string Title { get; set; }
    public int MojoCost { get; set; }
    public int StaminaCost { get; set; }


    private static readonly JsonSerializerOptions options = new() {
        WriteIndented = true
    };

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, options);
    }
    
};