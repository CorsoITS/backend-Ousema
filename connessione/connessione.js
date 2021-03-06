const mysql = require('mysql2/promise');
const config= require('config');

const createConnection = async () => {
  return await mysql.createConnection({
    host: "localhost",
    user: process.env.MYSQL_USER,
    password: process.env.MYSQL_PASSWORD,
    database: 'piattaforma_vaccini_v2'
  });
}

let connection;
const getConnection = async () => {
  if(!connection) {
    connection = await createConnection();
  }

  return connection;
}

module.exports = {
  createConnection,
  getConnection
}