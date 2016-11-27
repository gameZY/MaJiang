#coding:utf8

import sys
import time

from twisted.internet import reactor,task
from twisted.python import log
from firefly.distributed.root import PBRoot,BilateralFactory
from manager.GlobalManager import GlobalManager

class Master:

    def __init__(self):
        log.startLogging(sys.stdout)

        reload(sys)
        sys.setdefaultencoding('UTF-8')

        #数据库
        import database
        GlobalManager.db = database.db
        GlobalManager.Session = database.Session;

        #服务器配置
        from server import Server
        from services import Service
        server = Server(8100,"game")
        GlobalManager.tcpserver = server
        GlobalManager.netservice = Service('NetService')
        GlobalManager.tcpserver.serverFactory.addServiceChannel(GlobalManager.netservice)

        #开启进程监视
        GlobalManager.pbroot = PBRoot()
        GlobalManager.pbroot.addServiceChannel(GlobalManager.netservice)
        reactor.listenTCP(10000,BilateralFactory(GlobalManager.pbroot))

        #加入服务器逻辑函数
        import handle

    def start(self):
        GlobalManager.tcpserver.startTCPListen()

        loadStartTime = time.time()
        self.loadAllData()
        self.startAllThreads()
        self.startAllTasks()
        log.msg("===load all data spend time==="+str(time.time() - loadStartTime))

        reactor.run()

    def loadAllData(self):
        #加载所有的数据库数据
        from game.manager.PlayerManager import PlayerManager
        PlayerManager().loadAllPlayers()

    def startAllThreads(self):
        #启动所有的线程
        reactor.suggestThreadPoolSize(5)
        from game.manager.ThreadManager import ThreadManager
        ThreadManager().startAllThreads()

    def startAllTasks(self):
        from game.manager.PlayerManager import PlayerManager
        GlobalManager.heartTask = task.LoopingCall(PlayerManager().heartCheck)
        GlobalManager.heartTask.start(60)

        from game.manager.PkSceneManager import PkSceneManager
        pkSearchTask = task.LoopingCall(PkSceneManager().searchPkPlayer)
        pkSearchTask.start(1)

    def stopReactor(self):
        #Ctrl+c终止reactor
        from game.manager.PlayerManager import PlayerManager
        players = PlayerManager().players
        for key in players:
            _player = players[key]
            PlayerManager.updatePlayer(_player)
