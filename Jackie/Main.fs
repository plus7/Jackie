module Main
open System
open Microsoft.FSharp.Text.Lexing

open PascalLexer
open PascalParser
open Test

printfn "Jackie v0.0.1 (C) NOSE, Takafumi <ahya365@gmail.com>"

Test.DoTest

Console.WriteLine("(press any key)")   
Console.ReadKey(true) |> ignore

(*
  //MinCaml
  Lexer |> Parser |> Typing |> α変換 |> クロージャ変換
  |> 仮想機械語 |> 即値最適化 |> レジスタ割り付け |> Emit
*)
