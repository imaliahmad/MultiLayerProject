using BLL_BusinessLogicLayer_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_UserInterface_.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBs objProductBs;
        public ProductController(IProductBs _objProductBs)
        {
            objProductBs = _objProductBs;
        }
        public IActionResult Index()
        {
            var list = objProductBs.GetAll();
            return View(list);
        }
    }
}
