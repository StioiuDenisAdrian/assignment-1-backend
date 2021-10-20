using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_1_backend.Models.DTOs
{
    public class NameValueModel<T>
    {
        public T ID { get; set; }
        public string Name { get; set; }
    }
}
