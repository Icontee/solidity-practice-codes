pragma solidity  ^0.8.0;

contract Safemath {
    function testUnderflow() public pure returns (uint) {
        uint x=0;
        x--;
        return x
    }

    function testUncheckedUnderflow() public pure returns (uint) {
        uint  x=0;
        Unchecked {x--;}
        return x;
    }
}
