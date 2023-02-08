namespace MS.Personal.Api.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteCliente
        {
            // Read
            public const string GetAll = Base + "/personal/all";
            public const string GetById = Base + "/personal/{id}";

            // Write
            public const string Create = Base + "/personal/create";
            public const string Update = Base + "/personal/update";
            public const string Delete = Base + "/personal/delete";

        }
    }
}
