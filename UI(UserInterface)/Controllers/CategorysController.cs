using BLL_BusinessLogicLayer_;
using BOL_BusinessObjectLayer_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_UserInterface_.Controllers
{
    [Authorize(Roles ="Manager")]
    public class CategorysController : Controller
    {
        private readonly ICategoryBs objCategoryBs;
        public CategorysController(ICategoryBs _objCategoryBs)
        {
            objCategoryBs = _objCategoryBs;
        }
        public IActionResult Index()
        {
            var list = objCategoryBs.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            Categorys obj = new Categorys();
            if (id > 0)
            {
                obj = objCategoryBs.GetById(id);
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult CreateOrEdit(Categorys model)
        {
            if (model.CategoryId > 0) //udpate
            {
              objCategoryBs.Update(model);
            }
            else //insert
            {
                objCategoryBs.Insert(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
