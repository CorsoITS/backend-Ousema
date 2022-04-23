const { Router } = require('express');
const { authController } = require('../controllers/Auth-controller');


const routerAuth = Router();


routerAuth.post('/login',authController.login)
routerAuth.post('/register',authController.register)

module.exports = {
  routerAuth
};


// //test
// routerAuth.get('/token', async (req, res) => {
//   const {id} = req.body
//   const token = await getTokenByUtente(id)
//   return res.send(token)
// })

// //test
// routerAuth.get('/validate', async (req, res) => {
//   const {token} = req.body
//   const validate = await validateToken(token)
//   return res.send(validate)
// })

// //test
// routerAuth.delete('/token', async (req,res)=>{
//   const {token} = req.body
//   const del = await deleteToken(token)
//   if (del){
//     res.json({
//       messaggio:"cancellazione riuscita"
//     }).send()}
//   else{
//     res.json({
//       messaggio:"qualcosa e andato storto"
//     }).send()
//   }
// })