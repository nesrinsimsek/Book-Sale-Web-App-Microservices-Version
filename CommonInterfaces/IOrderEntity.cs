using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface IOrderEntity
    {
        int Id { get; set; }
        string Address { get; set; }
        decimal TotalPrice { get; set; }
    }
}
