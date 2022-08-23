namespace GeekBurguer.Users.Contracts.Commands.Output
{
    public class OutputUserFaceCommand
    {
        public bool Processing { get; set; }
        public Guid UserId { get; set; }
    }
}
