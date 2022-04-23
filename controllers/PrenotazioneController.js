const { getSedeById } = require("../model/dao/utente.dao");
const Prenotazione = require("../model/models/Prenotazione");



class PrenotazioneController {

    static async lista (req , res){

        const utente_id = req.body.utente_id
        const sede_id = await getSedeById(utente_id)
        let result=await Prenotazione.lista(sede_id);
        return res.json(result);
        
        
    } 
    static async elimina (req,res) {
        try {
            if (await Prenotazione.delete(req.params.id_prenotazione) ) {
            res.status(200).send('Ok');
            } else {
                res.status(400).send ("Errore Cancellazione Prenotazione");
            }
        } catch (err) {
            res.status(500).send ("Internal Server Error");
        }
    }

    static async get (req,res) {
        let result;
        if (req.params.id) {
            result=await Prenotazione.get(req.params.id);
        } else {
            result = req.Prenotazione;
        }
            return res.json(result);
    }
}

module.exports=PrenotazioneController;