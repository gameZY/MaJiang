# coding:utf8

import urllib2
from flask import request
from web import app
from web.database import Session
from web.model.TbUser import TbUser

#360平台获取用户详细信息
@app.route("/web/getQihuUserInfo",methods=['GET'])
def teach_getQihuUserInfo():
    _access_token = request.args.get("token")
    url = "https://openapi.360.cn/user/me.json?" + "access_token=" + _access_token
    req = urllib2.Request(url)
    respo = urllib2.urlopen(req)
    return respo.read()

#360支付回调
@app.route('/web/pay',methods=['GET','POST'])
def pay():
    app_key = request.args.get('app_key','')
    product_id = request.args.get('product_id','')
    amount = request.args.get('amount',0)
    app_uid = request.args.get('app_uid','')
    app_ext1 = request.args.get('app_ext1','')
    app_ext2 = request.args.get('app_ext2','')
    user_id = request.args.get('user_id',-1)
    order_id = request.args.get('order_id',-1)
    gateway_flag = request.args.get('gateway_flag','')
    sign_type = request.args.get('sign_type','')
    app_order_id = request.args.get('app_order_id','')
    sign_return = request.args.get('sign_return','')
    sign = request.args.get('sign','')

    if gateway_flag == 'success' :
        session = Session()
        query = session.query(TbUser)
        user = query.filter_by(platformid=user_id).first()
        if(user):
            user.is_buy = True
            session.flush()
            session.commit()
        session.close()
    return 'ok'