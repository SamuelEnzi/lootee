const mysql = require('mysql2/promise');
const config = require('../config');

module.exports = class DB {
    constructor(){
        this.connect();
    }

    async connect(){
        this.pool = await mysql.createPool(config.db);
    }

    //fetches a array from db
    async fetchAll(sql, params) {
        const [results, ] = await this.pool.query(sql, params);
        if(!results) {
            return null;
        }
        return results;
    }

    //fetches only first result
    async fetch(sql, params) {
        const [results, ] = await this.pool.query(sql, params);
        if(!results || results.length <= 0) {
            return null;
        }
        return results[0];
    }

    async execute(sql, params) {
        await this.pool.execute(sql, params);
    }

    async executeAndFetch(sql, params) {
        var result = await this.pool.execute(sql, params);
        try{
            return result[0].insertId;
        }catch (err) {
            return null;
        }
    }
}

