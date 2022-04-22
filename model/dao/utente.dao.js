const { getConnection } = require('../../connessione/connessione');
const { Utente } = require("../models/utente");

async function getUtenteByUsername(username) {
    const connection = await getConnection();
    const [utenti] =await connection.query('SELECT * FROM operatore WHERE username = ?',[username])
    if (utenti.length >0) return new Utente(utenti[0]);
    else return false


}

async function getUtenteById(id) {
    const conn = await getConnection();
    const [utenti] = await conn.query('SELECT * FROM operatore WHERE id = ?', [id]);
    return new Utente(utenti[0]);
}

async function insertUtente(name, lastname,username, passwordHash, role) {
    const conn = await getConnection();
    const [insert] = await conn.query(
      'INSERT INTO operatore (nome, cognome, username, password, ruolo) values (?, ?, ?, ?, ?)',
      [name, lastname,username, passwordHash, role]);
    return insert.insertId;
}
module.exports={
    getUtenteByUsername,
    getUtenteById,
    insertUtente
}