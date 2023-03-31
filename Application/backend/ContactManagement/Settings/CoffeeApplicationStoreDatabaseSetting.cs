using CoffeeApplication.Interfaces;

namespace CoffeeApplication.Settings
{
    public class CoffeeApplicationStoreDatabaseSetting : ICoffeeApplicationStoreDatabaseSetting
    {
        public string ContactCollectionName { get; set; } = string.Empty;
        public string OrderCollectionName { get; set; } = string.Empty;
        public string OrderItemCollectionName { get; set; } = string.Empty;
        public string PaymentCollectionName { get; set; } = string.Empty;
        public string PointsSettingsCollectionName { get; set; } = string.Empty;
        public string ProductCollectionName { get; set; } = string.Empty;
        public string UserCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
