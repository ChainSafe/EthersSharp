using ChainSafe.GamingWeb3.EVM.JsonRpc;

namespace ChainSafe.GamingWeb3.NetCore.Tests;

public class Web3WIPTests
{
  private Web3 _web3;

  [SetUp]
  public void Setup()
  {
    _web3 = new Web3Builder()
      .Configure(services =>
      {
        services.UseNetCoreEnvironment();
        services.UseJsonRpcProvider(new JsonRpcProviderSettings { RpcNodeUrl = "%RPC_NODE_URL%" });
        services.UseJsonRpcWallet(new JsonRpcWalletSettings());
      })
      .Build();
  }

  [Test]
  public async Task Test1()
  {
    await _web3.Initialize();
    var httpClient = _web3.Environment.HttpClient;
    var response = await httpClient.Post<string, string>("https://httpbin.org/post", "%TEST_DATA%");
  }
}