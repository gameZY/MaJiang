# coding:utf8

from firefly.utils import services
from firefly.distributed.node import RemoteObject
from twisted.internet import reactor
from twisted.python import util,log
import sys

log.startLogging(sys.stdout)
addr = ('localhost',10000)
remote = RemoteObject('commandNode')
service = services.Service('reference',services.Service.SINGLE_STYLE)
remote.addServiceChannel(service)

def serviceHandle(target):
    service.mapTarget(target)

@serviceHandle
def printOK(data):
    print data
    print "#############################"
    return "call printOK_01"

def handleResult(result):
    print result + " success"

def handleInput():
    while True:
        funcName = input()
        d = remote.callRemote(funcName)
        d.addCallback(handleInput,funcName)

if __name__ == "__main__":
    remote.connect(addr)
    reactor.callInThread(handleInput)
    reactor.run()