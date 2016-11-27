# coding:utf8

if __name__ == '__main__':
    from management import app

    #加入management逻辑
    from management import database
    from management import admin

    app.run(host="0.0.0.0",port=8082, debug=True)