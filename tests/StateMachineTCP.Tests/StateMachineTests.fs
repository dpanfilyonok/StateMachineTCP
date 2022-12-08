module Tests

open Expecto
open Microsoft.FSharp.Reflection
open StateMachineTCP

[<Tests>]
let tests = testList "Tests" [
    let message = "Result states should be equal"
    
    testCase "Sample 1" <| fun () ->
        let actual = StateMachine.applyEvents CLOSED [APP_PASSIVE_OPEN; APP_SEND; RCV_SYN_ACK]
        let expected = ESTABLISHED
        message |> Expect.equal actual expected
        
    testCase "Sample 2" <| fun () ->
        let actual = StateMachine.applyEvents CLOSED [APP_ACTIVE_OPEN]
        let expected = SYN_SENT
        message |> Expect.equal actual SYN_SENT
        
    testCase "Sample 3" <| fun () ->
        let actual = StateMachine.applyEvents CLOSED [APP_ACTIVE_OPEN; RCV_SYN_ACK; APP_CLOSE; RCV_FIN_ACK; RCV_ACK]
        let expected = ERROR
        message |> Expect.equal actual expected
        
    testCase "Applying empty list of events should not affect the state" <| fun () ->
        let actual = StateMachine.applyEvents LAST_ACK []
        let expected = LAST_ACK
        message |> Expect.equal actual expected
        
    testCase "ERROR should be a terminal state" <| fun () ->
        let listOfEvents =
            FSharpType.GetUnionCases typeof<Event>
            |> Array.map (fun caseInfo -> FSharpValue.MakeUnion(caseInfo, [||]) :?> Event)
            |> List.ofArray
        
        let actual = StateMachine.applyEvents ERROR listOfEvents
        let expected = ERROR
        message |> Expect.equal actual expected
]    
