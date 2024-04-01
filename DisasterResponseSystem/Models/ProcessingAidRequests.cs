using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponseSystem.Models
{
    public class ProcessingAidRequests
    {
        public long Id { set; get; }
        public float Value{ set; get; }
        public long AidRequestId { set; get; }
        public virtual AidRequest AidRequest { set; get; }
    }
}
