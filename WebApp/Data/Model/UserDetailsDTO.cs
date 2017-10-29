
using System.Collections.Generic;

namespace Data.Model
{
    public class UserDetailsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string UserRoleName { get; set; }
        public string DepartmentName { get; set; }
        public int UserRoleId { get; set; }
        public FilePath FilePath { get; set; }
        public string FileType { get; set; }
        
       

        public virtual ICollection<File> Files { get; set; }
        //public virtual ICollection<FilePath> FilePaths { get; set; }
    }
}
