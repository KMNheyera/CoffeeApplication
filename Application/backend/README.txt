Assessment Readme
Introduction
This repository contains the solution for the Coffee Application Assessment. The solution is made up of two components - CoffeeApplication frontEnd and coffee management backend.

Instructions
To run the solution, follow the steps below:

Open Visual Studio 2022 and run the program CoffeeApplication.sln.
Copy the backend endpoint from the CoffeeApplication project and paste it on the service/service.ts. The current endpoint is "https://localhost:44307/api/Contacts", but it might change the port when you run it on your machine. Do not add a forward slash at the end.
The online Atlas database has been used, and the connection string has already been set up. The connection string is as follows:
"ConnectionString": "mongodb+srv://lbenficious123:70VTzyNMSQ4ElYIu@ContactManagement.xhfbeqe.mongodb.net/?retryWrites=true&w=majority"

Please note that you need to add your IP address to the MongoDB Atlas project to connect the local project to the online Atlas database; otherwise, you will get a connection timeout error. Follow these steps to add your IP address:

Log in to your MongoDB Atlas account and select the ContactManagement project. (Username: lbenficious123@gmail.com, Password: IcanCount123)
Click on the "Network Access" tab in the left-hand menu.
Click on the "Add IP Address" button.
In the "Add IP Address" dialog box, enter the IP address you want to add in the "Whitelist Entry" field. You can also add a description of the IP address in the "Description" field.
Click the "Confirm" button to add the IP address to the whitelist.
Components
The solution consists of the following components:

ContactManagement_FrontEnd - Front-end component developed using JQuery, AJAX, HTML, CSS, and Bootstrap. These technologies are well-known and can be easily managed by most developers.
ContactManagement - Back-end component developed using .NET 6. .NET 6 comes with several performance improvements and optimizations, including faster startup times and reduced memory usage. This can lead to faster and more efficient application performance.

Testing
The solution was tested using Visual Studio 2022.

Conclusion
Overall, the solution meets the assessment's requirements and has been tested to ensure it works correctly. If you have any questions or issues with the solution, please do not hesitate to contact me via email at benficious@gmail.com or by phone at 0827320874.