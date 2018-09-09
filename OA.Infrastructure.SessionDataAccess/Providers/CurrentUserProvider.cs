using OA.Web.Extensibility;
using System;
using System.Web;
using System.Web.SessionState;

namespace OA.Infrastructure.SessionDataAccess.Providers
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private const string CartSessionKey = "CartKey";

        private HttpSessionState storage = HttpContext.Current.Session;

        public string GetCartId()
        {
            if (storage[CartSessionKey] == null)
            {
                storage[CartSessionKey] = Guid.NewGuid().ToString();
            }

            return storage[CartSessionKey].ToString();
        }

        public string GetUserId() => GetCartId();
    }
}
