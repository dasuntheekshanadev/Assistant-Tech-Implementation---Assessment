using CustomIdentity.Models;
using CustomIdentity.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentity.Controllers;


public class MaterialController : Controller
{
    private IMaterialService MaterialService;

    public MaterialController(IMaterialService MaterialService)
    {
        this.MaterialService = MaterialService;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddMaterialViewModel viewModel)
    {
        if (ModelState.IsValid) {

            var Material = new Material
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                UnitPrice = viewModel.UnitPrice,
                Quantity = viewModel.Quantity,
                Supplier = viewModel.Supplier
            };

            var result = await MaterialService.Save(Material);
            return RedirectToAction("List", "Material");
          


        }
        else
        {
            return View();
        }

    }


    [HttpGet]

    public async Task<IActionResult> List()
    {
        var Materials = await MaterialService.GetAll();
        return View(Materials);
    }

    [HttpGet]

    public async Task<IActionResult> Edit(int id)
    {
        

        var Materials = await MaterialService.GetById(id);
        return View(Materials);
    }

    [HttpPost]

    public async Task<IActionResult> Edit(Material viewModel)
    {
        if (ModelState.IsValid)
        {
var results = await MaterialService.Update(viewModel.Id,viewModel);
        }
            
        return RedirectToAction("List", "Material");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Material viewModel)
    {
        var results = await MaterialService.DeleteById(viewModel.Id);
        
        return RedirectToAction("List", "Material");
    }

}

