// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Transactions;
using TransactionalResourceManager;

Console.WriteLine("Hello, World!");

var bytesToWrite = Encoding.UTF8.GetBytes("hello world!!");
var createFileOperation = new CreateFileOperation("sample.txt",bytesToWrite);

try
{
    using var resourceManager = new ResourceManager();
    using var transactionScope = new TransactionScope();
    resourceManager.EnlistOperation(createFileOperation);
    throw new Exception();
    transactionScope.Complete();
}
catch 
{
    Console.WriteLine("Some error has occurred. Transaction has aborted and rolledback");
}

