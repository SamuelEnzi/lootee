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

async function hash(password){
    return passphrase.hash(password);
}

module.exports = {
    login,
    hash
}