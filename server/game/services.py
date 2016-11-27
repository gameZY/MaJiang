#coding:utf8

import threading
from twisted.internet import defer,threads
from twisted.python import log

class Service(object):

    SINGLE_STYLE = 1
    PARALLEL_STYLE = 2

    def __init__(self,name):
        self._lock = threading.RLock()
        self._name = name
        self._targets = {}

    def mapTargetName(self, target):
        """Add a target to the service."""
        self._lock.acquire()
        try:
            key = target.__name__
            if self._targets.has_key(key):
                exist_target = self._targets.get(key)
                raise "target [%d] Already exists,\
                Conflict between the %s and %s"%(key,exist_target.__name__,target.__name__)
            self._targets[key] = target
        finally:
            self._lock.release()

    def mapTarget(self,target):
        self._lock.acquire()
        try:
            key = int((target.__name__).split('_')[1])
            if self._targets.has_key(key):
                exist_target = self._targets.get(key)
                raise "target [%d] Already exists,\
                Conflict between the %s and %s"%(key,exist_target.__name__,target.__name__)
            self._targets[key] = target
        finally:
            self._lock.release()

    def getTarget(self,targetKey):
        self._lock.acquire()
        try:
            target = self._targets.get(targetKey,None)
        finally:
            self._lock.release()
        return target

    def callTarget(self,targetKey,*args,**kw):
        runstyle = 1
        target = self.getTarget(targetKey)
        if not target:
            log.err('the command '+target.__name__+' not Found on service')
            return None
        else:
            splitLen = len((target.__name__).split('_'))
            if(splitLen > 2):
                runstyle = int((target.__name__).split('_')[2])
            else:
                runstyle = self.SINGLE_STYLE

        if runstyle == self.SINGLE_STYLE:
           result = self.callTargetSingle(target,*args,**kw)
        else:
           result = self.callTargetParallel(target,*args,**kw)
        return result

    def callTargetSingle(self,target,*args,**kw):
        '''call Target by Single
        @param conn: client connection
        @param targetKey: target ID
        @param data: client data
        '''

        self._lock.acquire()
        try:
            defer_data = target(*args,**kw)
            if not defer_data:
                return None
            if isinstance(defer_data,defer.Deferred):
                return defer_data
            d = defer.Deferred()
            d.callback(defer_data)
        finally:
            self._lock.release()
        return d

    def callTargetParallel(self,target,*args,**kw):
        '''call Target by Single
        @param conn: client connection
        @param targetKey: target ID
        @param data: client data
        '''
        self._lock.acquire()
        try:
            log.msg("call method %s on service[parallel]"%target.__name__)
            d = threads.deferToThread(target,*args,**kw)
        finally:
            self._lock.release()
        return d

