# ToDo API Project

This project is a simple ASP.NET Core Web API for managing a ToDo list. The API allows users to perform CRUD operations on ToDo items. 

## Features

- **Create a ToDo**: Add a new task with a title, description, and created date.
- **Read ToDos**: Retrieve all tasks or a specific task by ID.
- **Update a ToDo**: Modify an existing task.
- **Delete a ToDo**: Remove a task by ID.

## Technologies Used

- ASP.NET Core Web API
- C#
- Swagger (for API documentation and testing)

## API Endpoints

### GET /api/ToDoController
- Retrieves all ToDo items.

### GET /api/ToDoController/{id}
- Retrieves a specific ToDo item by ID.

### POST /api/ToDoController
- Creates a new ToDo item.
- **Request Body Example**:
    ```json
    {
      "title": "Buy groceries",
      "description": "Remember to buy milk and eggs."
    }
    ```

### PUT /api/ToDoController/{id}
- Updates an existing ToDo item.

### DELETE /api/ToDoController/{id}
- Deletes a specific ToDo item by ID.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/AlifurkanKaraman/ToDoList.git
   ```
2. Navigate to the project directory:
    ```bash
    cd ToDoList
    ```
3. Build the project:
    ```bash
    dotnet build
    ```
4. Run the project:
   ```bash
   dotnet run
   ```
## Testing with Swagger
- Once the application is running, you can access Swagger UI at http://localhost:7261/swagger to test and view API documentation.


