#coding:utf8

import struct

from twisted.python import log
from twisted.internet import protocol,reactor

from game.manager.PlayerManager import PlayerManager

#TCP Protocol
class ServerProtocol(protocol.Protocol):
    '''ushort length'''
    ushort = 4

    def connectionMade(self):
        '''连接建立处理 '''
        log.msg('Client %d login in.[%s,%d]'%(self.transport.sessionno,\
                self.transport.client[0],self.transport.client[1]))

    def connectionLost(self,reason):
        '''连接断开处理'''
        PlayerManager().dropUserByConn(self)

    def terminate(self):
        '''心跳包检测断开连接'''
        self.transport.loseConnection()
        PlayerManager().dropUserByConn(self)

    def safeToWriteData(self,data):
        '''线程安全的向客户端发送数据
        @param data: str 要向客户端写的数据
        '''
        if not self.transport.connected or data is None:
            return
        length = struct.unpack("i",data[0:4])[0]
        log.msg('server tcp send %d%s to client %d in %s:%d' % (length,data[4:],self.transport.sessionno,
                self.transport.client[0],self.transport.client[1]))
        reactor.callFromThread(self.transport.write,data)

    def DefferedErrorHandle(self,e):
        '''延迟对象的错误处理'''
        log.err(str(e))
        return

    def dataReceived(self, data):
        _len = 0
        '''考虑粘包'''
        while True:
            try:
                if _len == len(data):
                    return
                #数据长度和消息id
                datalenth,commandID = struct.unpack("ii",data[_len:_len+8]);
                #消息
                msg = data[_len + 8:_len + 8 + datalenth].encode('utf-8')
                d = self.factory.doDataReceived(self,commandID,msg)
                if d:
                    d.addCallback(self.safeToWriteData)
                    d.addErrback(self.DefferedErrorHandle)
                _len += 8 + datalenth
            #超出data索引
            except IndexError:
                log.msg('data range index client %d in %s:%d' % (self.transport.sessionno,
                        self.transport.client[0],self.transport.client[1]))
                return

class ServerFactory(protocol.ServerFactory):
    '''服务器工厂'''
    protocol = ServerProtocol

    def __init__(self):
        '''初始化'''
        self.service = None

    def doDataReceived(self,conn,commandID,data):
        '''数据到达时的处理'''
        defer_tool = self.service.callTarget(commandID,conn,data)
        return defer_tool

    def addServiceChannel(self,service):
        '''添加服务通道'''
        self.service = service