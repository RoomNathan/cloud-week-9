namespace Service;

public interface IFoodService
{
    Task<List<Food>> GetAllFood();
};

public class FoodService : IFoodService
{
    private readonly IFoodRepo _foodRepo;

    public FoodService(IFoodRepo foodRepo)
    {
        _foodRepo = foodRepo;
    }

    public Task<List<Food>> GetAllFood()
    {
        return _foodRepo.GetAllFood();
    }
}