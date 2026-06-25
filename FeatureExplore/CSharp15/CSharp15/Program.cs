using System.Runtime.CompilerServices;

Console.WriteLine(" C# 15 Features ");
Console.WriteLine("-----------------");



// Union Type Usage Example
ApiResponse<Customer> response = new Unauthorized("User is not authorized to access this resource.");

var result = response switch
{
    Success<Customer> success => $"Success: {success.Data}",
    ValidationError validationError => $"Validation Error: {string.Join(", ", validationError.Errors)}",
    Unauthorized unauthorized => $"Unauthorized: {unauthorized.Reason}",
    NotFound notFound => $"Not Found: {notFound.ResourceName} with ID {notFound.ResourceId}",
    // Compiler guarantees all possibilities are covered 
};



// Closed Hierarchy Usage Example

PaymentMethod payment = new Upi();

var paymentType = payment switch
{
    Upi => "Processing UPI payment",
    NetBanking => "Processing Net Banking transaction",
    CreditCard => "Processing Credit Card payment"
    // Compiler guarantees all possibilities are covered within the assembly
};


// Collection Expression Arguements

string[] values = ["apple", "ball", "cat"];

// Pass capacity argument to List<T> constructor
List<string> names = [with(capacity: values.Length * 2), .. values];

// Pass comparer argument to HashSet<T> constructor
HashSet<string> set = [with(StringComparer.OrdinalIgnoreCase), "apple", "APPLE", "Apple"];
// set contains only one element because all strings are equal with OrdinalIgnoreCase


Console.WriteLine(result);

// Union Type Definitions
public record Customer();

public record Success<T>(T Data);

public record ValidationError(IReadOnlyList<string> Errors);

public record Unauthorized(string Reason);

public record NotFound(string ResourceName, string ResourceId);

public union ApiResponse<T>(
    Success<T>,
    ValidationError,
    Unauthorized,
    NotFound);



// Closed Hierarchy Definitions
public closed record PaymentMethod;

public record Upi : PaymentMethod;
public record NetBanking : PaymentMethod;
public record CreditCard : PaymentMethod;


