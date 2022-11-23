const passphrase = require("../components/passphrase");
const token = require("../components/token");
const DB = require("../components/db");
var db = new DB();

async function login(username, secret) {
    const user = await db.fetch(
        "select * from user where username = ?",
        [username]
    );
    if(user == null){
        return {
            status:401,
            data:undefined
        }
    }
    if(!passphrase.verify(secret, user.secret)) {
        return {
            status:401,
            data:undefined
        }
    }
    
    var newToken = await token.createToken(user.id, user.secret);

    return {
        status:200,
        data:newToken
    };
}

async function register(username, secret) {
    var search = await db.fetch("select * from user where username = ?", [username]);
    if(search != null) {
        return {
            status:404,
            data:null
        }
    }

    var hashed = passphrase.hash(secret);
    var user = await db.executeAndFetch("INSERT INTO user(username, secret) VALUES ( ? , ? )", [username, hashed]);
    if(user == null) {
        return {
            status:500,
            data:undefined
        }
    }
    return {
        status:200,
        data:user
    }
}

async function get(token) {
    var user = await getUserFromToken(token);
    if(user == null){
        return {
            status:401,
            data:undefined
        };
    }

    return {
        status:200,
        data:user
    };
}


async function getUserFromToken(token) {
    return await db.fetch("select user.* from user join token on token.user = user.id where token.value = ?", [token]);
}

module.exports = {
    login,
    register,
    get
}