using EMS.Models;

namespace EMS.EmployesData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);
        
        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);
    }
}
