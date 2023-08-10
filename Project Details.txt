Follow the steps:

1. Priject => ASP.NET CORE Web App (Model-View-Controller)
2. sql  - table
3. Package Download => Microsoft.EntityFramework.Core,
			Microsoft.EntityFramework.Core.Design,
			Microsoft.EntityFramework.Tools,
			Microsoft.EntityFramework.Core.SqlServer
4. Package Manager Console Command => Scaffold-DbContext "Data Source=(localdb)\mssqllocaldb;Database=Infinity;Initial Catalog=Infinity;Trusted_Connection=True;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
5. add Foleder name (Repositories) => add interface class (ICustomerRepo) => Add class (CustomerRepo)
6. add mvc empty controller (CustomersController)
7. connection strings
8. program cs