using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core_Blog.Controllers
{

    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = _blogManager.GetBlogListWithCategory();
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            var values = _blogManager.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = _blogManager.GetListWithCategoryByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {           
            List<SelectListItem> categoryvalue = (from x in cm.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.cv=categoryvalue;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            BlogValidator bv= new BlogValidator();
            ValidationResult results=bv.Validate(blog);
            List<SelectListItem> categoryvalue = (from x in cm.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerID;
                _blogManager.TInsert(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue=_blogManager.TGetByID(id);
            _blogManager.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue=_blogManager.TGetByID(id);
            List<SelectListItem> categoryvalue = (from x in cm.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            blog.WriterID = writerID;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            _blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
