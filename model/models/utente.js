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
}

module.exports = {Utente};