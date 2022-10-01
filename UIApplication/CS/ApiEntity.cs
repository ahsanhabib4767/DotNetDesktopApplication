using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FBApiApplication.CS
{
    [Serializable]
    [DataContract]
    public class ApiEntity
    {
        [DataMember]
        public string RefCode { get; set; }
        [DataMember]
        public string BankCode { get; set; }
        [DataMember]
        public string BranchCode { get; set; }
        [DataMember]
        public string AccountNo { get; set; }
        [DataMember]
        public string TrnNo { get; set; }
        [DataMember]
        public string DistributorCode { get; set; }

        [DataMember]
        public string CrAmount { get; set; }
        [DataMember]
        public string DrAmount { get; set; }
        [DataMember]
        public string DepositSlip { get; set; }
        [DataMember]
        public string TrnDate { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string Password { get; set; }
        public string WebApiUrl { get; set; }
    }
}
