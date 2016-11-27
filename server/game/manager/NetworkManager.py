# coding:utf8

import struct
from game.core.single.singleton import Singleton

class NetworkManager:
    '''网络管理器'''
    __metaclass__ = Singleton

    #向指定玩家发送消息
    def sendMsgToPlayer(self,player,msgId,proto):
        msg = proto.SerializeToString()
        str = struct.pack('i',len(msg)) + struct.pack('i',msgId) + msg
        player.conn.safeToWriteData(str)