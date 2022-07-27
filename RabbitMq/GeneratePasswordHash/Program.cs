using System.Security.Cryptography;
using System.Text;

Console.WriteLine("This program generates password hash for RabbitMq");

if (args.Any())
{
    var plainPasskey = args[0];
    
    var plainPassKeyInBytes = Encoding.UTF8.GetBytes(plainPasskey);
    var salt = GetSalt(4);
    Print("Plain Text Salt : ", salt);
    Print("Plain Text PassKey: ", plainPassKeyInBytes);

    var saltedPassKey = Concatenate(salt,plainPassKeyInBytes);
    Print("Salted Plain Text PassKey: ", saltedPassKey);

    var saltedPassKeyHash = SHA256.HashData(saltedPassKey);
    Print("Hashed Salted PassKey: ", saltedPassKeyHash);
    var result = Convert.ToBase64String(Concatenate(salt, saltedPassKeyHash));
    Print("Salted Hash Value : ", Concatenate(salt, saltedPassKeyHash));
    Console.WriteLine(result);
}

byte[] GetSalt(int maximumSaltLength)
{
    return RandomNumberGenerator.GetBytes(maximumSaltLength);
}

byte[] Concatenate(params byte[][] arrays)
{
    byte[] result = new byte[arrays.Sum(a => a.Length)];
    int offset = 0;
    foreach (byte[] array in arrays)
    {
        System.Buffer.BlockCopy(array, 0, result, offset, array.Length);
        offset += array.Length;
    }
    return result;
}

void Print(string message,byte[] arr)
{
    Console.WriteLine($"{message} {BitConverter.ToString(arr)}");
}