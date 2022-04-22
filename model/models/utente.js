const { listUtente, updateCampiUtente } = require("../dao/utente.dao");

class Utente {

  constructor(rawUtente)  {
    this.id = rawUtente.id;
    this.username = rawUtente.username;
    this.password = rawUtente.password;
    this.nome = rawUtente.nome;
    this.cognome = rawUtente.cognome;
    this.ruolo = rawUtente.ruolo;
    this.sedeId = rawUtente.sede_id
  }
  getPublicFields() {
    return {
      id: this.id,
      username: this.username,
      nome: this.nome,
      cognome: this.cognome,
      ruolo: this.ruolo,
    }
  }
  static async lista (pag) {
    let listaUtenteDAO=await listUtente(pag);
    let res=[];
    listaUtenteDAO.forEach(e =>{
      res.push(new Utente(e))
  }) 
  return res;
}

  static async get(id) {
      let ut=await getUtenteById(id);
      if (ut) { return ut}
      return null;
  }

  static async exists(id) {
      return await utenteExistById(id);
  }

  static async delete(id) {
      return await utenteDeleteById(id);
  }


  setId(x) {
      if (x == null || typeof(x) == 'undefined')  throw 'Id cannot be null';
      this.id=x;
  }
  getId() {
      return this.id;
  }

  existId () {
      if (this.id == null || typeof(this.id) == 'undefined') return false;
      return true; 
  }
  setNome(x) {
      if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
      this.nome=x;
  }
  getNome() {
      return this.nome;
  }

  setCognome(x) {
      if (x == null || typeof(x) == 'undefined')  throw 'Cognome cannot be null';
      this.cognome=x;
  }
  getCognome() {
      return this.cognome;
  }

  setUsername(x) {
      this.username=x;

  }
  getUsername() {
      return this.username;
  }

  setPassword(x) {
    this.password=x;

  }
  getPassword() {
      return this.password;
  }

  setRuolo (x) {
      this.ruolo=x;
  }
  getRuolo() {
      return this.ruolo;
  }

  setSedeId (x) {
      this.sedeId=x;
  }
  getSedeId () {
      return this.sedeId;
  }

  async save() {
      if (typeof (this.id) != 'undefined' && this.id != null ) {
          // id e' definito quindi dobbiamo aggiornare il recordo della persona
          let res= await updateCampiUtente (this.id, this.nome, this.cognome, this.username, this.password, this.ruolo, this.sedeId);
          if (! res) throw 'save Persona failed (update case).'; 
      } else {
          // id non e' definito quindi dobbiamo creare un nuovo record
          let res= await insertPersona (this.nome, this.cognome, this.CodFis, this.date, this.TS);
          this.setId(res);
          if (! res) throw 'save Persona failed (insert case).'; 
      }
  }

}

module.exports = {Utente};