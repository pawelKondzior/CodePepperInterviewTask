using URF.Core.EF.Trackable;

namespace CodePepperInterview.DAL.Models
{
    public partial class CharacterFriend : Entity
    {
        public CharacterFriend()
        {
        }

        public CharacterFriend(int relatingCharacterId, int relatedCharacterId)
        {
            RelatingCharacterId = relatingCharacterId;
            RelatedCharacterId = relatedCharacterId;
        }

        public int RelatingCharacterId { get; set; }
        public int RelatedCharacterId { get; set; }

        public virtual Character RelatedCharacter { get; set; }
        public virtual Character RelatingCharacter { get; set; }
    }
}