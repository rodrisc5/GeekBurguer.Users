using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurguer.Users.Contracts.Commands.Output
{
    public class OutputResponseBaseCommand<T>
    {
        public T Data { get; set; }

        public bool HasError => this.Errors != null ? true : false;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
