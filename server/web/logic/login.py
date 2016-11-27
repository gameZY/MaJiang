# coding:utf8

import datetime
import hashlib
import random

from flask import request

from web import app
from web.model.TbUser import TbUser
from web.common.globalobject import GlobalObject
from web.datapack import *

@app.route('/web/login',methods=['POST'])
def login():
    _deviceid = request.form['deviceid']
    session = GlobalObject().Session()
    query = session.query(TbUser)
    user = query.filter_by(deviceid=_deviceid).first()
    if user:
        session.close()
        return getUserJson(user)
    else:
        name = _deviceid[:5]
        _user = TbUser()
        timestamp = datetime.datetime.utcnow()
        _user.deviceid = _deviceid
        _user.regtime = timestamp
        _user.username = name
        session.add(_user)
        session.commit()
        msg = None
        if _user:
            msg = getUserJson(_user)
        else:
            msg = getHttpErrorJson(u"注册失败")
        session.close()
        return msg