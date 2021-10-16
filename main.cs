using System;
using System.Numerics;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;

namespace sig_neth
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://github.com/Nethereum/Nethereum/blob/b1c0a842959a97317138c311e51a6ab4e1866911/src/Nethereum.Signer/EthECKey.cs#L42
            EthECKey key = new EthECKey("0x78dae1a22c7507a4ed30c06172e7614eb168d3546c13856340771e63ad3c0081");
            string hashHex = "0xf94cc9053176e5b409587ebd640b31787b1db1e6db9b12ec8bd28760ab9dd9da";
            // https://github.com/Nethereum/Nethereum/blob/b1c0a842959a97317138c311e51a6ab4e1866911/src/Nethereum.Hex/HexConvertors/Extensions/HexByteConvertorExtensions.cs#L114
            byte[] hashByteArr = HexByteConvertorExtensions.HexToByteArray(hashHex);
            BigInteger chainId = 4;
            // https://github.com/Nethereum/Nethereum/blob/b1c0a842959a97317138c311e51a6ab4e1866911/src/Nethereum.Signer/EthECKey.cs#L278
            EthECDSASignature sig = key.SignAndCalculateV(hashByteArr, chainId);
            // 0x4b0927e304ea62a34bde5a33d882a101ca1b595f7686aaa421cbe75dc65344d26104d10cf81ec2b4ad3185591c36d782e10b73d48bc39a7ebadee9a0075044b81c
            Console.WriteLine(EthECDSASignature.CreateStringSignature(sig));        
        }
    }
}
