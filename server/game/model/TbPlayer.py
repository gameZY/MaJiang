# coding:utf8

from game.manager.GlobalManager import GlobalManager
from sqlalchemy import Column,Integer,String,VARCHAR,Boolean
from twisted.python import log
import json,time

class TbPlayer(GlobalManager().BaseModel):
    __tablename__ = 'tb_player'

    #玩家的uid
    uid = Column(Integer,primary_key=True,autoincrement=False)
    #玩家的昵称
    username = Column(VARCHAR(200))
    #玩家金币
    gold = Column(Integer)
    #玩家钻石
    diamond = Column(Integer)

    #获取所有的Player
    @staticmethod
    def selectAll():
        startTime = time.time()
        session = GlobalManager.Session()
        query = session.query(TbPlayer)
        tbplayers = query.all()
        session.close()
        log.msg("select all players data spend "+str(time.time() - startTime))
        return tbplayers

    #根据uid获取tbPlayer
    @staticmethod
    def selectByUid(uid):
        session = GlobalManager.Session()
        query = session.query(TbPlayer)
        tbPlayer = query.filter_by(uid=uid).first()
        session.close()
        return tbPlayer

    #插入tbPlayer
    @staticmethod
    def insert(player):
        session = GlobalManager.Session()
        tbPlayer = TbPlayer()
        tbPlayer.uid = player.uid
        tbPlayer.username = player.username
        session.add(tbPlayer)
        session.commit()
        session.close()
        log.msg("db insert player "+player.username)

    #更新tbPlayer
    @staticmethod
    def update(player):
        session = GlobalManager.Session()
        query = session.query(TbPlayer)
        tbPlayer = query.filter_by(uid=player.uid).first()
        session.commit()
        session.close()
        log.msg("db update player "+player.username)