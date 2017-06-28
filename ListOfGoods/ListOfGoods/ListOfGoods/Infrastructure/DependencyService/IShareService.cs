namespace ListOfGoods.Infrastructure.DependencyService
{
    public interface IShareService
    {
        void Share(string title, string description, string url = "");
    }
}
