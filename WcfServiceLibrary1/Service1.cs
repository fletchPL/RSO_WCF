using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        List<Book> listOfBooks = new List<Book>();
        List<User> listOfAllUser = new List<User>();
        public int bookID = 0;
        
         public void addBook()
        {
            for(int i = 0; i<10;i ++)
            {
                Book someBook = new Book();
                someBook.bookID = bookID;
                bookID++;
                someBook.dateOfReturn = DateTime.Now;
                someBook.status = new Status();
                someBook.status.user = new User();
                someBook.status.status = "available";
                someBook.bookInfo = new BookInfo();
                someBook.bookInfo.author = "author" + i;
                someBook.bookInfo.title = "title" + i;
                someBook.bookInfo.description = "description" + i;



                listOfBooks.Add(someBook);
            }
        }

        public List<Book> listOfAllItems()
        {
            /*for(int i=0;i<listOfBooks.Count;i++)
            {
                Console.WriteLine("Author: " + listOfBooks[i].bookInfo.author + " Title: " + listOfBooks[i].bookInfo.title + " BookID: " + listOfBooks[i].bookID + " Stauts: " + listOfBooks[i].status.status);
            }*/
            
            return listOfBooks.ToList();
        }


        public Status borrowBook(int bookID, int userID)
        {
            Book bookToBorrow = listOfBooks[bookID];
            if(bookToBorrow.status.status == "rent")
            {
                Console.WriteLine("Book already taken");
            }
            else
            {
                bookToBorrow.status.status = "rent";
                bookToBorrow.status.user.userID = userID;
                listOfBooks[bookID] = bookToBorrow;
                
            }
            return bookToBorrow.status;
        }
        public int logUser(string userName)
        {
            User user = new User();
            user.userID = listOfAllUser.Count;
            user.userName = userName;

            return user.userID;
        }


        public BookInfo getBookInfo(int bookID)
        {
            if (bookID > listOfBooks.Count || bookID < 0)
            {
                
            }
            return listOfBooks[bookID].bookInfo;
        }

        public List<Book> getBorrowedBooks(int userID)
        {
            List<Book> borrowedBooks = listOfBooks.Where(b => b.status.status == "rent" && b.status.user.userID==userID).ToList();
            return borrowedBooks;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Book> listOfBorrowedItems()
        {
            return listOfBooks.Where(b => b.status.status == "rent").ToList();
        }

        public int sum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}







