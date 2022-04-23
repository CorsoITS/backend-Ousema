const { compare, hash } = require('bcryptjs');
const { randomUUID } = require('crypto');
const { getUtenteByUsername, insertUtente } = require('../model/dao/utente.dao');
const { persistToken, getTokenByUtente, validateToken, generateToken, deleteToken } = require('../model/dao/token.dao');
const {Token} = require('../model/models/token');


class authController{

    static async login(req,res){
        const { username, password } = req.body
        try{
            const utente = await getUtenteByUsername(username);
            const id_utente = utente.id
            if (await compare(password, utente.password)) {
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
                        const del = await deleteToken(token.token)
                        token = await generateToken(id_utente)
                        return res.json({

                            token: token

                        }).send()
            }}} 
        } catch(err) {
            console.log(err)
            return res.status(404).json({
            messaggio: 'Qualcosa è andato storto',
            errore: err
        })}}


    static async register(req,res){
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
            })}
    
    static async controllaAutenticazione(req, res, next) {
        const header = req.headers['authorization'];
        if (!header) {
            return res.status(401).json({
            messaggio: 'metti header per favore'
            })
        }
        const [bearer, token] = header.split(' ');
        if (bearer !== 'Bearer' || !token || token.lenth === 0) {
            return res.status(401).json({
            messaggio: 'metti header per bene per favore'
            })
        }
        const validity = await validateToken(token)
        if (validity) {
            next();
        }
        return res.status(403).json({
            messaggio: 'token non valido'
        })}

    static async getSede(req,res,next){
        
    }
}

module.exports={authController}