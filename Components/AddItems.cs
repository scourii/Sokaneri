using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Sakuri.Shared;
using Microsoft.AspNetCore.Components;  
namespace Sakuri.Components
{
    public partial class AddItems : ComponentBase
    {
        public Item Item {  
            get;  
            set;  
        } = new Item {};   
        
        public bool ShowDialog {  
            get;  
            set;  
        }  
        [Parameter]  
        public EventCallback < bool > CloseEventCallback {  
            get;  
            set;  
        }  
        public void Show() {  
            ResetDialog();  
            ShowDialog = true;  
            StateHasChanged();  
        }  
        public void Close() {  
            ShowDialog = false;  
            StateHasChanged();  
        }  
        private void ResetDialog() {  
            Item = new Item {};  
        }  
        protected async Task HandleValidSubmit() {  
             
            ShowDialog = false;  
            await CloseEventCallback.InvokeAsync(true);  
            StateHasChanged();  
        }  
    }  
}
