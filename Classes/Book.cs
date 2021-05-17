using System;


namespace _4_laboratorinis.Classes
{
    public class Book : Publication
    {
        public string BISBN{ get; set; }
        public string Author { get; set; }

        public Book() { }

        public Book(string name, string type, string publishinghouse, DateTime publishdate, int pagecount, int copies, string bisbn, string author)
            : base (name, type, publishinghouse, publishdate, pagecount, copies)
        {
            this.BISBN = bisbn;
            this.Author = author;
        }

        /// <summary>
        /// method used to check if the book is new or not
        /// </summary>
        /// <returns></returns>
        public override bool IsNew()
        {
            if (DateTime.Now.Year - PublishDate.Year <= 1) return true;
            return false;
        }

        /// <summary>
        /// compare to method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override int CompareTo(Publication other)
        {
            Book otherBooks = other as Book;
            return this.PublishDate.Year.CompareTo(otherBooks.PublishDate.Year);
        }

        /// <summary>
        /// equals method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(Publication other)
        {
            Book otherBooks = other as Book;
            if(otherBooks != null &&
                Name == otherBooks.Name &&
                Type == otherBooks.Type &&
                PublishingHouse == otherBooks.PublishingHouse &&
                PublishDate == otherBooks.PublishDate &&
                PageCount == otherBooks.PageCount)
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// STRING FOR printing to csv file
        /// </summary>
        /// <returns></returns>
        public override string ToStringCSV()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};{6};{7}", Name, Type, PublishingHouse, PublishDate, PageCount, Copies, BISBN, Author);
        }
        /// <summary>
        /// to string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("| {0,-20} | {1, -20} | {2,-15} | {3, -10} | {4,-10} | {5,5} | {6,6} | {7,20} |", Name, Type, PublishingHouse, PublishDate, PageCount, Copies, BISBN, Author);
        }



    }
}