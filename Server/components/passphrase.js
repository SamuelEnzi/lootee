const crypto = require('crypto');

function verify(password, hashvalue){
    var hashed = hash(password);
    return hashed == hashvalue;
}

function hash(password) {
    return crypto.pbkdf2Sync(password, "69", 10, 64, 'sha512').toString('hex');
}

module.exports = {
    hash,
    verify
}