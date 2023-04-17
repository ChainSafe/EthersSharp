﻿using System.Text;
using Newtonsoft.Json;

namespace ChainSafe.GamingWeb3.NetCore;

public class NetCoreHttpClient : IHttpClient, IDisposable
{
  private readonly HttpClient _originalClient;

  public NetCoreHttpClient()
  {
    // todo optimization: use json serializer instance instead of static methods
    _originalClient = new HttpClient();
  }
  
  public async ValueTask<TResponse> Post<TRequest, TResponse>(string url, TRequest data)
  {
    var requestJson = JsonConvert.SerializeObject(data);
    var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
    var responseMessage = await _originalClient.PostAsync(url, requestContent);
    responseMessage.EnsureSuccessStatusCode();
    var responseJson = await responseMessage.Content.ReadAsStringAsync();
    var responseData = JsonConvert.DeserializeObject<TResponse>(responseJson);
    return responseData;
  }

  public void Dispose()
  {
    _originalClient.Dispose();
  }
}