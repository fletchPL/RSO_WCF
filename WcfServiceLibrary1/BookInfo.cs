using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class BookInfo
    {
        [DataMember]
        public string author;
        [DataMember]
        public string title;
        [DataMember]
        public string description;
    }
}
