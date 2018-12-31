import os
import datetime

# get all files from directory
def GetListOfFilesFromDirectory(dirpath):
    _files = os.listdir(dirpath)
    _returnList = []
    for file in _files:
        _fullPath = os.path.join(dirpath,file)
        _returnList.append((_fullPath,os.stat(_fullPath).st_atime))
    return _returnList

def RetrieveRecords():
    _desktopPath = os.path.expanduser("~\\Desktop")
    files = GetListOfFilesFromDirectory(_desktopPath)
    for file in sorted(files,key=lambda x:x[1]):
        print("%s , Last Accessed : %s" %(file[0],datetime.datetime.fromtimestamp(file[1])))

RetrieveRecords()
