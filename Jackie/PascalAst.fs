namespace PascalAst
open System

type Program_t =
    | Program of ProgramHeading_t * Block_t

and ProgramHeading_t =
    | ProgramHeading of Ident_t * Ident_t list

and Block_t =
    | Block of Number_t list * ConstDef_t list * 
               TypeDef_t list * VarDecl_t list * 
               ProcFuncDecl_t list * Stmt_t list

and Number_t = 
    | Float of Double
    | Integer of Int32

and Const_t = 
    | ConstNumber of Number_t
    | ConstIdent of Ident_t
    | ConstMinusIdent of Ident_t
    | ConstString of String
    | Nil

and Ident_t = 
    | Ident of String

and NewType_t = 
    | NewOrdinalType of NewOrdinalType_t
    | NewStructuredType of NewStructuredType_t
    | NewPointerType of NewPointerType_t

and NewOrdinalType_t = 
    | EnumType of Ident_t list
    | SubrangeType of Const_t * Const_t

and NewStructuredType_t = 
    | UnpackedStructuredType of UnpackedStructuredType_t
    | PackedStructuredType of UnpackedStructuredType_t

and UnpackedStructuredType_t =
    | ArrayType of IndexType_t list * ComponentType_t
    | RecordType of RecordSection_t list * VariantPart_t
    | SetType of SetType_t
    | FileType of FileType_t

and IndexType_t = 
    | OrdinalType of OrdinalType_t

and OrdinalType_t =
    | NewOrdinalType_OT of NewOrdinalType_t
    | OrdinalTypeIdent of Ident_t
    
and ComponentType_t = 
    | TypeDenoter of TypeDenoter_t

and TypeDenoter_t = 
    | TypeIdent of Ident_t
    | NewType of NewType_t
    
and RecordSection_t = 
    | RecordSection of Ident_t list * TypeDenoter_t

and VariantPart_t = 
    | VariantPart of VariantSelector_t * Variant_t list
    | NoVariantPart

and VariantSelector_t = 
    | VariantSelector of TagField_t * TagType_t

and TagField_t = 
    | TagField of Ident_t

and TagType_t = 
    | TagType of Ident_t

and Variant_t = 
    | Variant of Const_t list * RecordSection_t list * VariantPart_t
    
and SetType_t =
    | OrdinalType_ST of OrdinalType_t

and FileType_t =
    | ComponentType_FT of ComponentType_t

and NewPointerType_t =
    | DomainType of Ident_t

and Expr_t = 
    | SimpleExpr of SimpleExpr_t
    | Eq  of SimpleExpr_t * SimpleExpr_t
    | Neq of SimpleExpr_t * SimpleExpr_t
    | Lt  of SimpleExpr_t * SimpleExpr_t
    | Gt  of SimpleExpr_t * SimpleExpr_t
    | Le  of SimpleExpr_t * SimpleExpr_t
    | Ge  of SimpleExpr_t * SimpleExpr_t
    | In  of SimpleExpr_t * SimpleExpr_t

and SimpleExpr_t = 
    | Term of Term_t
    | Neg  of SimpleExpr_t
    | Add  of SimpleExpr_t * Term_t
    | Sub  of SimpleExpr_t * Term_t
    | Or   of SimpleExpr_t * Term_t

and Term_t = 
    | Factor of Factor_t
    | Mul    of Term_t * Factor_t
    | Div    of Term_t * Factor_t
    | DivI   of Term_t * Factor_t
    | Mod    of Term_t * Factor_t
    | And    of Term_t * Factor_t

and Factor_t = 
    | VarAccess of VarAccess_t
    | UnsignedConst of Const_t
    | FuncDesign of Ident_t * Param_t list
    | SetCtor of MemberDesign_t list
    | Expr of Expr_t
    | Not  of Factor_t

and VarAccess_t =
    | EntireVar of Ident_t
    | ComponentVar of ComponentVar_t
    | IdentVar of VarAccess_t

and ComponentVar_t = 
    | IndexedVar of VarAccess_t * Expr_t list
    | FieldDesign of VarAccess_t * Ident_t
    
and Param_t =
    | ParamExpr of Expr_t
    | ParamVarAcc of VarAccess_t
    | ParamProcOrFunc of Ident_t

and MemberDesign_t =
    | MemberDesignPt of Expr_t
    | MemberDesignRange of Expr_t * Expr_t

and ConstDef_t =
    | ConstDef of Ident_t * Const_t

and TypeDef_t =
    | TypeDef of Ident_t * TypeDenoter_t

and VarDecl_t =
    | VarDecl of Ident_t list * TypeDenoter_t

and Stmt_t = 
    | LabeledStmt of Number_t * Stmt_t
    | EmptyStmt
    | IfStmt of Expr_t * Stmt_t * Stmt_t
    | CaseStmt of Expr_t * Case_t list
    | AssignStmt of AssignStmt_t
    | RepeatStmt of Stmt_t list * Expr_t
    | WhileStmt of Expr_t * Stmt_t
    | CompoundStmt of Stmt_t list
    | ForStmt of Ident_t * Expr_t * IterDirection_t * Expr_t * Stmt_t
    | WithStmt of VarAccess_t list * Stmt_t
    | ProcStmt of Ident_t * Param_t list
    | GotoStmt of Number_t
and AssignStmt_t =
    | VarAssign of VarAccess_t * Expr_t
    | FuncAssign of Ident_t * Expr_t

and Case_t = 
    | Case of Const_t list * Stmt_t

and IterDirection_t = 
    | To | Downto

and ProcFuncDecl_t =
    | ProcDecl of ProcHeading_t * ProcFuncBody_t
    | FuncDecl of FuncHeading_t * ProcFuncBody_t

and ProcHeading_t =
    | ProcHeading of Ident_t * ParamSpec_t list

and FuncHeading_t =
    | FuncHeading of Ident_t * ResultType_t * ParamSpec_t list

and ProcFuncBody_t = 
    | Directive of Ident_t
    | ProcBody of Block_t
    | FuncBody of Block_t

and ResultType_t =
    | ResultType of Ident_t
    | Void

and ParamSpec_t = 
    | FuncParamSpec of FuncHeading_t
    | ProcParamSpec of ProcHeading_t
    | ValParamSpec of Ident_t list * Ident_t
    | VarParamSpec of Ident_t list * Ident_t