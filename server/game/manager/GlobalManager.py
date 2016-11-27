# coding:utf8

from game.core.single.singleton import Singleton

class GlobalManager:
    #全局管理器
    __metaclass__ = Singleton

    def __init__(self):
        self.db = None
        self.tcpserver = None
        self.netservice = None
        self.BaseModel = None
        self.Session = None
        self.heartTask = None
        self.rankTask = None
        self.stophandler = None
        self.reloadmodule = None
        self.pbroot = None

    def createTables(self):
        self.BaseModel.metadata.create_all(self.db)

    def dropTable(self):
        self.BaseModel.metadata.drop_all(self.db)