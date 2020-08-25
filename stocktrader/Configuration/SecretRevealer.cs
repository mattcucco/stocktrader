using Microsoft.Extensions.Options;
using System;

namespace stocktrader.Configuration
{
    public interface ISecretRevealer
    {
        void Reveal();
    }

    public class SecretRevealer : ISecretRevealer
    {
        private readonly AlpacaClient AlpacaClient;

        public SecretRevealer(IOptions<AlpacaClient> secrets)
        {
            AlpacaClient = secrets.Value ?? throw new ArgumentNullException(nameof(secrets));
        }

        public void Reveal()
        {
            Console.WriteLine($"Secret Key: {AlpacaClient.AlpacaKeyId}");
            Console.WriteLine($"Secret Value: {AlpacaClient.AlpacaKeyValue}");
        }
    }
}
