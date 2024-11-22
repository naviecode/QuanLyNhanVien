namespace BusinessLogic.IService.IUserService.Dto
{
    public class UserChangePassDto
    {
        public int Id { get; set; }
        public string PassNew { get; set; }
        public string PassOld { get; set; }
    }
}
