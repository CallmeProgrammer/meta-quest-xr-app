const express = require("express");
const cors = require("cors");
const jwt = require("jsonwebtoken");

const app = express();
app.use(cors());
app.use(express.json());

const SECRET = "xr_secret_key";

/*
LOGIN API
*/

app.post("/api/login", (req, res) => {

    const { username, password } = req.body;

    if (username !== "testuser") {
        return res.json({
            success: false,
            error: "username"
        });
    }

    if (password !== "123456") {
        return res.json({
            success: false,
            error: "password"
        });
    }

    const token = jwt.sign(
        { id: 1, name: "Test User" },
        SECRET
    );

    res.json({
        success: true,
        token: token,
        user: {
            id: 1,
            name: "Test User"
        }
    });

});

/*
PROJECT LIST API
*/
app.get("/api/projects", (req, res) => {

    res.json({
        projects: [
            { id: 1, name: "Project A" },
            { id: 2, name: "Project B" },
            { id: 3, name: "Project C" },
            { id: 4, name: "Project D" }
        ]
    });

});


/*
FLOORS API
*/
app.get("/api/projects/:id/floors", (req, res) => {

    const projectId = req.params.id;

    let floors = [];

    if (projectId == 1)
        floors = ["Floor 1", "Floor 2", "Floor 3", "Floor 4"];

    if (projectId == 2)
        floors = ["Floor A", "Floor B"];

    if (projectId == 3)
        floors = ["Ground", "1", "2", "3", "4", "5"];

    if (projectId == 4)
        floors = ["Basement", "Ground", "Mezzanine"];

    res.json({ floors });

});


app.listen(3000, () => {
    console.log("Server running on port 3000");
});
