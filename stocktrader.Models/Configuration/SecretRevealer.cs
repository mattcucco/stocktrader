using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace stocktrader.Models.Configuration
{
    public interface ISecretRevealer
    {
        KeyValuePair<string, string> GetAlpacaKeys();
    }

    public class SecretRevealer : ISecretRevealer
    {
        private readonly AlpacaClient AlpacaClient;

        public SecretRevealer(IOptions<AlpacaClient> secrets)
        {
            AlpacaClient = secrets.Value ?? throw new ArgumentNullException(nameof(secrets));
        }

        public KeyValuePair<string, string> GetAlpacaKeys()
        {
            return KeyValuePair.Create(AlpacaClient.AlpacaKeyId, AlpacaClient.AlpacaKeyValue);
        }
    }
}
