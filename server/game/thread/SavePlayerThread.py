# coding:utf8

from twisted.internet import reactor
from game.core.single.singleton import Singleton
from game.model.TbPlayer import TbPlayer

class SavePlayerThread:
    #保存玩家数据的线程
    __metaclass__ = Singleton

    #执行队列
    excuteList = []

    def __init__(self,name):
        self._name = name

    def addExcuteQueue(self,rank):
        self.excuteList.append(rank)

    def run(self):
        while(True):
            if(len(self.excuteList) > 0):
                removeList = []
                for task in self.excuteList:
                    if(task.operation == "insert"):
                        TbPlayer.insert(task)
                    if(task.operation == "update"):
                        TbPlayer.update(task)
                    removeList.append(task)
                if(len(removeList) > 0):
                    for rank in removeList:
                        self.excuteList.remove(rank)

    def start(self):
        reactor.callInThread(self.run)
