module Interp

exception UnknownAstError of string

open System
open PascalAst

let MakeEnv vars = vars
let rec ExecStatement env s = 
  
let rec ExecStatements env ss =
  match ss with 
  | [] -> env
  | hd::rest ->
    let newenv = ExecStatement env hd in
    ExecStatements newenv rest

let rec ExecBlock env block =
  match block with 
  | PascalAst.Block(labels, consts, typedefs, 
                    vars, funcs, statements) -> 0
    
    //ToDo:Process labels

let ExecProg prog = 
  match prog with
  | PascalAst.Program( head, block ) ->
    match head with
    | PascalAst.ProgramHeading( name, args ) ->
      let initial_env = Env(args) in
      ExecBlock initial_env block

