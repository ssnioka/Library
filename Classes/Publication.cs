using System;


namespace _4_laboratorinis.Classes
{
    public abstract class Publication : IComparable<Publication>, IEquatable<Publication>
    {
       public string Name { get; set; }
       public string Type { get; set; }
       public string PublishingHouse { get; set; }
       public DateTime PublishDate { get; set; }
       public  int PageCount { get; set; }
       public int Copies { get; set; }

        public Publication() { }
        public Publication(string name, string type, string publishinghouse, DateTime publishdate, int pagecount, int copies)
        {
            this.Name = name;
            this.Type = type;
            this.PublishingHouse = publishinghouse;
            this.PublishDate = publishdate;
            this.PageCount = pagecount;
            this.Copies = copies;
        }


        public abstract bool IsNew();

        public abstract string ToStringCSV();

        public static string ToStringHeader()
        {
            return String.Format("| {0,-20} | {1,-20} | {2,-15} | {3,-10} | {4,-5} | {5,5} | {6,6} | {7,20} | {8,8} | {9,15} |", 
                                "Pavadinimas", "Tipas", "Leidykla", "Isleidimo metai", "Psl. skaicius", "Tirazas", "ISBN", "Autorius", "Numeris", "Data laikrascio");
        }
 
        public abstract int CompareTo(Publication other);

        public abstract bool Equals(Publication other);
       

    }
}