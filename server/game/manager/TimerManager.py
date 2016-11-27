# coding:utf8
from twisted.internet import reactor
from game.core.single.singleton import Singleton

class TimerManager:
    '''定时器管理器'''
    __metaclass__ = Singleton

    '''创建定时器'''
    def createTimer(self,delay,func):
        timer = reactor.callLater(delay,func)
        return timer

    '''销毁指定定时器'''
    def removeTimer(self,timer):
        timer.cancel()