# coding:utf8

class PkPai:
    '''PK中的玩家的牌'''
    #牌的类型 1代表红桃 2代表黑桃 3代表方块 4代表梅花
    type = 0

    #值
    value = 0

    def __init__(self,type,value):
        self.type = type
        self.value = value

    '''比较牌的数字是否相同'''
    def compareValueEqual(self,pai):
        if(self.value == pai.value):
            return True
        else:
            return False

    '''比较牌的类型和数字是偶相同'''
    def compareEqual(self,type,value):
        if(self.type == type and self.value == value):
            return True
        else:
            return False