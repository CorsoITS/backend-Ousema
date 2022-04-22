const { Router } = require('express');
const { compare, hash } = require('bcryptjs');
const { randomUUID } = require('crypto');
const { getUtenteByUsername, insertUtente } = require('../model/dao/utente.dao');
const { persistToken, getTokenByUtente, validateToken, generateToken } = require('../model/dao/token.dao');
const {Token} = require('../model/models/token');


const routerAuth = Router();

routerAuth.get('/token', async (req, res) => {
  const {id} = req.body
  const token = await getTokenByUtente(id)
  return res.send(token)
})

routerAuth.get('/validate', async (req, res) => {
  const {token} = req.body
  const validate = await validateToken(token)
  return res.send(validate)
})

routerAuth.post('/login', async (req, res) => {
  const { username, password } = req.body
  try{
    const utente = await getUtenteByUsername(username);
    const id_utente = utente.getId()
    if (await compare(password, utente.getPassword())) {
      let token = await getTokenByUtente(id_utente);
      if(token == null){
        let token = await generateToken(id_utente)
        return res.json({
          token: token
        }).send()
      }else{
        const validity = await validateToken(token.token)
        if(validity){
          return res.json({
           token:  token.token
          }).send()
        }else{
          let token = await generateToken(id_utente)
          return res.json({
            token: token
          }).send()
      }}} 
      } catch(err) {
          return res.status(404).json({
          messaggio: 'non ti conosco',
          errore: err
      })
  }
});

routerAuth.post('/register', async (req, res) => {
  const { name, lastname, username, password, role } = req.body;
  if (password.length < 3) {
    return res.status(400).send({
      message: 'la password deve essere più lunga di 3 caratteri'
    })
  }
  const exist = await getUtenteByUsername(username);
  if(!exist){
    const passwordHash = await hash(password, 10);
    const re = await insertUtente(name, lastname, username, passwordHash, role);
    if (re)
      return res.json({
        messaggio: "Registrazione effettuata con successo"
      });
    else return res.json({
      messaggio: "Qualcosa è andato storto"
    })
    }
    
    else return res.json({
      messaggio: "Nome utente già esistente"
    })

})

module.exports = {
  routerAuth
};