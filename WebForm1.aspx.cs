using System;
using System.Collections.Generic;
using System.IO;
using _4_laboratorinis.Classes;

namespace _4_laboratorinis
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        public List<Library> Libraries = new List<Library>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            InOutUtils.DeleteOldFiles();

            try
            {
                Session["Libraries"] = InOutUtils.ReadFiles("1");
                Libraries = (List<Library>)Session["Libraries"];
            }
            catch (FormatException ex)
            {
                Label2.Text = "Error: " + ex.Message + '\n' + ex.StackTrace + '\n' +  ex.Source;
                Label2.Style["Color"] = "Red";
            }
            catch (FileNotFoundException ex)
            {
                Label2.Text = "Error: " + ex.Message + ex.StackTrace + ex.Source;
                Label2.Style["Color"] = "Red";
            }

            /////////////////////////////////////////////////////////////////////////
            List<Publication> Publications = TaskUtils.GetAllPublications(Libraries);
            List<Publication> Books = TaskUtils.FilterBooks(Publications);
            List<Publication> Journals = TaskUtils.FilterJournals(Publications);
            List<Publication> Newspapers = TaskUtils.FilterNewspapers(Publications);
            List<Publication> filteredBooks = TaskUtils.Sort(Books);
            List<Publication> filteredJournals = TaskUtils.Sort(Journals);
            List<Publication> filteredNewspapers = TaskUtils.Sort(Newspapers);
            /////////////////////////////////////////////////////////////////////////
            List<Publication> allPublications = TaskUtils.MergedLists(filteredBooks, filteredJournals, filteredNewspapers);

            InOutUtils.PrintToTXT(Libraries);
          
            Label1.Text = TaskUtils.OldPublicationsCount(allPublications).ToString();

            TaskUtils.FindScientificRecords(Table1, allPublications);
            TaskUtils.FindOldPublications(Table2, allPublications);
            TaskUtils.FindMostCopies(Table3, allPublications);

            InOutUtils.PrintOldPublicationsCSV(allPublications);
            InOutUtils.AlotOfCopiesCSV(allPublications);

        }

    
    }
}