using System;
using System.Collections.Generic;


namespace _4_laboratorinis.Classes
{
    public class Library
    {
        public string LibraryName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public List<Publication> Publications { get; set; }

        public Library() { }
        public Library(List<Publication> publications)
        {
            this.Publications = publications;
        }
        public Library(string libraryname, string address, string phoneno, List<Publication> publications)
        {
            this.LibraryName = libraryname;
            this.Address = address;
            this.PhoneNo = phoneno;
            this.Publications = publications;
        }
        /// <summary>
        /// Get publication by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Publication Get(int id)
        {
            return Publications[id];
        }
        /// <summary>
        /// Get publications count
        /// </summary>
        /// <returns></returns>
        public int PublicationsCount()
        {
            if (Publications == null)
                throw new NullReferenceException("Null");
            return Publications.Count;
        }

        /// <summary>
        /// contains method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Contains(Publication other)
        {
            foreach (Publication publication in Publications)
            {
                if (publication.Equals(other)) return true;
            }
            return false;
        }
        
        

    }

}