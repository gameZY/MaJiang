#coding:utf8

from game.core.single.singleton import Singleton
from game.classes.pk.PKScene import *
from game.classes.pk.PkPai import *
from game.message.PkMessage import PkMessage

class PkSceneManager:
    '''游戏场景管理器'''
    __metaclass__ = Singleton

    #在进入pk中的玩家
    players = {}

    def __init__(self):
        '''初始化'''
        self.scenes = {}
        self.players = {}

    '''玩家进入游戏匹配'''
    def addPkPlayer(self,player):
        if(self.players.has_key(player.uid) == False):
            player.state = 1;
            self.players[player.uid] = player
            return True
        return False

    '''移除玩家匹配'''
    def removePkPlayer(self,player):
        if(self.players.has_key(player.uid) == True):
            self.players.pop(player.uid)

    '''设置玩家游戏中的状态'''
    def setPlayerState(self,player):
        sceneId = player.pkPlayer.sceneId
        scene = self.scenes[sceneId];
        scene.setPkPlayerState(player.pkPlayer.pos,1)

    '''增加pk场景'''
    def addScene(self,sceneId,players):
        scene = PkScene(sceneId,players)
        self.scenes[scene.sceneId] = scene
        PkMessage().sendEnterGameResponse(scene)
        return scene

    '''移除pk场景'''
    def removeScene(self,sceneId):
        if(self.scenes.has_key(sceneId)):
            pkScene = self.scenes[sceneId]
            players = pkScene.pkPlayers
            keys = []
            for key in players:
                self.pkPlayers.pop(key)
            self.scenes.pop(sceneId)

    '''随机生成pk场景号'''
    def generateSceneID(self):
        for sceneID in range(1,201):
            if(self.scenes.has_key(sceneID) == False):
                return sceneID
        return 0

    '''根据pk场景id获取pkscene'''
    def getSceneById(self,sceneId):
        scene = self.scenes.get(sceneId)
        return scene

    '''出牌'''
    def chuPai(self,protoChuPai,player):
        paisStr = protoChuPai.pais
        paiStrs = paisStr.split(";")
        chuPais = []
        for paiStr in paiStrs:
            if(paiStr != ''):
                strs = paiStr.split("_")
                pai = PkPai(int(strs[0]),int(strs[1]))
                chuPais.append(pai)
        num = protoChuPai.num
        value = protoChuPai.value
        sceneId = player.pkPlayer.sceneId
        scene = self.scenes[sceneId]
        scene.chuPai(chuPais,num,value,player)

    '''决定'''
    def decide(self,decide,player):
        sceneId = player.pkPlayer.sceneId
        scene = self.scenes[sceneId]
        scene.decide(decide,player)

    '''每隔一秒搜索可以进行pk的玩家'''
    def searchPkPlayer(self):
        players = {}
        for key in self.players:
            player = self.players[key]
            if(player.state == 1):
                players[player.uid] = player
            if(len(players) >= 2):
                sceneId = self.generateSceneID()
                self.addScene(sceneId,players)
                players = {}