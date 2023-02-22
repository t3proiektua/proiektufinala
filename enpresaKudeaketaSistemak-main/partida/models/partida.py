# -*- coding: utf-8 -*- 
# Part of Odoo. See LICENSE file for full copyright and licensing details. 
from odoo import api, fields, models 
from datetime import datetime 

class partida(models.Model): 
    _name = 'partida'
    id = fields.Integer(string='id', required=True) 
    erabiltzailea = fields.Text(string='erabiltzailea', required=True)
    data = fields.Datetime(string='data', required=True) 
    puntuazioa = fields.Float(string='puntuazioa', required=True) 
