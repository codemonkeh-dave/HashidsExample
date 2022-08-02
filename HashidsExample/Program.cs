
using HashidsNet;

internal class Program
{
    static void Main(string[] args)
    {

        /* 
         * what not to do
         *  - Do not try to encode negative numbers. It won't work. The library currently supports only positive numbers and zero. If you're trying to use numbers as flags for something, simply designate the first N number of digits as internal flags.
         *  - Do not encode strings.We've had several requests to add this feature — "it seems so easy to add". We will not add this feature for security purposes, doing so encourages people to encode sensitive data, like passwords. This is the wrong tool for that.
         *  -Do not encode sensitive data.This includes sensitive integers, like numeric passwords or PIN numbers. This is not a true encryption algorithm. There are people that dedicate their lives to cryptography and there are plenty of more appropriate algorithms: bcrypt, md5, aes, sha1, blowfish.Here's a full list.
        */

        const string salt = "aafdsfasiodfua98sufpioAN3WR423R09FSJFVO";

        const int id = 1234;
        const int tenantId = 72;

        // Kez1PyDwZBOrqQmOIz3qjdVWnA638QaN
        var hashids = new Hashids(salt, 16);

        var encoded = hashids.Encode(id, tenantId);
        Console.WriteLine($"Encoded={encoded}");

        var decoded = hashids.Decode(encoded);

        int decodedId = decoded[0];
        int decodedTenantId = decoded[1];

        Console.WriteLine($"Decoded=id={decodedId} TenantId={tenantId}");
        Console.Read();


    }
}
