const crypto = require('crypto');
const DB = require('./db');
const db = new DB();

async function createToken (userid, secret) {
    var token = await db.fetch(`select * from token where user = ? `, [userid]);
    if(token != null) {
        return token.value;
    }
    var random = Math.random()* 1000;
    var newToken = hash(`${userid}${secret}${random}`);
    
    await db.execute("INSERT INTO token (user, value) VALUES ( ? , ? )", [userid, newToken]);
    return newToken;
}

function hash(value) {
    return crypto.createHash('md5').update(value).digest('hex');
}

module.exports = {
    createToken
}