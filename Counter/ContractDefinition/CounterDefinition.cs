using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SolidityPracticeCodes.Contracts.Counter.ContractDefinition
{


    public partial class CounterDeployment : CounterDeploymentBase
    {
        public CounterDeployment() : base(BYTECODE) { }
        public CounterDeployment(string byteCode) : base(byteCode) { }
    }

    public class CounterDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50610113806100206000396000f3fe6080604052348015600f57600080fd5b506004361060465760003560e01c806306661abd14604b578063371303c01460655780636d4ce63c14606d578063b3bcfa82146074575b600080fd5b605360005481565b60405190815260200160405180910390f35b606b607a565b005b6000546053565b606b6091565b6001600080828254608a919060b7565b9091555050565b6001600080828254608a919060cd565b634e487b7160e01b600052601160045260246000fd5b8082018082111560c75760c760a1565b92915050565b8181038181111560c75760c760a156fea26469706673582212206e1010b6bbe9fe061546b6be25f20502e53987a45f61c3cb18fc94120ccb0d1564736f6c63430008110033";
        public CounterDeploymentBase() : base(BYTECODE) { }
        public CounterDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CountFunction : CountFunctionBase { }

    [Function("count", "uint256")]
    public class CountFunctionBase : FunctionMessage
    {

    }

    public partial class DecFunction : DecFunctionBase { }

    [Function("dec")]
    public class DecFunctionBase : FunctionMessage
    {

    }

    public partial class GetFunction : GetFunctionBase { }

    [Function("get", "uint256")]
    public class GetFunctionBase : FunctionMessage
    {

    }

    public partial class IncFunction : IncFunctionBase { }

    [Function("inc")]
    public class IncFunctionBase : FunctionMessage
    {

    }

    public partial class CountOutputDTO : CountOutputDTOBase { }

    [FunctionOutput]
    public class CountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class GetOutputDTO : GetOutputDTOBase { }

    [FunctionOutput]
    public class GetOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
