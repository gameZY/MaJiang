# coding:utf8

from web.common.globalobject import GlobalObject
from sqlalchemy import Column,Integer,String,VARCHAR,DateTime,Boolean

class TbUser(GlobalObject().BaseModel):
    __tablename__ = 'tb_user'

    uid = Column(Integer,primary_key=True,autoincrement=True)
    deviceid = Column(VARCHAR(200),default=1)
    username = Column(VARCHAR(200),default=1)
    regtime = Column(DateTime)