module Test

open System
open Microsoft.FSharp.Text.Lexing

open PascalLexer
open PascalParser

let rec Lex expr = 
    let lexbuff = LexBuffer<char>.FromString(expr)
    while not lexbuff.IsPastEndOfStream do  
        printfn "%A" (PascalLexer.tokenize lexbuff)

let rec Parse str = 
    let lexbuff = LexBuffer<char>.FromString(str)
    let ast = PascalParser.start PascalLexer.tokenize lexbuff
    printfn "%A" ast

let expr1 = "program test_number;
begin
  i := 0;
  i := 1e10;
  i := +100;
  i := -0.1;
  i := 5e-3;
  i := 87.35E+8;
end."

let expr2 = "program mine(output);
 
var i : integer;
 
procedure print(var j: integer);
 
  function next(k: integer): integer;
  begin
    next := k + 1
  end;
 
begin
  writeln('The total is: ', j);
  j := next(j)
end;
 
begin
  i := 1;
  while i <= 10 do print(i)
end."

let DoTest = 
  Parse expr1
  Parse expr2