using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
      [HttpGet("/categories/{categoryId}/items/new")]
       public ActionResult CreateForm(int categoryId)
       {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Category category = Category.Find(categoryId);
          return View(category);
       }
        // [HttpGet("/items")]
        // public ActionResult Index()
        // {
        //     List<Item> allItems = Item.GetAll();
        //     return View(allItems);
        // }
        [HttpGet("/categories/{categoryId}/items/{itemId}")]
       public ActionResult Details(int categoryId, int itemId)
       {
          Item item = Item.Find(itemId);
          Dictionary<string, object> model = new Dictionary<string, object>();
          Category category = Category.Find(categoryId);
          model.Add("item", item);
          model.Add("category", category);
          return View(item);
       }
        // [HttpGet("/items/new")]
        // public ActionResult CreateForm()
        // {
        //     return View();
        // }

        // [HttpPost("/items")]
        // public ActionResult Create()
        // {
        //     Item newItem = new Item(Request.Form["new-item"]);
        //     List<Item> allItems = Item.GetAll();
        //     return View("Index", allItems);
        // }
        // [HttpGet("/items/{id}")]
        // public ActionResult Details(int id)
        // {
        //   Item item = Item.Find(id);
        //   return View(item);
        // }
    }
}
