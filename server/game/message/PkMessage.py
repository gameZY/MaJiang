# coding:utf8

from game.core.single.singleton import Singleton
from game.core.proto import Pk_pb2
from game.manager.NetworkManager import NetworkManager

class PkMessage:
    '''Pk消息'''
    __metaclass__ = Singleton

    '''玩家匹配成功发送进入消息'''
    def sendEnterGameResponse(self,scene):
        proto = Pk_pb2.EnterGameResponse()
        proto.state = True

        players = scene.players
        protoPkPlayers = []
        for key in players:
            protoPkPlayer = Pk_pb2.PkPlayer()
            player = players[key]
            protoPkPlayer.name = player.username
            protoPkPlayer.pos = player.pkPlayer.pos
            protoPkPlayers.append(protoPkPlayer)

        proto.players.extend(protoPkPlayers)
        for key in players:
            player = players[key]
            NetworkManager().sendMsgToPlayer(player,301,proto)

    '''玩家准备消息'''
    def sendReadyResponse(self,scene,pos):
        proto = Pk_pb2.ReadyPkResponse()
        proto.index = pos

        players = scene.players
        for key in players:
            player = players[key]
            NetworkManager().sendMsgToPlayer(player,302,proto)

    '''给玩家发牌消息'''
    def sendFaPaiResponse(self,scene):
        proto = Pk_pb2.FaPaiResponse()
        proto.state = True
        proto.first = 1
        players = scene.players
        protoPkPais = []
        for key in players:
            player = players[key]
            for pai in player.pkPlayer.pais:
                protoPkPai = Pk_pb2.PkPai()
                protoPkPai.pos = player.pkPlayer.pos
                protoPkPai.type = pai.type
                protoPkPai.value = pai.value
                protoPkPais.append(protoPkPai)
        proto.pais.extend(protoPkPais)
        for key in players:
            player = players[key]
            NetworkManager().sendMsgToPlayer(player,303,proto)

    '''给所有玩家推送出牌玩家出的牌'''
    def sendChuPaiResponse(self,scene,player):
        proto = Pk_pb2.ChuPaiResponse()
        proto.pos = player.pkPlayer.pos
        proto.num = player.pkPlayer.paiNum
        proto.value = player.pkPlayer.paiValue
        for key in scene.players:
            player = scene.players[key]
            NetworkManager().sendMsgToPlayer(player,305,proto)

    '''该那个玩家出牌'''
    def sendChuPaiPosResponse(self,scene,pos):
        proto = Pk_pb2.ChuPaiPos()
        proto.pos = pos
        for key in scene.players:
            player = scene.players[key]
            NetworkManager().sendMsgToPlayer(player,306,proto)

    '''该那个玩家做决定'''
    def sendDecidePosResponse(self,scene,pos):
        proto = Pk_pb2.DecidePos()
        proto.pos = pos
        for key in scene.players:
            player = scene.players[key]
            NetworkManager().sendMsgToPlayer(player,307,proto)