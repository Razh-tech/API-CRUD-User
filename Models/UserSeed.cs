namespace API_CRUD_User.Models
{
    public static class UserSeed
    {
        public static void InitData(UserContext context)
        {
            var fullName = new[] { "Adi", "Beni", "Cirilla", "Dane", "Elena" };
            var address = new[] { "Jakarta, Indonesia", "Surabaya, Indonesia", "Liverpool, UK", "Cairo, Egypt", "Virginia, US" };
            var birthDate = new[] { "22-03-93", "30-04-89", "12-07-99", "03-01-92", "01-04-90" };
            var sex = new[] { "M", "M", "F", "M", "F" };
            var photo = new[] { "adi.png", "beni.png", "cirilla.png", "dane.png", "elena.png" };

            context.SaveChanges();
        }
    }
}
