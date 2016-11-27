# coding:utf8

class Player:
    '''玩家类'''

    #数据库操作
    operation = None

    #玩家在线
    isOnline = False

    #用户id
    uid = 0

    #用户昵称
    username = None

    #用户连接
    conn = None

    #心跳时间
    heartTime = 0

    #玩家的状态 0.不在游戏中 1.正在匹配 2.在pk中
    state = 0

    #玩家是否具有pk的数据
    pkPlayer = None

    def __init__(self):
        self.state = 0
        self.heartTime = 0