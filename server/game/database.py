#coding=utf-8

from sqlalchemy import *
from sqlalchemy.orm import *
from sqlalchemy.pool import NullPool
from manager.GlobalManager import GlobalManager
from sqlalchemy.ext.declarative import declarative_base

SQLALCHEMY_DATABASE_URI = 'mysql://root:zhouhang@127.0.0.1:3306/chess?charset=utf8'

 #创建Mysql连接
db = create_engine(SQLALCHEMY_DATABASE_URI,encoding='utf-8',echo=False,poolclass=NullPool)
metadata = MetaData(db)
Session = sessionmaker(bind=db)
GlobalManager().db = db
GlobalManager().Session = Session
GlobalManager().BaseModel = declarative_base()

import model

GlobalManager().createTables()