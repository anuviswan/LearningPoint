# The script intends to archive unused (not acccessed in last 7 days) Desktop files to Archive Folder
# Aids in frequent cleaning of Desktop, could be run in Windows Startup
import os
import datetime
import shutil

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

def CreateArchiveDirectoryAndMoveFiles(archiveDirectory,files):
        if not os.path.exists(archiveDirectory):
                os.makedirs(archiveDirectory)
        
        for file in files:
                _fileName = os.path.basename(file)
                shutil.move(file,os.path.join(archiveDirectory,_fileName))
        


    
# Archive Desktop
def ArchiveDesktop():
    _desktopPath = os.path.expanduser("~\\Desktop")
    _archiveDirectoryPath = os.path.expanduser("~\\Desktop\\Archive")
    files = GetListOfFilesFromDirectory(_desktopPath)
    filterfiles = FilterRecords(files)
    PrintList(filterfiles)
    CreateArchiveDirectoryAndMoveFiles(_archiveDirectoryPath,filterfiles)

ArchiveDesktop()
