# coding:utf8

from game.core.single.singleton import Singleton
from game.thread.SavePlayerThread import SavePlayerThread

class ThreadManager:
    '''线程管理器'''
    __metaclass__ = Singleton

    #玩家数据库线程
    playerThread = None

    def __init__(self):
        self.playerThread = SavePlayerThread("SAVE-PLAYER-THREAD")

    def startAllThreads(self):
        self.playerThread.start()