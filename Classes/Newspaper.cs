using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4_laboratorinis.Classes
{
    public class Newspaper : Publication
    {
        public string NewspaperDate { get; set; }
        public int NewspaperNo { get; set; }
        public Newspaper() { }

        public Newspaper(string name, string type, string publishinghouse, DateTime publishdate, int pagecount, int copies, string newspaperdate, int newspaperno)
           : base(name, type, publishinghouse, publishdate, pagecount, copies)

        {
            this.NewspaperDate = newspaperdate;
            this.NewspaperNo = newspaperno;

        }

        /// <summary>
        /// checks if the newspaper is considered as "new"
        /// </summary>
        /// <returns></returns>
        public override bool IsNew()
        {
            if (DateTime.Now.AddDays(-7) < PublishDate) return true;
                return false;
        }

        /// <summary>
        /// compare to method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override int CompareTo(Publication other)
        {
            Newspaper otherNewspaper = other as Newspaper;
            this.PublishDate.Year.CompareTo(otherNewspaper.PublishDate.Year);
            if (this.PublishDate.Year.CompareTo(otherNewspaper.PublishDate.Year) == 0)
            {
                return otherNewspaper.PublishDate.Month.CompareTo(otherNewspaper.PublishDate.Month);
            }
            else if (this.PublishDate.Month.CompareTo(otherNewspaper.PublishDate.Month) == 0)
            {
                return this.PublishDate.Day.CompareTo(otherNewspaper.PublishDate.Day);
            }
            return this.PublishDate.Year.CompareTo(otherNewspaper.PublishDate);

        }
        /// <summary>
        /// equals method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(Publication other)
        {
            Newspaper otherNewspaper = other as Newspaper;
            if(otherNewspaper != null &&
                Name == otherNewspaper.Name &&
                Type == otherNewspaper.Type &&
                PublishingHouse == otherNewspaper.PublishingHouse &&
                PublishDate == otherNewspaper.PublishDate &&
                PageCount == otherNewspaper.PageCount &&
                NewspaperDate == otherNewspaper.NewspaperDate &&
                NewspaperNo == otherNewspaper.NewspaperNo)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// method used to print data to csv file
        /// </summary>
        /// <returns></returns>
        public override string ToStringCSV()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};{6};{7}", Name, Type, PublishingHouse, PublishDate, PageCount, Copies, NewspaperDate, NewspaperNo);
        }

        /// <summary>
        /// tostring method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("| {0,-20} | {1, -20} | {2,-15} | {3, -10} | {4,-10} | {5,5} | {6,6} | {7,20} |", Name, Type, PublishingHouse, PublishDate, PageCount, Copies, NewspaperDate, NewspaperNo);
        }
    }
}