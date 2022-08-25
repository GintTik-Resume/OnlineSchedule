namespace OnlineSchedule.BusinessLogic.Authenticate
{
    public class AuthenticateResult
    {
        public bool Successfully => Errors == null;
        public List<string> Errors { get; set; }

        public AuthenticateResult()
        {
            Errors = null;
        }

        public AuthenticateResult(List<string> errors)
        {
            Errors = errors;
        }

        public AuthenticateResult(string error)
        {
            Errors = new();
            Errors.Add(error);
        }
    }
}
