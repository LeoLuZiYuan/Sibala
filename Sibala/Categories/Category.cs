namespace Sibala.Categories;

public abstract class Category
{
    public string WinnerOutput { get; set; }
    public abstract CategroyType Type { get; }

    public abstract string Name { get;}
}