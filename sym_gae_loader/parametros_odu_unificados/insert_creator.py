# -*- coding: utf-8 -*-
# set PYTHONPATH=%PYTHONPATH%;C:\Program Files (x86)\Google\google_appengine
from __future__ import absolute_import
from datetime import date, datetime , timedelta

import inspect,os,sys
mydir = os.path.dirname( inspect.currentframe().f_code.co_filename )
gpath = r'c:\Program Files (x86)'
sys.path[0:0] = [r'%s\Google\google_appengine\lib\django'%gpath, \
                 r'%s\Google\google_appengine\lib\yaml\lib'%gpath, \
                 r'%s\Google\google_appengine'%gpath,\
                mydir+r'\..\src\lib', mydir+r'\..\src\distlib']
print sys.path

import codecs
import random 
import csv
import sys

# from google.appengine.ext import db
# from models import Property, PropertyIndex, RealEstate
# from search_helper import config_array, alphabet, calculate_price


fout = open('inserts.sql', "w")
csvout  = csv.writer(fout, delimiter=',', quotechar='"', lineterminator='\n')

parameters_fields = []

parameters_fields.append(u'%s' % unicode(key))

csvreader = csv.reader(open('parameters.csv', 'r'), delimiter=',', quotechar='"')
    
for row in csvreader:
  
  row = map(lambda x: x.decode('utf-8'), row)
  
  if len(parameters_fields)<1:
    parameters_fields
    continue
  
  arr = []
  
  #KEY
  
  arr.append( str(int(tryint(row[cnames.index("INM_Id")])))) 
  arr.append( '' )
  arr.append( row[cnames.index("INM_Nombre")]) 
  arr.append( row[cnames.index("INM_Url")] )
  arr.append( row[cnames.index("INM_Email")] )
  arr.append( '' )
  arr.append( row[cnames.index("INM_Fax")] )
  arr.append( row[cnames.index("INM_Telefono")] )
  arr.append( '' )
  arr.append( row[cnames.index("INM_Direccion")] )
  arr.append( '' )
  arr.append( '1' )
  
  
  csvout.writerow( map(lambda x: x.encode('utf8'), arr) )

fout.close()