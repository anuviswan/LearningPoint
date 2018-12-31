import os
import datetime

# Get all files from directory, along with Last Accessed TimeStamp
def GetListOfFilesFromDirectory(dirpath):
    _files = os.listdir(dirpath)
    _returnList = []
    for file in _files:
        _fullPath = os.path.join(dirpath,file)
        _returnList.append((_fullPath,os.stat(_fullPath).st_atime))
    return _returnList

# Filter Files = Not accessed for past 7 days
def FilterRecords(files):
    
    _weekAgo = datetime.date.today() - datetime.timedelta(days=7)

    _returnList=[]
    for file in sorted(files,key=lambda x:x[1]):
        lastAccessedDate = datetime.datetime.fromtimestamp(file[1])
        if(_weekAgo > lastAccessedDate.date()):
            _returnList.append(file[0])
    return _returnList

# Print Files
def PrintList(files):
    for file in files:
        print(file)
    
# Archive Desktop
def ArchiveDesktop():
    _desktopPath = os.path.expanduser("~\\Desktop")
    files = GetListOfFilesFromDirectory(_desktopPath)
    filterfiles = FilterRecords(files)
    PrintList(filterfiles)


ArchiveDesktop()
