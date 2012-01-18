# -*- coding: utf-8 -*-

from google.appengine.ext import db, blobstore
from tipfy.ext.db import EtagProperty, JsonProperty
  
class DCFUser(db.Model):
  name                    = db.StringProperty()
  lastname                = db.StringProperty()
  username                = db.StringProperty()
  legajo                  = db.StringProperty()
  turno                   = db.StringProperty()
  puesto                  = db.StringProperty()
  linea                   = db.StringProperty()
  is_admin                = db.BooleanProperty()
  is_super_admin          = db.BooleanProperty()