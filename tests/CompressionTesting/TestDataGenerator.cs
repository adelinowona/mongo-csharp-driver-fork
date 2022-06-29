namespace CompressionTesting.DataGenerator
{
    public class TestDataGenerator
    {
        private string directory = "/home/ubuntu/mongo-csharp-driver-fork/tests/CompressionTesting/Testdata/";
        private byte[] data;
        private int N = 10000;
        
        public TestDataGenerator(string data)
        {
            switch (data)
            {
                case "2.9mb_text_file":
                    GetFileData(directory + "plaintext1.txt");
                    break;
                case "156kB_text_file":
                    GetFileData(directory + "plaintext2.txt");
                    break;
                case "490kB_text_file":
                    GetFileData(directory + "plaintext3.txt");
                    break;
                case "49mb_json_file":
                    GetFileData(directory + "movies.json");
                    break;
                case "27mb_json_file":
                    GetFileData(directory + "transactions.json");
                    break;
                case "39kB_json_file":
                    GetFileData(directory + "users.json");
                    break;
                case "randomData":
                    GetRandomData();
                    break;
                case "repetitiveData":
                    GetRepetitiveData();
                    break;
                default:
                    break;
            }
        }

        private void GetFileData(string filepath)
        {
            data = File.ReadAllBytes(filepath);
        }

        private void GetRepetitiveData()
        {
            data = new byte[N];
            Array.Fill<byte>(data, 65);
        }

        private void GetRandomData()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        public byte[] GetData()
        {
            return data;
        }
    }
}