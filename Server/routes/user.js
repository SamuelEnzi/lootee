const express = require("express");
const router = express.Router();
const user = require("../services/user");
const std = require("../components/std");

router.post("/login", async (req, res, next) => {
    const body = req.body;
    try{
        const username = std.require(body.username);
        const secret = std.require(body.secret);
        const response = await user.login(username, secret);
        res.statusCode = response.status;
        if(response.status != 200){
            res.end();
            return;
        }
        res.json({
            token:response.data
        });
        res.end();
    }catch (error) {
        next(error);
    }
});

router.post("/register", async (req, res, next) => {
    const body = req.body;
    try{
        const username = std.require(body.username);
        const secret = std.require(body.secret);
        const response = await user.register(username, secret);
        res.statusCode = response.status;
        if(response.status != 200){
            res.end();
            return;
        }
        res.json({
            user:response.data
        });
        res.end();
    }catch (error) {
        next(error);
    }
});

router.get("/", async (req, res, next) => {
    try{
        const token = std.require(req.headers["token"]);
        const response = await user.get(token);
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