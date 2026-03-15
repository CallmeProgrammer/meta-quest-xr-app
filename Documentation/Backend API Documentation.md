# **Backend API Documentation**

## **Overview**

This backend server was developed using **Node.js and Express.js**. It provides APIs required for the Meta Quest XR application to handle:

* User login authentication

* Retrieving the list of available projects

* Retrieving floors based on the selected project

The backend communicates with the Unity XR application through **REST APIs using JSON responses**.

The server also uses **JWT (JSON Web Token)** to generate an authentication token when the user logs in successfully.

---

# **Technologies Used**

The backend uses the following technologies:

* **Node.js** – JavaScript runtime for building the server

* **Express.js** – Web framework used to create API endpoints

* **CORS** – Allows the Unity application to access the API

* **JSON Web Token (JWT)** – Used to generate a login token for authentication

# **Server Configuration**

The server starts using the following command:

node server.js

The server runs on:

http://localhost:3000  
---

# **Middleware Setup**

### **CORS**

app.use(cors());

This allows external applications such as the Unity XR app to communicate with the backend API.

### **JSON Parsing**

app.use(express.json());

This allows the server to read JSON data sent from the client in POST requests.

---

# **Secret Key**

const SECRET \= "xr\_secret\_key";

This key is used to generate the **JWT authentication token** when a user logs in successfully.

---

# **API Endpoints**

# **1\. Login API**

### **Endpoint**

POST /api/login

### **Description**

This API verifies the user's username and password.  
 If the credentials are correct, the server returns a **JWT authentication token** and user information.

### **Request Body Example**

{  
 "username": "testuser",  
 "password": "123456"  
}

### **Login Validation Logic**

The server performs the following checks:

1. If the username is incorrect, it returns an error indicating **invalid username**.

2. If the username is correct but the password is incorrect, it returns **invalid password**.

3. If both username and password are correct, the server generates a **JWT token** and returns user details.

---

### **Successful Response**

{  
 "success": true,  
 "token": "jwt\_token\_here",  
 "user": {  
   "id": 1,  
   "name": "Test User"  
 }  
}  
---

### **Invalid Username Response**

{  
 "success": false,  
 "error": "username"  
}

---

### **Invalid Password Response**

{  
 "success": false,  
 "error": "password"  
}  
---

# **2\. Project List API**

### **Endpoint**

GET /api/projects

### **Description**

This API returns the list of available projects.  
 The Unity XR application displays these projects for the user to select.

### **Example Response**

{  
 "projects": \[  
   { "id": 1, "name": "Project A" },  
   { "id": 2, "name": "Project B" },  
   { "id": 3, "name": "Project C" },  
   { "id": 4, "name": "Project D" }  
 \]  
}

### **Behavior**

When this API is called:

1. The server sends a list of predefined projects.

2. Each project contains an **ID** and a **Name**.

3. The Unity application uses this list to populate the **Project Selection UI**.

# **3\. Floors API**

### **Endpoint**

GET /api/projects/{projectId}/floors

### **Description**

This API returns the list of floors for a specific project.  
 The Unity application calls this API after a project is selected.

### **Example Request**

GET /api/projects/1/floors

### **Example Response**

{  
 "floors": \[  
   "Floor 1",  
   "Floor 2",  
   "Floor 3",  
   "Floor 4"  
 \]  
}

### **Floor Data Mapping**

Each project has different floors:

| Project ID | Floors |
| ----- | ----- |
| 1 | Floor 1, Floor 2, Floor 3, Floor 4 |
| 2 | Floor A, Floor B |
| 3 | Ground, 1, 2, 3, 4, 5 |
| 4 | Basement, Ground, Mezzanine |

# **Server Start**

The server is started using:

app.listen(3000, () \=\> {  
   console.log("Server running on port 3000");  
});

This launches the backend service and listens for API requests on **port 3000**.

---

# **How the Unity XR Application Uses the Backend**

The Unity application performs the following workflow:

1. The user enters login credentials.

2. Unity sends a **POST request to /api/login**.

3. If login succeeds, the user is taken to the **Project Selection screen**.

4. Unity calls **GET /api/projects** to fetch the list of projects.

5. When the user selects a project, Unity calls  
    **GET /api/projects/{projectId}/floors**.

6. The returned floors populate the **Floor dropdown UI**.

---

# **Summary**

The backend provides three main functionalities:

| API | Purpose |
| ----- | ----- |
| `/api/login` | Authenticate the user |
| `/api/projects` | Retrieve the list of projects |
| `/api/projects/{id}/floors` | Retrieve floors for selected project |

These APIs enable the Unity XR application to dynamically load data and provide an interactive user experience.

