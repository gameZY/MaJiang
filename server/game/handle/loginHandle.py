#coding:utf8

import time

from game.manager.PlayerManager import *
from game.manager.NetworkManager import *
from game.core.proto.Login_pb2 import *

def loginServiceHandle(target):
    from game.manager.GlobalManager import GlobalManager
    GlobalManager.netservice.mapTarget(target)

@loginServiceHandle
def heartEcho_200_1(conn,data):
    player = PlayerManager().getPlayerByConn(conn)
    if(player != None):
        player.heartTime = time.time()
        heartResponse = HeartResponse()
        heartResponse.state = True
        NetworkManager().sendMsgToPlayer(player,200,heartResponse)

@loginServiceHandle
def login_201_1(conn,data):
    loginRequest = LoginRequest()
    loginRequest.ParseFromString(data)
    uid = loginRequest.uid
    username = loginRequest.name

    player = PlayerManager().getPlayerByUid(uid)
    if(player == None):
        player = Player()
        player.uid = uid
        player.username = username
        player.conn = conn

        PlayerManager().addPlayer(player)
        PlayerManager().insertTbPlayer(player)
    else:
        player.conn = conn
    player.heartTime = time.time()
    player.isOnline = True

    loginResponse = LoginResponse()
    loginResponse.state = True
    NetworkManager().sendMsgToPlayer(player,201,loginResponse)