#coding=utf-8

if __name__ == '__main__':
    from web import app

    #加入teacher逻辑
    from web import database
    from web import logic

    app.run(host="0.0.0.0",port=8081, debug=True)