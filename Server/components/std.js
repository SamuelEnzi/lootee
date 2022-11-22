function get(value, def) {
    if(value == undefined || value == null){
        return def;
    }
    return value;
}

function require(value) {
    if(value == undefined || value == null){
        throw new Error("missing requirement");
    }
    return value;
}

module.exports = {
    get,
    require
};