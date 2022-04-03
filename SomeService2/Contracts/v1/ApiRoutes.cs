
namespace SomeService2.Contracts.v1;

public class ApiRoutes
{
    private const string Root = "api";

    private const string Version = "v1";

    private const string Base = "/" + Root + "/" + Version;

    public const string Admin = Base + "/admin";

    public const string Users = Base + "/users";

    public const string Organizations = Base + "/organizations";

    public static class UserApi
    {
        public const string ByOrganizationId = Organizations + "/{organizationId:int:min(1)}/users";
    }
}