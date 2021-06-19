namespace API.Helpers.Utilities
{
    public class Crypto
    {
        private const int _bufferSizeInBytes = 16 * 1024;

        // you can have a number of other lengths but these will do
        private const int _requiredKeyLengthInBytes = 32;
        private const int _requiredInitialisationVectorLengthInBytes = 16;
        public bool EncryptStream(string password, ref Stream stream)
        {
            string InitVector = @"qwertyui"; //16byte 1chr = 2byte(unicode)
            try
            {
                UnicodeEncoding UE = new();
                byte[] key = UE.GetBytes(password);
                byte[] IV = UE.GetBytes(InitVector);
                RijndaelManaged RMCrypto = new();
                ICryptoTransform encryptor = RMCrypto.CreateEncryptor(key, IV);
                CryptoStream cs = new(stream, encryptor, CryptoStreamMode.Write);
                stream = cs;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DecryptStream(string password, ref Stream stream)
        {
            string InitVector = @"qwertyui"; //16byte 1chr = 2byte(unicode)
            try
            {
                UnicodeEncoding UE = new();
                byte[] key = UE.GetBytes(password);
                byte[] IV = UE.GetBytes(InitVector);
                RijndaelManaged RMCrypto = new();
                ICryptoTransform decryptor = RMCrypto.CreateDecryptor(key, IV);
                CryptoStream cs = new(stream, decryptor, CryptoStreamMode.Read);
                stream = cs;

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ValidateKey(byte[] key)
        {
            if (key.Length == _requiredKeyLengthInBytes)
            {
                return;
            }
            throw new ArgumentException(string.Format("Please use a key length of {0} bytes ({1} bits)", _requiredKeyLengthInBytes, _requiredKeyLengthInBytes * 8));
        }

        private void ValidateInitialisation(byte[] initialisationVector)
        {
            if (initialisationVector.Length == _requiredInitialisationVectorLengthInBytes)
            {
                return;
            }
            throw new ArgumentException(string.Format("Please use an initialisation vector length of {0} bytes ({1} bits)", _requiredInitialisationVectorLengthInBytes, _requiredInitialisationVectorLengthInBytes * 8));
        }
    }
}
