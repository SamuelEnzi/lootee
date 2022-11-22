const express = require("express");
const router = express.Router();
const user = require("../services/user");
const std = require("../components/std");

router.get("/hash/:value", async (req, res, next) => {
    try{
        const value = std.require(req.params.value);
        const response = await user.hash(value);
        res.json(response);
        res.end();
    }catch (error) {
        next(error);
    }
});

router.post("/login", async (req, res, next) => {
    const body = req.body;
    try{
        const username = std.require(body.username);
        const secret = std.require(body.secret);
        const response = await user.login(username, secret);
        console.log(response);
        res.statusCode = response.status;
        if(response.status != 200){
            res.end();
            return;
        }
        res.json(response.data);
        res.end();
    }catch (error) {
        next(error);
    }
});


module.exports = router;