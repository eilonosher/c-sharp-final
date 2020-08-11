using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameService
{
    [DataContract]
    internal class OpponentDisconnectedFault
    {
        [DataMember]
        public string Details { get; set; }
    }
}
