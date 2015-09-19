using System.Web;


namespace EconomyReloaded.Services.Services.User
{
  public class UserIdSessionService
  {
    private const string UserIdSessionKey = "UserIdSessionKey";

    public static string UserId
    {
      get
      {
        if (HttpContext.Current == null || HttpContext.Current.Session == null)
          return string.Empty;
        return HttpContext.Current.Session[UserIdSessionKey] == null ? string.Empty : HttpContext.Current.Session[UserIdSessionKey].ToString();
      }
    }

    public static void SaveUserIdInSession(int userId)
    {
      if (HttpContext.Current == null)
        return;
      if (HttpContext.Current.Session == null)
        return;
      HttpContext.Current.Session[UserIdSessionKey] = userId;
    }
  }
}
