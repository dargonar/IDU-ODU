# -*- coding: utf-8 -*-
"""
Handlers Python - Frontend App.
"""

from google.appengine.ext import db, blobstore

from tipfy import RequestHandler, Response, redirect, render_json_response, cached_property, abort, url_for
from tipfy.ext.session import SessionMiddleware, SessionMixin, CookieMixin
from tipfy.ext.jinja2 import render_response, render_template, Jinja2Mixin, get_jinja2_instance

from models import *

"""
from tipfy import RequestHandler, Response, redirect, render_json_response, cached_property, abort, url_for
from tipfy.ext.session import SessionMiddleware, SessionMixin, CookieMixin
from tipfy.ext.jinja2 import render_response, render_template, Jinja2Mixin, get_jinja2_instance

from tipfy.ext.auth import MultiAuthMixin, login_required, user_required
from tipfy.ext.auth.facebook import FacebookMixin
from tipfy.ext.auth.twitter import TwitterMixin
from facebook.facebookpy import *

from google.appengine.api import mail
from google.appengine.api import channel

from uuid import uuid4
import sys, urllib, logging, string # , json
from django.utils import simplejson
from datetime import date, datetime , timedelta
from google.appengine.ext import db, blobstore
from google.appengine.api import images, urlfetch
from google.appengine.ext import deferred
from tipfy.ext.taskqueue import Mapper
"""

#====================================#
#                                    #
#      Index / Sessions / Reg        # 
#                                    #
#====================================#
class IduOduLoader(RequestHandler):
  def get(self, **kwargs):
    
    query = DCFUser.all()
    entries =query.fetch(1000)
    db.delete(entries)
    
    users = []
    users.append(['34',u'Bepre',u'Rafael',u'SUPERVISOR',u'ODU',u'Mañana', False, False])
    users.append(['219',u'Puebla',u'Carlos',u'BOMBAS DE VACIO',u'ODU',u'Mañana', False, False])
    users.append(['334',u'Carrion',u'Matias',u'CARGADORA',u'ODU',u'Mañana', False, False])
    users.append(['56',u'Robles',u'Victor',u'LEAK TEST',u'ODU',u'Mañana', False, False])
    users.append(['58',u'Ansaldi',u'Aldo',u'REPARACIONES',u'ODU',u'Mañana', False, False])
    users.append(['67',u'García',u'Fernando',u'HIGH POT',u'ODU',u'Mañana', False, False])
    users.append(['51',u'Amaya',u'Leonel',u'RUN TEST',u'ODU',u'Mañana', False, False])
    users.append(['46',u'Moglie',u'Sebastian',u'RUN TEST',u'ODU',u'Mañana', False, False])
    users.append(['28',u'Campostrini',u'Hugo',u'RUN TEST',u'ODU',u'Mañana', False, False])
    users.append(['115',u'Navarrete',u'Martin',u'SUPERVISOR',u'ODU',u'Tarde', False, False])
    users.append(['129',u'Aguilar',u'Marcelo',u'BOMBAS DE VACIO',u'ODU',u'Tarde', False, False])
    users.append(['324',u'Vega',u'Emanuel',u'CARGADORA',u'ODU',u'Tarde', False, False])
    users.append(['251',u'Maldonado',u'Hugo',u'LEAK TEST',u'ODU',u'Tarde', False, False])
    users.append(['304',u'Godoy',u'Daniel',u'HIGH POT',u'ODU',u'Tarde', False, False])
    users.append(['27',u'Alves',u'Sergio',u'RUN TEST',u'ODU',u'Tarde', False, False])
    users.append(['247',u'De La Cruz',u'Daniel',u'RUN TEST',u'ODU',u'Tarde', False, False])
    users.append(['120',u'Knorr',u'Alexis',u'RUN TEST',u'ODU',u'Tarde', False, False])
    users.append(['58',u'Andino',u'Martin',u'REPARACIONES',u'ODU',u'Tarde', False, False])
    users.append(['20',u'Pereda',u'Jorge',u'SUPERVISOR',u'IDU',u'Mañana', False, False])
    users.append(['131',u'Riveros',u'Nelson',u'LEAK TEST',u'IDU',u'Mañana', False, False])
    users.append(['261',u'Dupuy',u'Hugo',u'HIGH POT',u'IDU',u'Mañana', False, False])
    users.append(['277',u'Villafañe',u'',u'HIGH POT',u'IDU',u'Mañana', False, False])
    users.append(['265',u'Romero',u'Claudio',u'RUN TEST',u'IDU',u'Mañana', False, False])
    users.append(['249',u'Lelles',u'Gabriel',u'RUN TEST',u'IDU',u'Mañana', False, False])
    users.append(['26',u'Fernandez',u'Marcelo',u'REPARACIONES',u'IDU',u'Mañana', False, False])
    users.append(['96',u'Fernandez',u'Jose Luis',u'SUPERVISOR',u'IDU',u'Tarde', False, False])
    users.append(['122',u'Perez',u'Pablo',u'LEAK TEST',u'IDU',u'Tarde', False, False])
    users.append(['108',u'Tejeda',u'Gonzalo',u'RUN TEST',u'IDU',u'Tarde', False, False])
    users.append(['116',u'Gallo',u'Gabriel',u'RUN TEST',u'IDU',u'Tarde', False, False])
    users.append(['284',u'Rolon',u'Sebastian',u'HIGH POT',u'IDU',u'Tarde', False, False])
    users.append(['94',u'Espeche',u'Miguel',u'REPARACIONES',u'IDU',u'Tarde', False, False])
    
    users.append(['30',u'Villa',u'Gabriel',u'ND',u'ND',u'ND', True, False])
    users.append(['98',u'Blanco',u'Sebastián',u'ND',u'ND',u'ND', True, False])
    users.append(['213',u'Bellani',u'Oscar',u'ND',u'ND',u'ND', True, True])
    users.append(['113',u'Silva',u'Patricio',u'ND',u'ND',u'ND', True, True])
     
    for user in users:
      dcf_user = DCFUser()
      dcf_user.legajo                   = user[0]
      dcf_user.name                     = user[2]
      dcf_user.lastname                 = user[1]
      if len(dcf_user.name)>0:
        dcf_user.username                 = "%s%s" % (user[2].lower()[0], user[1].lower())
      else:
        dcf_user.username                 = "%s" % user[1].lower()
      dcf_user.turno                    = user[5]
      dcf_user.puesto                   = user[3]
      dcf_user.linea                    = user[4]
      dcf_user.is_admin                 = user[6]
      dcf_user.is_super_admin           = user[7]
      
      dcf_user.save()
    
    return Response('DCFUsers Loaded!')
    
class Profiles(RequestHandler):
  def get(self, **kwargs):
    query = DCFUser.all()
    users = query.fetch(1000)
    return render_response('frontend/userprofile.html', users=users)
      
class SFGuardUsers(RequestHandler):
  def get(self, **kwargs):
    query = DCFUser.all()
    users = query.fetch(1000)
    return render_response('frontend/sfguard.html', users=users)
    