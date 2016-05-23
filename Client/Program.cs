using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary1;

namespace Client
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary1/Service1/");
            var myChannelFactory = new ChannelFactory<IService1>(myBinding,myEndpoint);

            IService1 clinet = null;
            int option = 0;
            try
            {

                clinet = myChannelFactory.CreateChannel();
                clinet.addBook();
                Console.WriteLine("Type Your userName: ");
                string userName = Console.ReadLine();
                int userID = clinet.logUser(userName); // dodac readline

                /*  MENU  */
                
                
              
                do
                {
                    Console.WriteLine("***MENU***");
                    Console.WriteLine("1) ListOfBorrowedItems");
                    Console.WriteLine("2) GetBorrowedBooks ");
                    Console.WriteLine("3) GetBookInfo");
                    Console.WriteLine("4) BorroweBook");
                    Console.WriteLine("5) ListOfAllItems");
                    Console.WriteLine("0) Exit");

                    string optionString = Console.ReadLine().ToString();
                    option = Int32.Parse(optionString);

                    switch(option)
                    {
                        case 1:
                            List<Book> listOfBorrowedItem = clinet.listOfBorrowedItems();
                            foreach (Book b in listOfBorrowedItem)
                            {
                                Console.WriteLine("Book: " + b.bookInfo.title + " " + b.status.status);
                            }
                            break;
                        case 2:
                            List<Book> listOfBookInClientClass = clinet.getBorrowedBooks(userID);
                            foreach (Book b in listOfBookInClientClass)
                            {
                                Console.WriteLine("Author: " + b.bookInfo.author + " Title: " + b.bookInfo.title + " BookID: " + b.bookID + " userID:" + b.status.user.userID);
                            }
                            break;
                        case 3:
                            //bookInfo 
                            Console.WriteLine("Give a bookID: ");
                            int userBookID = Int32.Parse(Console.ReadLine().ToString());
                            BookInfo bookInfo = clinet.getBookInfo(userBookID);
                           Console.WriteLine(bookInfo.title + " " + bookInfo.author + " " + bookInfo.description);
                            break;
                        case 4:
                            Console.WriteLine("Give a bookID: ");
                            userBookID = Int32.Parse(Console.ReadLine().ToString());
                            clinet.borrowBook(userBookID, userID);
                            break;
                        case 5:
                            List<Book> listOfAllItem = clinet.listOfAllItems();
                            foreach (Book b in listOfAllItem)
                            {
                                Console.WriteLine("Author: " + b.bookInfo.author + " Title: " + b.bookInfo.title + " BookID: " + b.bookID + " Stauts: " + b.status.status);
                            }
                            break;
                       
                    }



                } while (option != 0);

                
                
               // Console.WriteLine(clinet.sum(2, 2));
                //Console.ReadLine();
                ((ICommunicationObject)clinet).Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
                if(clinet !=null)
                {
                    ((ICommunicationObject)clinet).Abort();
                }
            }
        }
    }
}
