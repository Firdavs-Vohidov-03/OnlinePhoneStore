namespace Web.API;

public static class ApiEndpoints
{
    public static class Customer
    
    {
        private const string Base = $"{ApiBase}/Customer";
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
    private const string ApiBase = "api";

public static class Product
    
{
    private const string Base = $"{ApiBase}/Product";
    public const string Create = Base;
    public const string Get = $"{Base}/{{id:guid}}";
    public const string GetAll = Base;
    public const string Update = $"{Base}/{{id:guid}}";
    public const string Delete = $"{Base}/{{id:guid}}";
}
    public static class Order

    {
        private const string Base = $"{ApiBase}/Order";
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
}