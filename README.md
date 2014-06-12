NanoBus
=======

Install:

```
PM> Install-Package NanoBus
```

Configure:

```
public class BusModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterType<InProcessBus>()
            .AsImplementedInterfaces()
            .AutoActivate()
            .OnActivated(c => Mediator.SetInstance(c.Instance))
            .SingleInstance();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(t => t.IsClosedTypeOf(typeof (IHandleCommand<>)))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(t => t.IsClosedTypeOf(typeof (IHandleMulticastEvent<>)))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
```


And Bus.

```
var myCommand = new TestBusCommand();
Mediator.Send(command);

```
