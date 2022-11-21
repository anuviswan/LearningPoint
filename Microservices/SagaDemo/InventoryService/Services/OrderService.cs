namespace Saga.Services.InventoryService.Services;

public class OrderService
{

	private ILogger _logger;
	public OrderService(ILogger<OrderService> logger)
	{
		_logger = logger;
	}


	public Guid CreateOrder()
	{
		// Create Order Here with Status pending
		return default;
	}


	public void CancelOrder(Guid orderId)
	{

	}


	public void CompleteOrder(Guid orderId)
	{

	}
}
