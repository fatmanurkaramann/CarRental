
using Core.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Color:IEntity
    {
        public int ColorId { get; set; }
        public string ColorNameTr { get; set; }
        public string ColorNameEn { get; set; }
    }
}
