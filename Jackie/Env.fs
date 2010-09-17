module Env
open PascalAst
type Env = 
  | Env of PascalAst.Number_t list * PascalAst.ConstDef_t list * 
           PascalAst.TypeDef_t list * PascalAst.VarDecl_t list * 
           PascalAst.ProcFuncDecl_t list * PascalAst.Stmt_t list
(*and Ident = 
  | Id of string
and Type =
  | Integer of System.Int32
  | Float of System.Double
  | String of string
  | *)