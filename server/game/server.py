#coding:utf8

from twisted.internet import reactor
from twisted.python import log

from game.protoc import ServerFactory

class Server:
    def __init__(self,_port,_name):
        self.port = _port
        self.name = _name
        self.serverFactory = ServerFactory()

    def startTCPListen(self):
        log.msg('%s start listening %d' % (self.name,self.port))
        reactor.listenTCP(self.port,self.serverFactory)