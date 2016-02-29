﻿namespace DG.XrmContext

open DG.XrmContext
open GeneratorLogic
open System.Configuration

type ArgInfo = { command: string; description: string; required: bool }

type Args private () =
  static member expectedArgs = [
    { command="url"
      description="Url to the Organization.svc"
      required=true }

    { command="username"
      description="CRM Username"
      required=true }

    { command="password"
      description="CRM Password"
      required=true }

    { command="domain"
      description="Domain to use for CRM"
      required=false }

    { command="ap"
      description="Authentication Provider Type"
      required=false }

    { command="out"
      description="Output directory for the generated files"
      required=false }

    { command="solutions"
      description="Comma-separated list of solutions names. Generates code for the entities found in these solutions."
      required=false }

    { command="entities"
      description="Comma-separated list of logical names of the entities it should generate code for. This is additive with the entities gotten via the \"solutions\" argument."
      required=false }

    { command="namespace"
      description="The namespace for the generated code. The default is the global namespace."
      required=false }

    { command="servicecontextname"
      description="The name of the generated organization service context class. If no value is supplied, no service context is created."
      required=false }

    { command="deprecatedprefix";
      description="Marks all attributes with the given prefix in their display name as deprecated."
      required=false }
    ]

  // Usage
  static member usageString = 
    @"Usage: XrmContext.exe /url:http://<serverName>/<organizationName>/XRMServices/2011/Organization.svc /username:<username> /password:<password>"
  

  static member genConfig () =
    let configmanager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
    let config = configmanager.AppSettings.Settings
    config.Add("url", "https://INSTANCE.crm4.dynamics.com/XRMServices/2011/Organization.svc")
    config.Add("username","admin@INSTANCE.onmicrosoft.com")
    config.Add("password", "pass@word1")
    configmanager.Save(ConfigurationSaveMode.Modified)
    printfn "Generated configuration file with dummy values. Change them to fit your environment."


  static member useConfigArgs = [ "-useconfig"; "/useconfig"; "-uc"; "/uc" ] |> Set.ofList
  static member genConfigArgs = [ "-genconfig"; "/genconfig"; "-gc"; "/gc" ] |> Set.ofList
  static member helpArgs = [ "help"; "-h"; "-help"; "--help"; "/h"; "/help" ] |> Set.ofList