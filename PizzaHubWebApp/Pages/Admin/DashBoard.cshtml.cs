﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaHubWebApp.DAO;
using PizzaHubWebApp.Models;

namespace PizzaHubWebApp.Pages.Admin
{
    public class DashBoard : PageModel
    {
        private readonly PizzaDao _pizzaDao;
        private readonly CategoryDao _categoryDao;
        private readonly MemberDao _memberDao;
        private readonly DrinkDao _drinkDao;

        public DashBoard(PizzaHubContext context)
        {
            _pizzaDao = new PizzaDao(context);
            _categoryDao = new CategoryDao(context);
            _drinkDao = new DrinkDao(context);
            _memberDao = new MemberDao(context);
        }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Pizza> Pizzas { get; set; }

        public void OnGet()
        {
            Categories = _categoryDao.GetCategories();
            Pizzas = _pizzaDao.GetPizzaList();
        }
    }
}