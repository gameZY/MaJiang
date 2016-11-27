# coding:utf8

import json
import struct

#http
#获取用户uid
def getUserJson(obj):
    str = json.dumps({'uid':obj.uid,'username':obj.username})
    return str

#修改成功
def getUpdateSuccess():
    str = json.dumps({'msgid':200})
    return str

def getHttpErrorJson(msg):
    str = json.dumps({"msgid":10000,'msg':msg})
    return str