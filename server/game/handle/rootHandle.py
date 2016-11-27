# coding:utf8

def rootServiceHandle(target):
    from game.manager.GlobalManager import GlobalManager
    GlobalManager.netservice.mapTargetName(target)

@rootServiceHandle
def reloadConfig():
    pass