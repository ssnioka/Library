using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _4_laboratorinis.Classes
{
    public static class TaskUtils
    {
        /// <summary>
        /// method used to generatetable
        /// </summary>
        /// <param name="Table1"></param>
        /// <param name="Publications"></param>
        public static void FindScientificRecords(Table Table1, List<Publication> Publications)
        {
            InOutUtils.GenerateTable(Table1, TaskUtils.ScientificPublications(Publications));
        }
        /// <summary>
        /// method used to generatetable
        /// </summary>
        /// <param name="Table1"></param>
        /// <param name="Publications"></param>
        public static void FindMostCopies(Table Table2, List<Publication> Publications)
        {
            InOutUtils.GenerateTableforCopies(Table2, TaskUtils.AlotOfCopies(Publications));
        }
        /// <summary>
        /// method used to generatetable
        /// </summary>
        /// <param name="Table1"></param>
        /// <param name="Publications"></param>
        public static void FindOldPublications(Table Table3, List<Publication> Publications)
        {
            InOutUtils.GenerateTable(Table3, TaskUtils.OldPublications(Publications));
        }
        /// <summary>
        /// method used to filter books
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public static List<Publication> FilterBooks(List<Publication> publications)
        {
            List<Publication> filterbooks = new List<Publication>();
            foreach (Publication publication in publications)
            {
                if(publication is Book)
                {
                    filterbooks.Add(publication);
                }
            }
            return filterbooks;
        }
        /// <summary>
        /// method used to filter newspapers
        /// </summary>
        /// <param name="newspapers"></param>
        /// <returns></returns>
        public static List<Publication> FilterNewspapers(List<Publication> publications)
        {
            List<Publication> filternewspapers = new List<Publication>();
            foreach (Publication publication in publications)
            {
                if (publication is Newspaper)
                {
                    filternewspapers.Add(publication);
                }
            }
            return filternewspapers;
        }
        /// <summary>
        /// method used to filter journals
        /// </summary>
        /// <param name="journals"></param>
        /// <returns></returns>
        public static List<Publication> FilterJournals(List<Publication> publications)
        {
            List<Publication> filterjournals = new List<Publication>();
            foreach (Publication publication in publications)
            {
                if (publication is Journal)
                {
                    filterjournals.Add(publication);
                }
            }
            return filterjournals;
        }

        /// <summary>
        /// method used to sort the given list
        /// </summary>
        /// <param name="publications"></param>
        /// <returns></returns>
        public static List<Publication> SortList(List<Publication> publications)
        {
            List<Publication> SortedLists = Sort(publications);
            return SortedLists;

        }
        /// <summary>
        /// method used to merge all the lists
        /// </summary>
        /// <param name="books"></param>
        /// <param name="journals"></param>
        /// <param name="newspapers"></param>
        /// <returns></returns>

        public static List<Publication> MergedLists(List<Publication> books, List<Publication> journals, List<Publication> newspapers)
        {
            books.AddRange(journals);
            books.AddRange(newspapers);
            return books;
        }


        /// <summary>
        /// Gets all publications
        /// </summary>
        /// <param name="Libraries"></param>
        /// <returns></returns>
        public static List<Publication> GetAllPublications(List<Library> Libraries)
        {
            List<Publication> Publications = new List<Publication>();
            foreach(Library library in Libraries)
            {
                for(int i =0; i < library.PublicationsCount(); i++)
                {
                    Publication publication = library.Get(i);
                    if (!Publications.Contains(publication))
                    {
                        Publications.Add(publication);
                    }
                }
            }
            return Publications;
        }

        /// <summary>
        /// Sort method
        /// </summary>
        /// <param name="Publications"></param>
        /// <returns></returns>
        public static List<Publication> Sort(List<Publication> Publications)
        {
            Publications.Sort((x, y) => x.CompareTo(y));
            return Publications;
        }

        /// <summary>
        /// counting the number of publications older than 2 years
        /// </summary>
        /// <param name="Publications"></param>
        /// <returns></returns>
        public static int OldPublicationsCount(List<Publication> Publications)
        {
            int count = 0;
            foreach(Publication publication in Publications)
            {
                if (DateTime.Now.Year - publication.PublishDate.Year > 2)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Finds scientific publications 
        /// </summary>
        /// <param name="Publications"></param>
        /// <returns></returns>
        public static List<Publication> ScientificPublications(List<Publication> Publications)
        {
            List<Publication> scientific = new List<Publication>();
            foreach(Publication publication in Publications)
            {
                if(publication.Type == "mokslinis")
                {
                    scientific.Add(publication);

                }
            }
            return scientific;
        }

        /// <summary>
        /// Find publications that are old
        /// </summary>
        /// <param name="Publications"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Publication> OldPublications(List<Publication> Publications)
        {

            List<Publication> oldPublications = new List<Publication>();
            foreach (Publication publication in Publications)
                    if (!publication.IsNew())
                        oldPublications.Add(publication);
            
            return oldPublications;
        }


        /// <summary>
        /// finds publications that have copy count exceeding 10 000.
        /// </summary>
        /// <param name="Publications"></param>
        /// <returns></returns>
        public static List<Publication> AlotOfCopies(List<Publication> Publications)
        {
            List<Publication> copies = new List<Publication>();
            foreach(Publication publication in Publications)
            {
                if (publication.Copies > 10000)
                    copies.Add(publication);
            }
            return copies;
        }
    }
}