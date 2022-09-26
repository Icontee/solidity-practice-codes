using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using SolidityPracticeCodes.Contracts.Counter.ContractDefinition;

namespace SolidityPracticeCodes.Contracts.Counter
{
    public partial class CounterService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, CounterDeployment counterDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CounterDeployment>().SendRequestAndWaitForReceiptAsync(counterDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, CounterDeployment counterDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CounterDeployment>().SendRequestAsync(counterDeployment);
        }

        public static async Task<CounterService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, CounterDeployment counterDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, counterDeployment, cancellationTokenSource);
            return new CounterService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public CounterService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> CountQueryAsync(CountFunction countFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CountFunction, BigInteger>(countFunction, blockParameter);
        }

        
        public Task<BigInteger> CountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CountFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> DecRequestAsync(DecFunction decFunction)
        {
             return ContractHandler.SendRequestAsync(decFunction);
        }

        public Task<string> DecRequestAsync()
        {
             return ContractHandler.SendRequestAsync<DecFunction>();
        }

        public Task<TransactionReceipt> DecRequestAndWaitForReceiptAsync(DecFunction decFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decFunction, cancellationToken);
        }

        public Task<TransactionReceipt> DecRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<DecFunction>(null, cancellationToken);
        }

        public Task<BigInteger> GetQueryAsync(GetFunction getFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetFunction, BigInteger>(getFunction, blockParameter);
        }

        
        public Task<BigInteger> GetQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> IncRequestAsync(IncFunction incFunction)
        {
             return ContractHandler.SendRequestAsync(incFunction);
        }

        public Task<string> IncRequestAsync()
        {
             return ContractHandler.SendRequestAsync<IncFunction>();
        }

        public Task<TransactionReceipt> IncRequestAndWaitForReceiptAsync(IncFunction incFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incFunction, cancellationToken);
        }

        public Task<TransactionReceipt> IncRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<IncFunction>(null, cancellationToken);
        }
    }
}
