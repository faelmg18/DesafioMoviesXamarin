using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Libary.Infrastructure
{
    public interface IApplication
    {
        IContainer Services { get; }
        string ServerAddress { get; }
    }
}
