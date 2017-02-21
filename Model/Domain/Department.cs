namespace Model.Domain
{
    using System.Collections.Generic;

    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<User> Users { get; private set; }
    }
}
