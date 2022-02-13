using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionalResourceManager;
public class CreateFileOperation : IDisposable
{
    private string _backupPath;
    private string _actualPath;
    private byte[] _content;
    private bool _disposedValue;
    public CreateFileOperation(string filePath, byte[] content)
    {
        (_actualPath, _content) = (filePath, content);
        _backupPath = Path.GetTempFileName();
    }
    public void DoOperation()
    {
        if (File.Exists(_actualPath))
            File.Copy(_actualPath, _backupPath, true);

        File.WriteAllBytes(_actualPath, _content);
    }


    public void RollBack()
    {
        File.Copy(_backupPath, _actualPath, true);
        File.Delete(_backupPath);
    }

    public void Dispose() => Dispose(true);

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue) return;

        if (disposing)
        {
            File.Delete(_backupPath);
        }

        _disposedValue = true;
    }
    ~CreateFileOperation() => Dispose(false);
}
