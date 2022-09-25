pragma solidity ^0.4.11;
contract Purchase {
 address public seller;
 modifier onlySeller() { // Modifier
 require(msg.sender == seller);
 _;
 }
 function abort() public onlySeller { // Modifier usage
 // ...
 }
}