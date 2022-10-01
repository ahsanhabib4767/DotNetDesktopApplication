using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FBApiApplication.CS
{
    [Serializable]
  public  class ApiParameter
    {
        [DataMember]
        public string SendAft { get; set; }
        public string ReloadAft { get; set; }
        public string ApiUrl { get; set; }
        public string ApiUser { get; set; }
        public string ApiPass { get; set; }
        public string autoYN { get; set; }
    }
}
