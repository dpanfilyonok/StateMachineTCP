open System
open Argu
open StateMachineTCP

type CliArguments =
    | [<Unique; AltCommandLine("-s")>] Initial_State of State
    | [<Unique; AltCommandLine("-e")>] Events of Event list
    interface IArgParserTemplate with
        member this.Usage =
            match this with
            | Initial_State _ -> "Specify initial state of tcp state machine."
            | Events _ -> "Specify list of events."

let errorHandler = ProcessExiter(
    colorizer = function
        | ErrorCode.HelpText -> None
        | _ -> Some ConsoleColor.Red
)
let parser = ArgumentParser.Create<CliArguments>(programName = "StateMachineTCP", errorHandler = errorHandler)

[<EntryPoint>]
let main argv =
    let args = parser.ParseCommandLine argv
    
    StateMachine.applyEvents
        (args.GetResult(Initial_State, defaultValue = CLOSED))
        (args.GetResult(Events, defaultValue = []))
    |> printfn "%A"
    
    0