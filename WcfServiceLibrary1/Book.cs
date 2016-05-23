using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int bookID;
        [DataMember]
        public BookInfo bookInfo;
        [DataMember]
        public DateTime dateOfReturn;
        [DataMember]
        public Status status;
    }
}
