# coding:utf8
from game.manager.PlayerManager import PlayerManager
from game.manager.PkSceneManager import PkSceneManager
from game.core.proto.Pk_pb2 import *

def pkServiceHandle(target):
    from game.manager.GlobalManager import GlobalManager
    GlobalManager.netservice.mapTarget(target)

@pkServiceHandle
def searchPlayer_301_1(conn,data):
    player = PlayerManager().getPlayerByConn(conn)
    PkSceneManager().addPkPlayer(player)

@pkServiceHandle
def readyPlayer_302_1(conn,data):
    proto = ReadyPkRequest()
    proto.ParseFromString(data)

    player = PlayerManager().getPlayerByConn(conn)
    PkSceneManager().setPlayerState(player)

@pkServiceHandle
def decidePlayer_304_1(conn,data):
    proto = DecideRequest()
    proto.ParseFromString(data)

    player = PlayerManager().getPlayerByConn(conn)
    PkSceneManager().decide(proto.decide,player)

@pkServiceHandle
def chuPai_305_1(conn,data):
    proto = ChuPaiRequest()
    proto.ParseFromString(data)

    player = PlayerManager().getPlayerByConn(conn)
    PkSceneManager().chuPai(proto,player)