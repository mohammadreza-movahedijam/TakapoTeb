using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Role.ViewModel
{
    public class RouteViewModel
    {
        public int Order {  get; set; }
        public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
