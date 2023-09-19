using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnjinFilesTool.Event
{
    public interface Cancellable
    {
        public bool Cancelled { get; set; }
    }
}
