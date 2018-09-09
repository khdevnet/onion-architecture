namespace OA.Web.Extensibility
{
    public interface ICurrentUserProvider
    {
        string GetCartId();

        string GetUserId();
    }
}
