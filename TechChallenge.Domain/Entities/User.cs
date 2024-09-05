using TechChallengeGestaoInvestimentos.Domain.Common;

namespace TechChallengeGestaoInvestimentos.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
