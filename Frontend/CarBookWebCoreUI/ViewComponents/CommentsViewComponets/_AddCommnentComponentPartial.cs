using CarBook_Ayt_Dto.CommentDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBookWebCoreUI.ViewComponents.CommentsViewComponets
{
    public class _AddCommnentComponentPartial:ViewComponent
    {
       

        public IViewComponentResult Invoke()
        {
            return View();
        }
      
    }
}
