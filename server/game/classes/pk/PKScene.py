# coding:utf8

from PkPai import PkPai
from PkPlayer import PkPlayer
from game.message.PkMessage import PkMessage

from game.core.math.rand import *

class PkScene:
    '''场景ID'''
    sceneId = 0

    '''场景中的玩家'''
    players = {}

    '''场景中的牌'''
    pkPais = []

    '''pk中每个人手上的牌个数'''
    playerPaiNum = 5

    '''当前操作的玩家的Pos'''
    currentPos = 1

    '''初始化PK场景中的玩家'''
    def __init__(self,sceneId,players):
        self.sceneId = sceneId
        self.players = {}
        self.pkPais = []
        self.currentPos = 1
        pos = 1
        for key in players:
            player = players[key]
            player.state = 2
            pkPlayer = PkPlayer(pos,self.sceneId)
            player.pkPlayer = pkPlayer
            self.players[pos] = player
            pos = pos + 1

    '''判断是否已经有了该牌'''
    def isExitPai(self,type,value):
        for pai in self.pkPais:
            if(pai.compareEqual(type,value)):
                return True
        return False

    '''设定玩家的状态'''
    def setPkPlayerState(self,pos,state):
        player = self.players[pos]
        player.state = state
        if(self.isAllReady() == False):
            PkMessage().sendReadyResponse(self,player.pkPlayer.pos)
        else:
            self.startFaPai()

    '''是否所有玩家都处于准备状态'''
    def isAllReady(self):
        for key in self.players:
            player = self.players[key]
            if(player.state != 1):
                return False
        return True

    '''获取下一个操作的玩家的pos'''
    def nextPlayerPos(self):
        self.currentPos = self.currentPos + 1
        if(self.currentPos > len(self.players)):
            self.currentPos = 1

    '''pk开始发牌'''
    def startFaPai(self):
        playersNum = len(self.players)
        paiNums = self.playerPaiNum * playersNum
        for i in range(1,paiNums+1):
            while True:
                type = ranNum(1,4)
                value = ranNum(1,13)
                if(self.isExitPai(type,value) == False):
                    pai = PkPai(type,value)
                    self.pkPais.append(pai)
                    break
        index = 0
        for key in self.players:
            player = self.players[key]
            for i in range(0,5):
                pai = self.pkPais[index * self.playerPaiNum + i];
                player.pkPlayer.addPai(pai)
            index = index + 1
        PkMessage().sendFaPaiResponse(self)

    '''pk出牌'''
    def chuPai(self,pais,num,value,player):
        player.pkPlayer.removePais(pais)
        player.pkPlayer.setJiaoInfo(num,value)
        PkMessage().sendChuPaiResponse(self,player)
        #self.nextPlayerPos()
        #PkMessage().sendDecidePosResponse(self,self.currentPos)

    '''决定假，过，出牌'''
    def decide(self,decide,player):
        if(decide == 1):
            pos = player.pkPlayer.pos - 1
            if(pos <= 0):
                pos = len(self.players)
            prevPlayer = self.players[pos]
        elif(decide == 2):
            self.nextPlayerPos()
            PkMessage().sendDecidePosResponse(self,self.currentPos)
        else:
            pass