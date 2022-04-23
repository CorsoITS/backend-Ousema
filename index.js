require('dotenv').config();
const express = require('express');
const cors = require('cors')
const { json, urlencoded } = require('body-parser');
const { routerAuth } = require('./rotte/auth-router');
const { routerUtente } = require('./rotte/utente-router');
const routerPrenotazione = require('./rotte/prenotazione-router');
const app = express()

app.use(cors());
app.use(json());
app.use(urlencoded({ extended: true }));

app.options('*', cors())

app.use('/auth', routerAuth);
app.use('/utente',routerUtente);
app.use('/prenotazione',routerPrenotazione)

app.listen(3000);