using EMS.EmployesData;

namespace EMS.Models
{
    public class MockEmloyeeData : IEmployeeData
    {
        private List<Employee> _employees = new List<Employee>()
        {
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Aqib"
            },
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="malik"
            }

        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }

        public Employee GetEmployee(Guid id)
        {
            return _employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
