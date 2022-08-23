namespace GeekBurguer.Users.Contracts.Commands.Input
{
    public class InputUserFoodRestrictionsCommand
    {
        public List<string> Restrictions { get; set; }
        public string Others { get; set; }
        public Guid UserId { get; set; }
        public Guid RequesterId { get; set; }

    }
}
