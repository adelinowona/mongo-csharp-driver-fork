using System;
using System.IO;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace benchmarks.ParallelBench;

[IterationCount(100)]
[BenchmarkCategory("ParallelBench", "ReadBench", "DriverBench")]
public class GridFsMultiFileDownload
{
    private MongoClient _client;
    private GridFSBucket _gridFsBucket;
    private DirectoryInfo _tmpDirectory;

    [GlobalSetup]
    public void Setup()
    {
        string mongoUri = Environment.GetEnvironmentVariable("MONGODB_URI");
        _client = mongoUri != null ? new MongoClient(mongoUri) : new MongoClient();
        _client.DropDatabase("perftest");
        _gridFsBucket = new GridFSBucket(_client.GetDatabase("perftest"));
        _gridFsBucket.Drop();
        _tmpDirectory = Directory.CreateDirectory("../../../../../../../data/parallel/tmpGridFS");
        PopulateDatabase();
    }

    [IterationSetup]
    public void BeforeTask()
    {
        ClearDirectory();
    }

    [Benchmark]
    public void GridFsMultiDownload()
    {
        Task[] tasks = new Task[50];
        for (int i = 0; i < 50; i++)
        {
            tasks[i] = Task.Factory.StartNew(DownloadFile(i));
        }
        Task.WaitAll(tasks);
    }

    [GlobalCleanup]
    public void Teardown()
    {
        _client.DropDatabase("perftest");
        ClearDirectory();
        _tmpDirectory.Delete();
    }

    private void ClearDirectory()
    {
        foreach (var file in _tmpDirectory.EnumerateFiles())
        {
            file.Delete();
        }
    }

    private Action DownloadFile(int fileNumber)
    {
        return () =>
        {
            string filename = $"file{fileNumber:D2}.txt";
            string resourcePath = $"../../../../../../../data/parallel/tmpGridFS/{filename}";
            _gridFsBucket.DownloadToStreamByName(filename, File.Create(resourcePath));
        };
    }

    private void PopulateDatabase()
    {
        for (int i = 0; i < 50; i++)
        {
            string filename = $"file{i:D2}.txt";
            string resourcePath = $"../../../../../../../data/parallel/gridfs_multi/{filename}";
            _gridFsBucket.UploadFromStream(filename, File.Open(resourcePath, FileMode.Open));
        }
    }
}
