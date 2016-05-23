using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class User 
    {
        [DataMember]
        public int userID;
        [DataMember]
        public string userName;
    }
}
