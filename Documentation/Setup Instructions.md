# **Setup Instructions**

This document explains how to set up and run the **Meta Quest XR Application** and its backend server.

---

# **1\. Prerequisites**

Before running the project, make sure the following software is installed:

### **Unity**

Install **Unity Hub** and the following Unity version:

Unity 2022.3 LTS (recommended)

Required Unity modules:

Android Build Support  
Android SDK & NDK Tools  
OpenJDK

### **Node.js**

Install Node.js from:

https://nodejs.org

Check installation:

node \-v  
npm \-v

### **Meta Quest Setup**

Install:

Meta Quest Developer Hub  
Meta Quest Link / Air Link

Enable **Developer Mode** on the Meta Quest headset.

---

# **2\. Backend Setup**

Navigate to the backend folder:

cd Backend

Install dependencies:

npm install

Start the backend server:

node server.js

You should see:

Server running on port 3000

The backend APIs will now be available at:

http://localhost:3000  
---

# **3\. Backend API Endpoints**

### **Login API**

POST /api/login

Example request:

{  
"username": "testuser",  
"password": "123456"  
}

### **Project List API**

GET /api/projects

Returns the list of available projects.

### **Floors API**

GET /api/projects/{projectId}/floors

Returns floors for the selected project.

---

# **4\. Unity Project Setup**

Open Unity Hub.

Click:

Add Project

Select the folder:

UnityProject

Open the project.

---

# **5\. XR Setup**

Make sure the following XR settings are enabled:

### **XR Plugin Management**

Edit → Project Settings → XR Plugin Management

Enable:

OpenXR

### **Required Packages**

Install from **Package Manager**:

XR Interaction Toolkit  
Input System  
TextMeshPro  
---

# **6\. Running the Application in Unity**

Open the main scene.

Press:

Play

You should see the following flow:

Login Screen  
  ↓  
Project Selection Screen  
  ↓  
Floor Selection Screen  
---

# **7\. Building for Meta Quest**

Go to:

File → Build Settings

Select platform:

Android

Click:

Switch Platform

Then build the APK:

Build

The generated APK can be installed on the Meta Quest headset.

# **8\. Testing with Meta Quest**

Connect the headset using:

Meta Quest Link

or

USB Debugging

Install the APK using:

adb install XRApp.apk

Launch the application from the headset.

---

# **9\. Application Flow**

The XR application works as follows:

1. User logs in using credentials.

2. The system validates login using the backend API.

3. The user selects a project.

4. Floors are dynamically loaded from the backend.

5. The user selects a floor and confirms the selection.

Toast notifications provide feedback during each step.

---

# **10\. Troubleshooting**

### **Backend not responding**

Make sure the backend server is running:

node server.js  
---

### **Unity cannot connect to backend**

Ensure the API URL in `APIManager.cs` is correct.

Example:

http://localhost:3000

or the deployed server URL.

---

# **11\. Notes**

The backend uses **JWT authentication** and provides dynamic project and floor data for the XR application.

The frontend UI uses **XR Interaction Toolkit** with **controller ray interaction** to allow users to interact with the interface inside the VR environment.

