using _35_ServiceLifeTimeAppSettingProduct.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class FooterViewComponent : ViewComponent
{
    private readonly ILayoutService _layoutService;

    public FooterViewComponent(ILayoutService layoutService)
    {
        _layoutService = layoutService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var settings = await _layoutService.GetSettingAsync();
        return View(settings);
    }
}