using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;


namespace _4_laboratorinis.Classes
{
    public static class InOutUtils
    {
        /// <summary>
        /// deletes old files
        /// </summary>
        public static void DeleteOldFiles()
        {
            string results = HttpContext.Current.Server.MapPath("App_Data/Results.txt");
            File.Delete(results);
            File.Delete(HttpContext.Current.Server.MapPath("App_Data/PopuliarusLeidiniai.csv"));
            string[] Files = Directory.GetFiles(HttpContext.Current.Server.MapPath("App_Data/"), "Nenauji.csv");
            foreach (string fileName in Files)
                File.Delete(Path.Combine(HttpContext.Current.Server.MapPath("App_Data"), fileName));
        }

        /// <summary>
        /// finds files
        /// </summary>
        /// <param name="variation"></param>
        /// <returns></returns>
        private static string[] FindFiles(string variation)
        {
            string[] Files = Directory.GetFiles(HttpContext.Current.Server.MapPath("App_Data/"), "Biblioteka?_" + variation + ".csv");
            if (Files.Length == 0) throw new FileNotFoundException("Failai neegzistuoja");
            return Files;
        }


        /// <summary>
        /// read file
        /// </summary>
        /// <param name="variation"></param>
        /// <returns></returns>
        public static List<Library> ReadFiles(string variation = "1")
        {
            string[] Files = FindFiles(variation);
            List<Library> Libraries = new List<Library>();
            for (int i = 0; i < Files.Length; i++)
            {
                Libraries.Add(ReadFile(Files[i]));
            }
            return Libraries;
        }



        /// <summary>
        /// reads data
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static Library ReadFile(string fileName)
        {
       
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                string libraryname = reader.ReadLine();
                string address = reader.ReadLine();
                string phoneno = reader.ReadLine();
                string line;
                List<Publication> Publications = new List<Publication>();
                if ((line = reader.ReadLine()) == null)
                {
                    throw new FormatException("Neteisingas duomenu formatas");
                }
                else
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] Values = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        string objtype = Values[0];
                        string name = Values[1];
                        string type = Values[2];
                        string publishinghouse = Values[3];
                        DateTime publishtime = DateTime.Parse(Values[4]);
                        int pagecount = int.Parse(Values[5]);
                        int copies = int.Parse(Values[6]);

                        if (objtype.Equals("Book"))
                        {
                            string bisbn = Values[7];
                            string author = Values[8];
                            Book Book = new Book(name, type, publishinghouse, publishtime, pagecount, copies, bisbn, author);
                            Publications.Add(Book);
                        }
                        if (objtype.Equals("Journal"))
                        {
                            string jisbn = Values[7];
                            string journalno = Values[8];
                            Journal Journal = new Journal(name, type, publishinghouse, publishtime, pagecount, copies, jisbn, journalno);
                            Publications.Add(Journal);
                        }
                        if (objtype.Equals("Newspaper"))
                        {
                            string newspaperdate = Values[7];
                            int newspaperno = int.Parse(Values[8]);
                            Newspaper Newspaper = new Newspaper(name, type, publishinghouse, publishtime, pagecount, copies, newspaperdate, newspaperno);
                            Publications.Add(Newspaper);
                        }
                    }
                }
                return new Library(libraryname, address, phoneno, Publications);
            }

        }


        /// <summary>
        /// generate table header
        /// </summary>
        /// <param name="table"></param>
        public static void GenerateTableHeader(Table table)
        {
            TableHeaderCell cell1 = new TableHeaderCell();
            TableHeaderCell cell2 = new TableHeaderCell();
            TableHeaderCell cell3 = new TableHeaderCell();
            TableHeaderCell cell4 = new TableHeaderCell();
            TableHeaderCell cell5 = new TableHeaderCell();
            TableHeaderCell cell6 = new TableHeaderCell();
            TableHeaderCell cell7 = new TableHeaderCell();
            TableHeaderCell cell8 = new TableHeaderCell();
            TableHeaderCell cell9 = new TableHeaderCell();
            TableHeaderCell cell10 = new TableHeaderCell();


            cell1.Text = "Pavadinimas";
            cell2.Text = "Tipas";
            cell3.Text = "Leidykla";
            cell4.Text = "Išleidimo metai";
            cell5.Text = "Psl. Skaičius";
            cell6.Text = "Tiražas";
            cell7.Text = "ISBN";
            cell8.Text = "Autorius";
            cell9.Text = "Numeris";
            cell10.Text = "Data";


            TableHeaderRow row = new TableHeaderRow();

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);
            row.Cells.Add(cell5);
            row.Cells.Add(cell6);
            row.Cells.Add(cell7);
            row.Cells.Add(cell8);
            row.Cells.Add(cell9);
            row.Cells.Add(cell10);


            table.Rows.Add(row);
        }

        /// <summary>
        /// inserts data into the table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="Publications"></param>
        public static void GenerateTable(Table table, List<Publication> Publications)
        {
            GenerateTableHeader(table);
            foreach (Publication publication in Publications)
            {
                TableCell name = new TableCell();
                TableCell type = new TableCell();
                TableCell publishinghouse = new TableCell();
                TableCell publishdate = new TableCell();
                TableCell pagecount = new TableCell();
                TableCell copies = new TableCell();
                TableCell isbn = new TableCell();
                TableCell author = new TableCell();
                TableCell number = new TableCell();
                TableCell newspaperdate = new TableCell();
                TableCell empty = new TableCell();
                empty.Text = "-";
                TableRow row = new TableRow();
                if (publication is Book)
                {
                    Book book = publication as Book;

                    name.Text = book.Name;
                    type.Text = book.Type;
                    publishinghouse.Text = book.PublishingHouse;
                    publishdate.Text = book.PublishDate.ToString();
                    pagecount.Text = book.PageCount.ToString();
                    copies.Text = book.Copies.ToString();
                    isbn.Text = book.BISBN;
                    author.Text = book.Author.ToString();
                    number.Text = "-";
                    newspaperdate.Text = "-";


                    row.Cells.Add(name);
                    row.Cells.Add(type);
                    row.Cells.Add(publishinghouse);
                    row.Cells.Add(publishdate);
                    row.Cells.Add(pagecount);
                    row.Cells.Add(copies);
                    row.Cells.Add(isbn);
                    row.Cells.Add(author);
                    row.Cells.Add(number);
                    row.Cells.Add(newspaperdate);

                    table.Rows.Add(row);

                }

                if (publication is Journal)
                {
                    Journal journal = publication as Journal;

                    name.Text = journal.Name;
                    type.Text = journal.Type;
                    publishinghouse.Text = journal.PublishingHouse;
                    publishdate.Text = journal.PublishDate.ToString();
                    pagecount.Text = journal.PageCount.ToString();
                    copies.Text = journal.Copies.ToString();
                    isbn.Text = journal.JISBN;
                    author.Text = "-";
                    number.Text = journal.JournalNo.ToString();
                    newspaperdate.Text = "-";

                    row.Cells.Add(name);
                    row.Cells.Add(type);
                    row.Cells.Add(publishinghouse);
                    row.Cells.Add(publishdate);
                    row.Cells.Add(pagecount);
                    row.Cells.Add(copies);
                    row.Cells.Add(isbn);
                    row.Cells.Add(author);
                    row.Cells.Add(number);
                    row.Cells.Add(newspaperdate);

                    table.Rows.Add(row);
                }
                if (publication is Newspaper)
                {
                    Newspaper newspaper = publication as Newspaper;

                    name.Text = newspaper.Name;
                    type.Text = newspaper.Type;
                    publishinghouse.Text = newspaper.PublishingHouse;
                    publishdate.Text = newspaper.PublishDate.ToString();
                    pagecount.Text = newspaper.PageCount.ToString();
                    copies.Text = newspaper.Copies.ToString();
                    isbn.Text = "-";
                    author.Text = "-";
                    number.Text = newspaper.NewspaperNo.ToString();
                    newspaperdate.Text = newspaper.NewspaperDate.ToString();

                    row.Cells.Add(name);
                    row.Cells.Add(type);
                    row.Cells.Add(publishinghouse);
                    row.Cells.Add(publishdate);
                    row.Cells.Add(pagecount);
                    row.Cells.Add(copies);
                    row.Cells.Add(isbn);
                    row.Cells.Add(author);
                    row.Cells.Add(number);
                    row.Cells.Add(newspaperdate);

                    table.Rows.Add(row);
                }

            }

        }
        /// <summary>
        /// generates copy header
        /// </summary>
        /// <param name="table"></param>
        public static void GenerateCopiesHeader(Table table)
        {
            TableHeaderCell cell1 = new TableHeaderCell();
            TableHeaderCell cell2 = new TableHeaderCell();

            cell1.Text = "Pavadinimas";
            cell2.Text = "Tiražas";

            TableHeaderRow row = new TableHeaderRow();

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);

            table.Rows.Add(row);
        }

        /// <summary>
        /// generatetable for copies
        /// </summary>
        /// <param name="table"></param>
        /// <param name="Publications"></param>
        public static void GenerateTableforCopies(Table table, List<Publication> Publications)
        {
            GenerateCopiesHeader(table);

            foreach (Publication publication in Publications)
            {
                TableCell name = new TableCell();
                TableCell copies = new TableCell();

                TableRow row = new TableRow();

                name.Text = publication.Name;
                copies.Text = publication.Copies.ToString();

                row.Cells.Add(name);
                row.Cells.Add(copies);

                table.Rows.Add(row);

            }
        }
        /// <summary>
        /// prints oldtimers to csv file
        /// </summary>
        /// <param name="AllPublications"></param>

        public static void PrintOldPublicationsCSV(List<Publication> AllPublications)
        {
            List<Publication> OldTimers = TaskUtils.OldPublications(AllPublications);
            using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath("App_Data/Nenauji.csv")))
            {
                foreach(Publication publication in OldTimers)
                {
                    writer.WriteLine(publication.ToStringCSV());
                }
            }
               
        }
        

        /// <summary>
        /// method  used to print lots of copies to csv file
        /// </summary>
        /// <param name="AllPublications"></param>
        public static void AlotOfCopiesCSV(List<Publication> AllPublications)
        {
            string space = " ";
            List<Publication> LotsOfCopies = TaskUtils.AlotOfCopies(AllPublications);
            using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath("App_Data/PopuliarusLeidiniai.csv")))
            {
                foreach(Publication publication in LotsOfCopies)
                {
                    writer.Write(publication.Name);
                    writer.Write(space);
                    writer.WriteLine(publication.Copies);
                }
            }
        }

        /// <summary>
        /// prints initial data to txt
        /// </summary>
        /// <param name="Libraries"></param>
        public static void PrintToTXT(List<Library> Libraries)
        {
            using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath("App_Data/Results.txt")))
            {

                foreach (Library library in Libraries)
                {
                    writer.WriteLine(library.LibraryName);
                    writer.WriteLine(library.Address);
                    writer.WriteLine(library.PhoneNo);
                    writer.WriteLine(new string('-', Publication.ToStringHeader().Length));
                    writer.WriteLine(Publication.ToStringHeader());
                    writer.WriteLine(new string('-', Publication.ToStringHeader().Length));
                    for (int i = 0; i < library.PublicationsCount(); i++)
                    {
                        Publication publication = library.Get(i);
                        writer.WriteLine(publication.ToString());
                        writer.WriteLine(new string('-', Publication.ToStringHeader().Length));
                    }
                    writer.WriteLine();
                }

            }
        }
    }
}