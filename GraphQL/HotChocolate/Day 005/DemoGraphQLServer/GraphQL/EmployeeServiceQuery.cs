using DemoGraphQLServer.Services;

namespace DemoGraphQLServer.GraphQL;

[ExtendObjectType(typeof(Query))]
public class EmployeeServiceQuery
{
    public async Task<IEnumerable<Employee>> GetAllEmployees([Service]EmployeeService employeeService)
    {
        return await employeeService.GetAllEmployeesAsync();
    }
}
