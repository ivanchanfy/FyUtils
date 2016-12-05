using System;
using PCLCrypto;
using System.Text;
using static PCLCrypto.WinRTCrypto;

namespace FyUtils {
    public class CryptUtils {
        public static string MD5(string input) {
            return Encode(input, HashAlgorithm.Md5);
        }

        public static string SHA1(string input) {
            return Encode(input, HashAlgorithm.Sha1);
        }

        public static string SHA256(string input) {
            return Encode(input, HashAlgorithm.Sha256);
        }

        public static string SHA384(string input) {
            return Encode(input, HashAlgorithm.Sha384);
        }

        public static string SHA512(string input) {
            return Encode(input, HashAlgorithm.Sha512);
        }

        private static string Encode(string input, HashAlgorithm algorithm) {
            IHashAlgorithmProvider provider = HashAlgorithmProvider.OpenAlgorithm(algorithm);
            byte[] data = provider.HashData(CryptographicBuffer.ConvertStringToBinary(input, Encoding.UTF8));

            return CryptographicBuffer.EncodeToHexString(data);
        }
    }
}