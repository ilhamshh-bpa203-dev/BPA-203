namespace _35_ServiceLifeTimeAppSettingProduct.Services.Interface
{
    public interface ILayoutService
    {
       Task<Dictionary<string, string>> GetSettingAsync();

    }
}
