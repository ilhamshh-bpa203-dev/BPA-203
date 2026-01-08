using _34_Front_To_BackSqlConnection.DAL;
using _35_ServiceLifeTimeAppSettingProduct.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace _35_ServiceLifeTimeAppSettingProduct.Services.Implementation
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDBContext _context;

        public LayoutService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string, string>> GetSettingAsync()
        {
            Dictionary<string,string> settings = await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);
            return settings;
        }
    }
}
