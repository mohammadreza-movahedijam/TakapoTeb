using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product;

public class ProductEntity:BaseEntity
{
    public string? ImagePath { get; set; }
    public string? Title { get; set; }   
    public string? Descrption { get; set; }   
    public string? VideoLink { get; set; }
}
