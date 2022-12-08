open Expecto

[<EntryPoint>]
let main argv =
    Tests.tests
    |> Tests.runTestsWithCLIArgs [] argv
