﻿using System;
using System.Threading.Tasks;
using ChainSafe.GamingWeb3.EVM;

namespace ChainSafe.GamingWeb3
{
  /// <summary>
  /// Facade for all Web3-related services
  /// </summary>
  public class Web3 : IDisposable
  {
    public IWeb3Environment Environment { get; internal set; }
    public IEvmClient? EvmClient { get; internal set; }

    private bool _initialized;
    
    internal Web3() { }
    public void Dispose() => Terminate();

    public async ValueTask Initialize()
    {
      if (EvmClient != null) await EvmClient.Provider.Connect();
      
      // todo initialize other components
      
      _initialized = true;
    }

    public void Terminate()
    {
      // todo
    }

  }
}