namespace Library_Management_EF_Core.Models;

public class Author : BaseModel
{
    public string Name { get; set; }
    public List<AuthorBook> AuthorBooks { get; set; }
}
