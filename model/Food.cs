namespace model;

public class Food
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public string Description { get; set; }

    public override string ToString()
    {
        return $"{Name} (${Price}): {Description}";
    }
}