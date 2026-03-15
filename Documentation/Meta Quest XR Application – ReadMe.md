# **Meta Quest XR Application – Project**

## **Overview**

This project is a **Meta Quest XR application developed using Unity and OpenXR**.  
 The application allows a user to:

1. Log in using credentials

2. Select a project from a list

3. Choose a floor dynamically based on the selected project

The application communicates with a **Node.js backend API** to retrieve projects and floor data dynamically.

This project was developed as part of the **Meta Quest XR Development Task**.

---

# **Technologies Used**

## **Frontend (XR Application)**

* Unity

* OpenXR

* XR Interaction Toolkit

* TextMeshPro

* DoTween (for toast animations)

## **Backend**

* Node.js

* Express.js

* JWT (JSON Web Token)

* CORS

---

# **XR Features**

The application was designed following **Meta XR UI guidelines** and includes:

* XR controller ray interaction

* World space UI canvas

* Interactive buttons and dropdowns

* Toast notifications for user feedback

* Smooth UI animations using DoTween

The application works with:

* Meta Quest 2

* Meta Quest 3

* Meta Quest Pro

---

# **Application Flow**

Login Screen  
     ↓  
Project Selection Screen  
     ↓  
Floor Selection Screen

Navigation features:

Forward navigation

Login → Project Selection → Floor Selection

Backward navigation

Floor Selection → Project Selection  
Project Selection → Login  
---

# **UI Features**

### **Login Screen**

* Username input

* Password input

* Login button

* Error validation messages

* Remember me option

* Exit application button

### **Project Selection**

* Dropdown listing available projects

* Next button to navigate to floor selection

* Toast notification when a project is selected

### **Floor Selection**

* Dynamic dropdown populated using API

* Next button to confirm floor

* Toast notification when a floor is selected

---

# **Toast Notifications**

Toast notifications appear in **XR world space** and automatically fade out.

Examples:

Login Successful  
Invalid Credentials  
Project Selected: Project A  
Selected Floor: Floor 3

These notifications use **DoTween animations**.

---

# **Backend API**

The backend server provides three APIs used by the Unity XR application.

Base URL example:

http://localhost:3000

or deployed version:

https://your-vercel-app-url  
---

# **1 Login API**

Endpoint

POST /api/login

Description  
 Authenticates the user and returns a JWT token on success.

Request example

{  
"username": "testuser",  
"password": "123456"  
}

Success response

{  
"success": true,  
"token": "jwt\_token\_here",  
"user": {  
  "id": 1,  
  "name": "Test User"  
}  
}

Invalid username

{  
"success": false,  
"error": "username"  
}

Invalid password

{  
"success": false,  
"error": "password"  
}  
---

# **2 Project List API**

Endpoint

GET /api/projects

Description  
 Returns the list of available projects.

Response example

{  
"projects": \[  
 { "id": 1, "name": "Project A" },  
 { "id": 2, "name": "Project B" },  
 { "id": 3, "name": "Project C" },  
 { "id": 4, "name": "Project D" }  
\]  
}  
---

# **3 Floors API**

Endpoint

GET /api/projects/{projectId}/floors

Description  
 Returns the floors associated with a selected project.

Example request

GET /api/projects/1/floors

Example response

{  
"floors": \[  
 "Floor 1",  
 "Floor 2",  
 "Floor 3",  
 "Floor 4"  
\]  
}

Floor data mapping:

| Project | Floors |
| ----- | ----- |
| Project A | Floor 1, Floor 2, Floor 3, Floor 4 |
| Project B | Floor A, Floor B |
| Project C | Ground, 1, 2, 3, 4, 5 |
| Project D | Basement, Ground, Mezzanine |

---

# **Project Structure**

Example Unity project structure:

Assets  
│  
├── Scripts  
│   ├── API  
│   │   └── APIManager.cs  
│   │  
│   ├── UI  
│   │   ├── LoginUI.cs  
│   │   ├── ProjectDropdownUI.cs  
│   │   └── FloorDropdownUI.cs  
│   │  
│   ├── Managers  
│   │   └── NavigationManager.cs  
│   │  
│   └── ToastNotification.cs  
│  
├── Prefabs  
│  
├── Scenes  
│   ├── LoginScene  
│   ├── ProjectScene  
│   └── FloorScene  
│  
└── XR  
   └── XR Origin  
---

# **Setup Instructions**

## **Backend**

Install dependencies

npm install

Start the server

node server.js

The server runs at

http://localhost:3000  
---

## **Unity XR Application**

1. Open the project in **Unity**

2. Ensure **OpenXR and XR Interaction Toolkit** are enabled

3. Set the API base URL in `APIManager.cs`

4. Build the project for **Android (Meta Quest)**

---

# **Build Instructions**

1. Go to **File → Build Settings**

2. Select **Android**

3. Switch platform

4. Click **Build**

This generates an **APK file** compatible with Meta Quest devices.

---

# **Expected Result**

The final XR application allows a user to:

1. Log in to the system

2. Select a project

3. Choose a floor dynamically

All interactions occur within the **Meta Quest XR environment using controller ray interaction**.

---

# **Author**

Hrithik Kumar  
 Unity / XR Developer

