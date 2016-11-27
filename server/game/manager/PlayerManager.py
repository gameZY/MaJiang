#coding:utf8

from twisted.python import log

from game.core.single.singleton import Singleton
from game.classes.player.Player import Player
from game.model.TbPlayer import TbPlayer
from game.manager.ThreadManager import ThreadManager
from game.manager.PkSceneManager import PkSceneManager

import time

class PlayerManager:
    '''玩家管理器'''
    __metaclass__ = Singleton

    def __init__(self):
        self.players = {}

    def loadAllPlayers(self):
        #加载所有的玩家数据
        tbPlayers = TbPlayer.selectAll()
        for tbPlayer in tbPlayers:
            player = Player()
            player.uid = tbPlayer.uid
            player.username = tbPlayer.username
            self.players[tbPlayer.uid] = player

    def addPlayer(self,player):
        """添加一个玩家"""
        self.players[player.uid] = player
        sessionno = player.conn.transport.sessionno
        log.msg('Client %d User %s login from %s' % (sessionno,player.username,player.conn.transport.client[0]))

    def dropUserByConn(self,conn):
        '''根据用户连接对象处理用户下线'''
        try:
            player = self.getPlayerByConn(conn)
            if(player):
                if(player.state != 0):
                    PkSceneManager().removePkPlayer(player)
                if(player.conn != None):
                    sessionno = player.conn.transport.sessionno
                    address = player.conn.transport.client[0]
                    player.conn = None
                player.isOnline = False
                player.pkPlayer = None
                self.updateTbPlayer(player)
                log.msg('Client %d User %s logout from %s' % (sessionno,player.username,address))
            else:
                log.msg("Client %s has none")
        except Exception,e:
            print e

    #获取所有在线用户的个数
    def getAllPlayersNum(self):
        return len(self.players)

    #根据名字获取指定玩家
    def getPlayerByName(self,username):
        for key in self.players:
            if username == self.players[key].username:
                return self.players[key]
        return None

    #根据uid获取玩家
    def getPlayerByUid(self,uid):
        if(self.players.has_key(uid)):
            return self.players[uid]
        return None

    #分局连接获取指定玩家
    def getPlayerByConn(self,conn):
        for key in self.players:
            if conn == self.players[key].conn:
                return self.players[key]
        return None

    #获取所有在线的玩家
    def getAllOnlinePlayers(self):
        onlinePlayers = []
        for key in self.players:
            player = self.players[key]
            if(player.isOnline):
                onlinePlayers.append(player)
        return onlinePlayers

     #每隔60秒检测心跳
    def heartCheck(self):
        _now = time.time()
        keys = []
        for key in self.players:
            _player = self.players[key]
            if(_player.heartTime != None and _player.isOnline):
                if(_now - _player.heartTime >= 60):
                    keys.append(key)
        for key in keys:
            _player = self.players[key]
            _player.conn.terminate()

    #插入玩家数据
    def insertTbPlayer(self,player):
        player.operation = "insert"
        ThreadManager().playerThread.addExcuteQueue(player)

    #插入玩家数据
    def updateTbPlayer(self,player):
        player.operation = "update"
        ThreadManager().playerThread.addExcuteQueue(player)