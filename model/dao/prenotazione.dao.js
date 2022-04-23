const { getConnection } = require("../../connessione/connessione");


const listPrenotazione = async (sede_id) => {
  const connection = await getConnection();
  let query=`SELECT prenotazione.*, 
                    sede.id as post_id, sede.citta ,
                    persona.nome, persona.cognome, persona.codice_fiscale
                    FROM prenotazione  
                LEFT JOIN sede ON prenotazione.sede_id = sede.id
                LEFT JOIN persona ON prenotazione.persona_id = persona.id
                WHERE sede.id = ?
     `;

  const [rows] = await connection.query(query,[sede_id]);
  return rows;
}

const prenotazioneExistById = async (id_prenotazione) => {
  const connection = await getConnection();
  const query = 'SELECT 1 FROM prenotazione WHERE id = ?';
  const [rows] = await connection.query(query, [id_prenotazione]);
  return rows.length > 0;
}

const getPrenotazioneById = async (id_prenotazione) => {
  const connection = await getConnection();
  let query=`SELECT prenotazione.*, 
              sede.id as post_id, sede.citta ,
              persona.nome, persona.cognome, persona.codice_fiscale
              FROM prenotazione  
              LEFT JOIN sede ON prenotazione.sede_id = sede.id
              LEFT JOIN persona    ON prenotazione.persona_id = persona.id 
              WHERE prenotazione.id = ?
`
  const [rows] = await connection.query(query, [id_prenotazione]);
  return rows[0];
}
// ALT + 0 0 9 6 => `
const insertPrenotazione = async (persona_id, postazione_id, somministrazione_id=null) => {
  const connection = await getConnection();
  const query = `INSERT INTO prenotazione (persona_id, somministrazione_id, postazione_id) VALUES (?,?,?)`;
  const [res] = await connection.query(query, [persona_id, somministrazione_id, postazione_id]);
  return res.insertId;
}

const updatePrenotazione = async (id, persona_id, postazione_id,somministrazione_id=null) => {
  const connection = await getConnection();
  const query = `UPDATE prenotazione SET persona_id = ?, somministrazione_id = ?, postazione_id= ? WHERE id = ?`;
  const [res] = await connection.query(query, [persona_id, somministrazione_id, postazione_id, id]);
  return res.affectedRows === 1;
}

const prenotazioneDeleteById = async (id_prenotazione) => {
  const connection = await getConnection();
  const query = 'DELETE FROM prenotazione WHERE id = ?';
  const [res] = await connection.query(query, [id_prenotazione]);
  logger.debug('Query:' + query);
  return res.affectedRows === 1;;
}

module.exports = {
  listPrenotazione,
  prenotazioneExistById,
  getPrenotazioneById,
  insertPrenotazione,
  updatePrenotazione,
  prenotazioneDeleteById
}