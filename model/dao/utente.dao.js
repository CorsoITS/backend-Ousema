const { getConnection } = require('../../connessione/connessione');
const { Utente } = require("../models/utente");

async function getUtenteByUsername(username) {
    const connection = await getConnection();
    const [utenti] =await connection.query('SELECT * FROM operatore WHERE username = ?',[username])
    if (utenti.length >0) return new Utente(utenti[0]);
    else return false


}
const listUtente = async (pag) => {
    const connection = await getConnection();
    let numres=config.get('max-results-per-page');
    let query='SELECT * FROM operatore'
    if (pag>0){
      let start=(pag-1)*numres;
      query +=' LIMIT '+numres+' OFFSET '+start;
    }
    const [rows] = await connection.query(query);
  
    return rows;
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

async function utenteExistById(id_utente){
    const connection = await getConnection();
    const query = 'SELECT 1 FROM operatore WHERE id = ?';
    const [rows] = await connection.query(query, [id_utente]);
    return rows.length > 0;

}

async function utenteDeleteById(id_utente){
    const connection = await getConnection();
    const query = 'DELETE FROM operatore WHERE id = ?';
    const [res] = await connection.query(query, [id_utente]);
    return res.affectedRows === 1;
}

const updateCampiUtente = async (id, nome, cognome, username, password, ruolo, sede_id) => {
    const connection = await getConnection();
    const campi = [];
    const params = [];
    if (nome !== undefined) {
      campi.push('nome');
      params.push(nome);
    }
    if (cognome !== undefined) {
      campi.push('cognome');
      params.push(cognome);
    }
    if (username !== undefined) {
      campi.push('username');
      params.push(username);
    }
    if (password !== undefined) {
        campi.push('password');
        params.push(password);
    }
    if (ruolo !== undefined) {
    campi.push('ruolo');
    params.push(ruolo);
    }
    if (sede_id !== undefined) {
    campi.push('sede_id');
    params.push(sede_id);
    }

    params.push(id);
    const query = `UPDATE persona SET ${campi.map(campo => campo + ` = ?`).join(',')} WHERE id = ?`;
    const [res] = await connection.query(query, params);
    return res.affectedRows === 1;
  }

module.exports={
    getUtenteByUsername,
    listUtente,
    getUtenteById,
    insertUtente,
    utenteExistById,
    utenteDeleteById,
    updateCampiUtente
}