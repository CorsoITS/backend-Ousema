const { listToken, getTokenByUtente, validateToken} = require("../dao/token.dao");

class Token{
    constructor(rawToken){
        this.num = rawToken.token,
        this.operatore_id = rawToken.operatore_id,
        this.exp = rawToken.exp,
        this.remind_me = rawToken.remind_me
    }   

    static async lista (pag) {
        let listaTokenDAO=await listToken();
        let res=[];
        listaTokenDAO.forEach(e =>{
          res.push(new Token(e))
      }) 
      return res;
    }

    async getTokenByOperatoreId(id){
        let tk = getTokenByUtente(id)
        if (tk) return tk
        return null
    }

    async checkTokenValidity(token){
        let validity = validateToken(token)
        if (validity) return true
    }
}

module.exports={Token}