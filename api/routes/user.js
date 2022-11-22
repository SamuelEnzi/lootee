const express = require("express");
const router = express.Router();
const user = require("../services/user");
const std = require("../components/std");

router.get("/get", async (req, res, next) => {
    const body = req.body;
    try {
        const limit = std.get(body.limit, 100);
        res.json(await user.get(limit));
    } catch (error) {
        next(error);
    }
});

router.post("/login", async (req, res, next) => {
    const body = req.body;
    try{
        const username = std.require(body.username);
        const secret = std.require(body.secret);
        const response = await user.login(username, secret);

        if(response != 200){
            res.statusCode = response;
            res.end();
        }
        res.end("login success");
    }catch (error) {
        next(error);
    }
});


module.exports = router;