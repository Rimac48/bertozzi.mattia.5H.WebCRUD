#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bertozzi.mattia._5H.WebCRUD.Models;

    public class WebCRUDContext : DbContext
    {
        public WebCRUDContext (DbContextOptions<WebCRUDContext> options)
            : base(options)
        {
        }

        public DbSet<bertozzi.mattia._5H.WebCRUD.Models.Movie> Movie { get; set; }
    }
