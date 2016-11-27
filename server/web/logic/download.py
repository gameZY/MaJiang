#encoding:utf8

#上传文件

import os,sys
from flask import Flask,request,redirect,url_for,send_from_directory
from web.common.globalvar import tmp_path
from web import app

@app.route('/downloadFile/<platform>',methods=['POST'])
def downloadFile(platform):
    if request.method == 'POST':
        filepath = request.form['path']
        filename = request.form['file']
        if(filepath == "null"):
            filepath = ''
        path = tmp_path + '/' + platform + '/' + filepath
        print 'Download=======>' + path + filename
        str = send_from_directory(path,filename)
        return str

@app.route('/downloadModel/<fileName>',methods=['GET','POST'])
def downloadModel(fileName):
    path = tmp_path + "\\android\\model\\" + fileName;
    print 'Download=======>' + path;
    str = send_from_directory(tmp_path + "\\android\\model",fileName)
    return str
