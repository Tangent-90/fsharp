// #435263: compiler crash with .net optional parameters and F# optional syntax

//<Expects>    'string option'    </Expects>
//<Expects>but here has type</Expects>
//<Expects>    'string'    </Expects>

let _ = (TestLib.T()).NonNullOptArg(?x = "text")