const { Router } = require('express');
const { getUtenteById } = require('../model/dao/utente.dao');
const routerUtente = Router();

routerUtente.get('/', async (req,res) => {
    const id_utente = req.body.id_utente
    const utente = await getUtenteById(id_utente)
    res.json({
        utente
    }).send()
})

module.exports={routerUtente}