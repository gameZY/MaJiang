# coding:utf8
import random
import string

def randNumByList(nums,min,max):
    while(True):
        _num = random.randint(min,max);
        if(_num not in nums):
            return _num;

def ranNum(min,max):
    return random.randint(min,max);

def getRandRight(percent):
    perNum = int(percent * 100)
    num = ranNum(1,100)
    if(num <= perNum):
        return True
    else:
        return False

def getRandName(length):
    name = string.join(random.sample(['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'], length)).replace(" ","")
    return name