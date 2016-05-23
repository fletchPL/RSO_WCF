using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfServiceLibrary1
{
    [DataContract]
    public  class Status
    {
        [DataMember]
        public string status;
        [DataMember]
        public DateTime dateOfReturn;
        [DataMember]
        public User user;
    }
}
