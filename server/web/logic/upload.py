# coding:utf8
import os
from flask import Flask,url_for,render_template,request,url_for,redirect,send_from_directory
from web import app
import json

UPLOAD_FOLDER='D:/zhouhang/project/server/tmp/head/'
ALLOWED_EXTENSIONS=set(['txt','pdf','png','jpg','jpeg','gif'])

app.config['UPLOAD_FOLDER']=UPLOAD_FOLDER

def allowed_file(filename):
    return '.' in filename and filename.rsplit('.',1)[1] in ALLOWED_EXTENSIONS

@app.route('/web/savePhoto',methods=['GET','POST'])
def savePhoto():
    if request.method=='POST':
        fileName = request.form['uid']
        fileData = request.files['data']
        path = os.path.join(app.config['UPLOAD_FOLDER'],fileName+".png")
        fileData.save(path)
        return json.dumps({'msgid':200})

@app.route('/web/uploadPhoto/<filename>')
def uploadPhoto(filename):
    path = app.config['UPLOAD_FOLDER'] + filename+".png"
    if(os.path.exists(path)):
        bytes = send_from_directory(app.config['UPLOAD_FOLDER'],filename+".png")
    else:
        bytes = send_from_directory(app.config['UPLOAD_FOLDER'],"default.png")
    if(bytes == None):
        return json.dumps({'msgid':1000})
    return bytes