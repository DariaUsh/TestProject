using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestTask.Models;
using System.Data.Entity;

namespace TestTask.Controllers
{
    public class ProductsController : ApiController 
    {
        DataBaseContext db = new DataBaseContext();
        IQueryable<Products> query;
        int pageSize = 30;


        public IEnumerable<Products> GetProducts(int page)
        {
            Query(page);
            return query.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
        }

        public IEnumerable<Products> GetProducts(string sort)
        {
            Query();
            Sorted(sort);
            return query.Take(pageSize).ToList();
        }

        public IEnumerable<Products> GetProducts(int page, string sort, string nameProduct, string nameMarker, 
            double priceFrom, double priceTo)
        {
            Query(page);

            Filter(nameProduct, nameMarker, priceFrom, priceTo);

            if (!String.IsNullOrEmpty(sort))
            {
                Sorted(sort);
            }

            return query.Skip(pageSize * (page - 1)).Take(pageSize).ToList();         
        }

        public void Query(int page = 1)
        {
            var totalCount = db.ProductsList.Count();
            var totalPages = (int)Math.Round((double)totalCount / pageSize);

            var paginationHeader = new
            {
                TotalPages = totalPages,
                CurrentPage = page
            };

            System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination",
            Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

            query = db.ProductsList.OrderBy(p=>p.Name).Include(p=>p.Marker);
        }

        public void Filter(string nameProduct, string nameMarker, double priceFrom, double priceTo)
        {
            if (nameProduct != "\"\"")
            {
                query = query.Where(p => p.Name.ToLower().Contains(nameProduct.ToLower()));
            }
            if (nameMarker != "\"\"")
            {
                query = query.Where(p => p.Marker.Name.ToLower().Contains(nameMarker.ToLower()));
            }
            if (priceFrom>0)
            {
                query = query.Where(p => p.Price >= priceFrom);
            }
            if (priceTo > 0 & priceTo > priceFrom)
            {
                query = query.Where(p => p.Price <= priceTo);
            }
        }

        public void Sorted(string sort)
        {
            switch (sort)
            {
                case "name DESC":
                    {
                        query = query.OrderByDescending(p => p.Name);
                        break;
                    }
                case "marker ASC":
                    {
                        query = query.OrderBy(p => p.Marker.Name);
                        break;
                    }
                case "marker DESC":
                    {
                        query = query.OrderByDescending(p => p.Marker.Name);
                        break;
                    }
                case "category ASC":
                    {
                        query = query.OrderBy(p => p.Category);
                        break;
                    }
                case "category DESC":
                    {
                        query = query.OrderByDescending(p => p.Category);
                        break;
                    }
                case "price ASC":
                    {
                        query = query.OrderBy(p => p.Price);
                        break;
                    }
                case "price DESC":
                    {
                        query = query.OrderByDescending(p => p.Price);
                        break;
                    }
            }
        }
    }
}
