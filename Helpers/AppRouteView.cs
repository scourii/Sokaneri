using System;
using System.Net;
using Sakuri.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Sakuri.Helpers
{
    public class AppRouteView : RouteView
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AccountService AccountService { get; set; }
        
        protected override void Render(RenderTreeBuilder renderTreeBuilder)
        {
            var authorization = Attribute.GetCustomAttribute(RouteData.PageType, typeof(Authorization)) != null;
            if (authorization && AccountService.User != null)
            {
                var returnUrl = WebUtility.UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery);
                NavigationManager.NavigateTo($"account/login?returnUrl={returnUrl}");
            }
            else
            {
                base.Render(renderTreeBuilder);
            }
        }
    }
}

