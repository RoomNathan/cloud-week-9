namespace Repository;

public interface IFoodRepo
{
    Task<List<Food>> GetAllFood();
}

public class FoodRepo : IFoodRepo
{
    protected readonly SqlConnection _sqlConnection;

    public FoodRepo(SqlConnection sqlConnection)
    {
        _sqlConnection = sqlConnection;
    }

    public async Task<List<Food>> GetAllFood()
    {
        List<Food> foods = new List<Food>();

        await _sqlConnection.OpenAsync();
        SqlCommand command = new SqlCommand("SELECT Id, Name, Price, Description FROM dbo.Food", _sqlConnection);
        SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Food food = new Food
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                Description = reader.GetString(3)
            };
            foods.Add(food);
        }
        await _sqlConnection.CloseAsync();
        return foods;
    }
}