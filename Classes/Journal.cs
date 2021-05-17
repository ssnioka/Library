using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4_laboratorinis.Classes
{
    public class Journal : Publication
    {
        public string JISBN{ get; set; }
        public string JournalNo { get; set; }

        public Journal() { }

        public Journal(string name, string type, string publishinghouse, DateTime publishdate, int pagecount, int copies, string jisbn, string journalno)
            : base(name, type, publishinghouse, publishdate, pagecount, copies)
        {
            this.JISBN = jisbn;
            this.JournalNo = journalno;
           
        }

        /// <summary>
        /// method used to check if the journal is new
        /// </summary>
        /// <returns></returns>
        public override bool IsNew()
        {
            if (DateTime.Now.AddMonths(-1) < PublishDate) return true;
                return false;
        }

        /// <summary>
        /// compare to method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override int CompareTo(Publication other)
        {
            Journal otherJournals = other as Journal;
            if (this.PublishDate.Year.CompareTo(otherJournals.PublishDate.Year) == 0)
            {
                return otherJournals.PublishDate.Month.CompareTo(this.PublishDate.Month);
            }
            return this.PublishDate.Year.CompareTo(otherJournals.PublishDate.Year);
        }

        /// <summary>
        /// equals method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(Publication other)
        {
            Journal otherJournal = other as Journal;
            if (otherJournal != null &&
                Name == otherJournal.Name &&
                Type == otherJournal.Type &&
                PublishingHouse == otherJournal.PublishingHouse &&
                PublishDate == otherJournal.PublishDate &&
                PageCount == otherJournal.PageCount &&
                JISBN == otherJournal.JISBN &&
                JournalNo == otherJournal.JournalNo)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// to csv file method
        /// </summary>
        /// <returns></returns>
        public override string ToStringCSV()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};{6};{7}", Name, Type, PublishingHouse, PublishDate, PageCount, Copies, JISBN, JournalNo);
        }

        /// <summary>
        /// to string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("| {0,-20} | {1, -20} | {2,-15} | {3, -10} | {4,-10} | {5,5} | {6,6} | {7,20} |", Name, Type, PublishingHouse, PublishDate, PageCount, Copies, JISBN, JournalNo);
        }
    }
}