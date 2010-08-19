Inspector
==========
Tiny type/method call indexer created because Visual Studio's `Find All References` only searches currently opened projects.

Mostly created as an excuse to mess around with [cci.metadata][1] and [MongoDB][2]

Injector
=========

Default api for injecting ops is kinda ugly

    (method.Body as MethodBody).Operations.Insert(0, new Operation() { OperationCode = OperationCode.Ldstr, Value = "hello world" });

A new Block type, indexers, and some static type checks later we get

    Injector.Inject(method, new Block()
      [Ops.Ldstr, "hello world"]
      [Ops.Call, Console.WriteLine]);

Okay so the console.writeline delegate was a lie.  Pretend it's actually the IMethodDefinition

[1]: http://ccimetadata.codeplex.com/
[2]: http://www.mongodb.org
