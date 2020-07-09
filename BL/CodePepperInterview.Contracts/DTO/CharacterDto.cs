using System.Collections.Generic;

namespace CodePepperInterview.Contracts.DTO
{
    public class CharacterBaseDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string planet { get; set; }
    }

    public class CharacterItemDto : CharacterBaseDto
    {
        public IEnumerable<string> friends { get; set; } = new List<string>();
    }
}