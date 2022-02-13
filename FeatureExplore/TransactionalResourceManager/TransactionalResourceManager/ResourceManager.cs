using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TransactionalResourceManager;
public class ResourceManager : IEnlistmentNotification, IDisposable
{
    private List<CreateFileOperation> _operations;
    private bool _disposedValue;
    public void EnlistOperation(CreateFileOperation operation)
    {
        Console.WriteLine("Enlisting Operation");
        if (_operations is null)
        {
            var currentTransaction = Transaction.Current;
            currentTransaction?.EnlistVolatile(this, EnlistmentOptions.None);
            _operations = new List<CreateFileOperation>();
        }
        _operations.Add(operation);
    }
    public void Commit(Enlistment enlistment)
    {
        Console.WriteLine("Initiaitng Commit Operation");
        foreach (var createFileOperation in _operations)
        {
            createFileOperation.DoOperation();
        }
        enlistment.Done();
        Console.WriteLine("Commit Operation Completed. Ensuring cleanup");
        foreach (var createFileOperation in _operations)
        {
            createFileOperation.Dispose();
        }
    }

    public void InDoubt(Enlistment enlistment)
    {
        foreach (var createFileOperation in _operations)
        {
            createFileOperation.RollBack();
        }
        enlistment.Done();
    }

    public void Prepare(PreparingEnlistment preparingEnlistment)
    {
        try
        {
            Console.WriteLine("Preparing for commit.");
            PrepareForCommit();
            Console.WriteLine("Client is ready for commit Notify Cordinator");
            preparingEnlistment.Prepared();
            
        }
        catch 
        {
            Console.WriteLine("Client is NOT ready for commit Notify Cordinator");
            preparingEnlistment.ForceRollback();
        }
    }

    public void Rollback(Enlistment enlistment)
    {
        Console.WriteLine("Initiating Rollback");
        foreach (var createFileOperation in _operations)
        {
            createFileOperation.RollBack();
        }
        enlistment.Done();
        Console.WriteLine("Rollback completed");
    }

    private void PrepareForCommit()
    {
        // Prepare for commit
    }

    public void Dispose() => Dispose(true);

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue) return;

        if (disposing)
        {
            foreach(var operation in _operations)
                operation.Dispose();
        }

        _disposedValue = true;
    }
    ~ResourceManager() => Dispose(false);
}