namespace CoffeeApplication.Interfaces
{
    public interface ICoffeeApplicationStoreDatabaseSetting
    {
        string ContactCollectionName { get; set; }
        string OrderCollectionName { get; set; }
        string OrderItemCollectionName { get; set; }
        string PaymentCollectionName { get; set; }
        string PointsSettingsCollectionName { get; set; }
        string ProductCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
