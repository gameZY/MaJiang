# coding:utf8

class PkPlayer:
    '''PK中的玩家'''
    '''玩家处于场景的id'''
    sceneId = 0

    '''玩家的位置'''
    pos = 0

    '''玩家手中的牌'''
    pais = []

    '''玩家状态1.准备 2.pk中'''
    state = 0

    '''玩家叫的个数和数字'''
    paiNum = 0
    paiValue = 0

    '''当前出的牌'''
    chuPais = []

    def __init__(self,pos,sceneId):
        self.pos = pos
        self.sceneId = sceneId
        self.chuPais = []
        self.pais = []

    '''给玩家发牌'''
    def addPai(self,pai):
        self.pais.append(pai)

    '''给玩家增加多个牌'''
    def addPais(self,pais):
        for _pai in pais:
            self.pais.append(_pai)

    '''玩家销牌'''
    def removePai(self,pai):
        type = pai.type
        value = pai.value
        for _pai in self.pais:
            if(_pai.type == type and _pai.value == value):
                self.pais.remove(_pai)
                break

    '''玩家销毁多个牌'''
    def removePais(self,chuPais):
        self.chuPais = chuPais
        for chu in chuPais:
            for _pai in self.pais:
                if(_pai.type == chu.type and _pai.value == chu.value):
                    self.pais.remove(_pai)
                    break

    '''设置玩家叫的信息'''
    def setJiaoInfo(self,num,value):
        self.paiNum = num
        self.paiValue = value

    '''玩家交的信息是否与出牌的信息匹配'''
    def isJiaoMatchChu(self):
        for chu in self.chuPais:
            if(chu.value != self.paiValue):
                return False
        return True