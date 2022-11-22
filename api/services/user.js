const DB = require("../components/db");
var db = new DB();

async function get(amount = 100) {
    const rows = await db.fetchAll(
        'SELECT * from user limit ?',
        [amount]
    );
    const data = rows;
    return {
        data
    };
}

async function login(username, secret) {
    const user = await db.fetch(
        "select * from user where username = ?",
        [username]
    );
    if(user == null || user.secret != secret) {
        return 401;
    }
    return 200;
}

module.exports = {
    get,
    login
}