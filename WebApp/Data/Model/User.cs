using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;



namespace Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        //public decimal Latitude { get; set; }
        //public decimal Longitude { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        [ForeignKey("UsersRole")]
        public int UserRoleId { get; set; }
        public UsersRole UsersRole { get; set; }

        //[ForeignKey("FilePath")]
        //public int FilePathId { get; set; }
        public FilePath FilePath { get; set; }


        public virtual ICollection<File> Files { get; set; }
     
    }
}
