// 1. Function declaration
// function GetLocalFiles(input) {
//     // ...
//     return input.output;
// }
// let usage = GetLocalFiles('../');

// 2. Function expression
// var GetLocalFiles = function(input) {
//     // ...
//     return input.output;
// };
// let usage = GetLocalFiles('../');

// 3. Shorthand method definition
// var localFiles = {
//     get: (input) => { return input.output },
//     sometingElse: (input) => { return input.output },
// };
// usage:
// localFiles.get('../');
// localFiles.sometingElse('will it work?');

// 4. Arrow function
// var GetLocalFiles = (input) => {
//     // ...
//     return input.output;
// };
// let usage = GetLocalFiles('../');

// 5. New Function
// const input='output', GetLocalFiles = new Function(input,'return output');
// usage:
// GetLocalFiles('../');

// example:
// for (const example of exampleRequest) {
//     alert("example:"+example);
// }