﻿let f0 (array: int array) = [|for x in array do x|]
let f00 (array: int array) = [|for x in array do yield x|]
let f000 (array: int array) = [|for x in array do let x = x in yield x|]
let f0000 (array: int array) = [|for x in array do let x = x in x|]
let f00000 (array: int array) x y = [|for z in array do let foo = z + x in let bar = z + y in yield z + foo + bar|]
let f000000 (array: int array) x y = [|for z in array do let foo = z + x in let bar = z + y in z + foo + bar|]
let f0000000 (array: int array) f x y = [|for z in array do f (); let foo = z + x in let bar = z + y in z + foo + bar|]
let f00000000 (array: int array) f x y = [|for z in array do let foo = z + x in f (); let bar = z + y in z + foo + bar|]
let f000000000 (array: int array) f x y = [|for z in array do let foo = z + x in let bar = z + y in f (); z + foo + bar|]
let f0000000000 (array: int array) (f : unit -> int) x y = [|for z in array do let foo = z + x in let bar = z + y in f (); z + foo + bar|]

let f1 (array: int array) = [|for x in array -> x|]
let f2 f (array: int array) = [|for x in array -> f x|]
let f3 f (array: int array) = [|for x in array -> f (); x|]
let f4 f g (array: int array) = [|for x in array -> f (); g(); x|]
let f5 (array: int array) = [|for x in array do yield x|]
let f6 f (array: int array) = [|for x in array do f (); yield x|]
let f7 f g (array: int array) = [|for x in array do f (); g (); yield x|]

let f8 f g (array: int array) = [|let y = f () in let z = g () in for x in array -> x + y + z|]
let f9 f g (array: int array) = [|let y = f () in g (); for x in array -> x + y|]
let f10 f g (array: int array) = [|f (); g (); for x in array -> x|]
let f11 f g (array: int array) = [|f (); let y = g () in for x in array -> x + y|]
let f12 (f: unit -> int array) y = [|for x in f () -> x + y|]

// https://github.com/dotnet/fsharp/issues/17708
// Don't read or rebind the loop variable when it is not in scope in the body.
let ``for _ in Array.groupBy id [||] do ...`` () = [|for _ in Array.groupBy id [||] do 0|]
let ``for _ | _ in Array.groupBy id [||] do ...`` () = [|for _ | _ in Array.groupBy id [||] do 0|]
let ``for _ & _ in Array.groupBy id [||] do ...`` () = [|for _ & _ in Array.groupBy id [||] do 0|]
let ``for _, _group in Array.groupBy id [||] do ...`` () = [|for _, _group in Array.groupBy id [||] do 0|]
let ``for _, group in Array.groupBy id [||] do ...`` () = [|for _, group in Array.groupBy id [||] do group.Length|]
let ``for 1 | 2 | _ in ...`` () = [|for 1 | 2 | _ in [||] do 0|]
let ``for Failure _ | _ in ...`` () = [|for Failure _ | _ in [||] do 0|]
let ``for true | false in ...`` () = [|for true | false in [||] do 0|]
let ``for true | _ in ...`` () = [|for true | _ in [||] do 0|]
let ``for _ | true in ...`` () = [|for _ | true in [||] do 0|]
