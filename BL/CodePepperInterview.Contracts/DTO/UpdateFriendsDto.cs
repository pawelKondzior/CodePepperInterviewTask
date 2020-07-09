using System;
using System.Collections.Generic;
using System.Text;

namespace CodePepperInterview.Contracts.DTO
{
    public class UpdateFriendsDto
    {
        public IEnumerable<int> Friends { get; set; } = new List<int>();
    }
}