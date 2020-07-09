using System.Collections.Generic;
using URF.Core.EF.Trackable;

namespace CodePepperInterview.DAL.Models
{
    public class Character : Entity

    {
        public Character()
        {
            CharacterFriendRelatedCharacter = new HashSet<CharacterFriend>();
            CharacterFriendRelatingCharacter = new HashSet<CharacterFriend>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Planet { get; set; }

        public virtual ICollection<CharacterFriend> CharacterFriendRelatedCharacter { get; set; }
        public virtual ICollection<CharacterFriend> CharacterFriendRelatingCharacter { get; set; }
    }
}