#coding:utf8

from singleton import Singleton

class GlobalObject:

    __metaclass__ = Singleton

    def __init__(self):
        self.db = None
        self.Session = None
        self.BaseModel = None

    def createTables(self):
        self.BaseModel.metadata.create_all(self.db)