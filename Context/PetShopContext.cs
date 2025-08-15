using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_PetShop.Entidades;
using Microsoft.EntityFrameworkCore;

namespace API_PetShop.Context
{
    public class PetShopContext : DbContext
    {

        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {

        }

        public DbSet<Cachorro> Cachorros { get; set; }

    }
}